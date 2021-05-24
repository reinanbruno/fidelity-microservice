using AutoMapper;
using System.Threading.Tasks;
using UserService.Application.Commands.InsertUserAddress;
using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using Xunit;

namespace UserService.Test.Commands.UserAddress
{
    public class InsertUserAddressTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserAddressRepository _userAddressRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertUserAddressTest(IUserRepository userRepository, IUserAddressRepository userAddressRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userAddressRepository = userAddressRepository;
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task Command_Valid_Executed_With_Success()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertUserAddressMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertUserAddressInputModel
            {
                userId = 1,
                address = "Rua 1",
                city = "Salvador",
                state = "BA",
                district = "Barra"
            };

            var commandHandler = new InsertUserAddressCommandHandler(
                _userRepository,
                _userAddressRepository,
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
                cfg.AddProfile(new InsertUserAddressMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var inputModel = new InsertUserAddressInputModel
            {
                userId = 10,
                address = "Rua 1",
                city = "Salvador",
                state = "BA",
                district = "Barra"
            };

            var commandHandler = new InsertUserAddressCommandHandler(
                _userRepository,
                _userAddressRepository,
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
