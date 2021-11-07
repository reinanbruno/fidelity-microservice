using AutoMapper;
using Moq;
using System;
using System.Threading.Tasks;
using UserService.Application.Commands.InsertUser;
using UserService.Core.Interfaces;
using UserService.Core.Interfaces.Repositories;
using UserService.Core.Interfaces.Services;
using Xunit;

namespace UserService.Test.Commands.User
{
    public class InsertUserTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public InsertUserTest(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public async Task Command_Valid_Executed_With_Success()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertUserMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var criptographyServiceMock = new Mock<ICryptographyService>();

            var inputModel = new InsertUserInputModel
            {
                birthDate = DateTime.Now,
                cellphone = "71981818283",
                email = "teste10@hotmail.com",
                individualTaxpayerRegistration = "74084578010",
                name = "Teste 10",
                password = "123456"
            };

            criptographyServiceMock.Setup(x => x.Encrypt(inputModel.password)).Returns(inputModel.password);

            var commandHandler = new InsertUserCommandHandler(
                _userRepository,
                mapper,
                _unitOfWork,
                criptographyServiceMock.Object
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.True(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_Email_Exists()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertUserMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var criptographyServiceMock = new Mock<ICryptographyService>();

            var inputModel = new InsertUserInputModel
            {
                birthDate = DateTime.Now,
                cellphone = "71981818283",
                email = "t1@gmail.com",
                individualTaxpayerRegistration = "74084578010",
                name = "Teste 10",
                password = "123456"
            };

            criptographyServiceMock.Setup(x => x.Encrypt(inputModel.password)).Returns(inputModel.password);

            var commandHandler = new InsertUserCommandHandler(
                _userRepository,
                mapper,
                _unitOfWork,
                criptographyServiceMock.Object
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.False(dimensionTravelledResult.success);
        }

        [Fact]
        public async Task Command_Invalid_Individual_Taxpayer_Registration_Exists()
        {
            // Arrange
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new InsertUserMapping());
            });
            var mapper = mockMapper.CreateMapper();

            var criptographyServiceMock = new Mock<ICryptographyService>();

            var inputModel = new InsertUserInputModel
            {
                birthDate = DateTime.Now,
                cellphone = "71981818283",
                email = "teste10@hotmail.com",
                individualTaxpayerRegistration = "90144123045",
                name = "Teste 10",
                password = "123456"
            };

            criptographyServiceMock.Setup(x => x.Encrypt(inputModel.password)).Returns(inputModel.password);

            var commandHandler = new InsertUserCommandHandler(
                _userRepository,
                mapper,
                _unitOfWork,
                criptographyServiceMock.Object
             );

            // Act
            var dimensionTravelledResult = await commandHandler.Handle(inputModel, new System.Threading.CancellationToken());

            // Assert
            Assert.False(dimensionTravelledResult.success);
        }
    }
}
