using ProductService.Application.Commands.Contract;
using AutoMapper;
using ProductService.Core.Enums;
using ProductService.Core.Interfaces;
using ProductService.Core.Interfaces.Repositories;
using ProductService.Core.Models;
using MediatR;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.Commands.InsertOrder
{
    public class InsertOrderCommandHandler : IRequestHandler<InsertOrderInputModel, ICommandResult<int>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPointHistoryRepository _userPointHistoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public InsertOrderCommandHandler(IUserRepository userRepository, IUserPointHistoryRepository userPointHistoryRepository, IOrderRepository orderRepository, IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userPointHistoryRepository = userPointHistoryRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ICommandResult<int>> Handle(InsertOrderInputModel request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.Find(x => x.UserId == request.userId && x.Active == 1);

            if (user == null)
            {
                return new CommandResult<int>
                {
                    message = "Usuário não encontrado!",
                    success = false,
                    httpStatusCode = HttpStatusCode.NotFound
                };

            }

            if (user.UserAddresses.FirstOrDefault(x => x.UserAddressId == request.userAddressId) == null)
            {
                return new CommandResult<int>
                {
                    message = "Endereço não está associado com o usuário!",
                    success = false,
                    httpStatusCode = HttpStatusCode.NotFound
                };

            }

            Product product = await _productRepository.Find(x => x.ProductId == request.productId && x.Active == 1);

            if (product == null)
            {
                return new CommandResult<int>
                {
                    message = "Produto não encontrado!",
                    success = false,
                    httpStatusCode = HttpStatusCode.NotFound
                };

            }

            if (user.CurrentPointsBalance < product.PointsValue)
            {
                return new CommandResult<int>
                {
                    message = "Ops! Você não tem saldo suficiente para resgatar esse produto.",
                    success = false,
                    httpStatusCode = HttpStatusCode.BadRequest
                };

            }

            Order order = _mapper.Map<InsertOrderInputModel, Order>(request);
            order.PointsValue = product.PointsValue;
            order.OrderHistories.Add(new OrderHistory
            {
                Details = "Produto está sendo preparado.",
                RegistrationDate = DateTime.Now,
                OrderStatusId = (char)StatusOrderEnum.PreparingProduct
            });
            await _orderRepository.Insert(order);

            user.CurrentPointsBalance = (user.CurrentPointsBalance - product.PointsValue);
            await _userRepository.Update(user);

            UserPointHistory userPointHistory = new UserPointHistory
            {
                UserId = user.UserId,
                PointBalance = user.CurrentPointsBalance,
                RegistrationDate = DateTime.Now
            };
            await _userPointHistoryRepository.Insert(userPointHistory);
            await _unitOfWork.Commit();

            return new CommandResult<int>
            {
                response = order.OrderId,
                message = $"Pedido do produto {product.Name} criado com sucesso!",
                success = true,
                httpStatusCode = HttpStatusCode.Created
            };
        }
    }
}
