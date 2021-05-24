using AutoMapper;
using ProductService.Application.Commands.InsertOrder;
using ProductService.Core.Interfaces;
using ProductService.Core.Interfaces.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace ProductService.Test.Commands.Order
{
    public class InsertOrderTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserPointHistoryRepository _userPointHistoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertOrderTest(IUserRepository userRepository, IUserPointHistoryRepository userPointHistoryRepository, IOrderRepository orderRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userPointHistoryRepository = userPointHistoryRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task Command_Valid_Executed_With_Success()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertOrderInputModelMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertOrderInputModel
            {
                userId = 1,
                productId = 1,
                userAddressId = 1
            };

            var commandHandler = new InsertOrderCommandHandler(
                _userRepository,
                _userPointHistoryRepository,
                _orderRepository,
                _productRepository,
                mapper,
                _unitOfWork
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_User_Not_Exists()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertOrderInputModelMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertOrderInputModel
            {
                userId = 9,
                productId = 1,
                userAddressId = 1
            };

            var commandHandler = new InsertOrderCommandHandler(
                _userRepository,
                _userPointHistoryRepository,
                _orderRepository,
                _productRepository,
                mapper,
                _unitOfWork
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_User_Address_Not_Exists()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertOrderInputModelMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertOrderInputModel
            {
                userId = 1,
                productId = 1,
                userAddressId = 3
            };

            var commandHandler = new InsertOrderCommandHandler(
                _userRepository,
                _userPointHistoryRepository,
                _orderRepository,
                _productRepository,
                mapper,
                _unitOfWork
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_Product_Not_Exists()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertOrderInputModelMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertOrderInputModel
            {
                userId = 1,
                productId = 9,
                userAddressId = 1
            };

            var commandHandler = new InsertOrderCommandHandler(
                _userRepository,
                _userPointHistoryRepository,
                _orderRepository,
                _productRepository,
                mapper,
                _unitOfWork
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_Product_Value_Greater_Than_Balance()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertOrderInputModelMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertOrderInputModel
            {
                userId = 1,
                productId = 3,
                userAddressId = 1
            };

            var commandHandler = new InsertOrderCommandHandler(
                _userRepository,
                _userPointHistoryRepository,
                _orderRepository,
                _productRepository,
                mapper,
                _unitOfWork
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

    }
}
