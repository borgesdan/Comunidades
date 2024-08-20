using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Responses;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services;
using Comunidades.ApiService.Shared;
using Comunidades.Tests.Api.Builders;
using Comunidades.Tests.Api.MockExtensions.Repositories;
using Moq;

namespace Comunidades.Tests.Api.Tests.Services
{
    public class UserServiceTests : BaseServiceTest
    {
        readonly Mock<UserRepository> userRepository;
        readonly Mock<UserService> userService;

        public UserServiceTests()
        {
            userRepository = new Mock<UserRepository>(AppDbContextMock.Object);
            userService = new Mock<UserService>(userRepository.Object);
        }

        [Fact]
        public async Task CreateAsync_ReturnOk()
        {
            //Arrange
            var request = new UserCreatePostRequestBuilder()
                .Default()
                .Get();

            userRepository.MockSelectAsync(0);
            userRepository.MockCreateAsync(1);

            //Act
            var result = await userService.Object.CreateAsync(request!);
            var data = result.GetData<UserCreatePostResponse>();

            //Assert
            Assert.True(result.Succeeded);
            Assert.True(data != null);
            Assert.True(data.Uid != Guid.Empty);
        }

        [Fact]
        public async Task LoginAsync_ReturnOk()
        {
            //Arrange
            var request = new UserLoginPostRequestBuilder()
                .Default()
                .Get();

            //Act
            var passwordHash = Password.GetPasswordHash(request!.Password!, "0");

            var userEntity = new UserEntity()
            {
                Email = request.Email,
                PasswordHash = passwordHash.Hash,
                PasswordSalt = "0",
            };

            userRepository.MockSelectAsync(userEntity);

            var result = await userService.Object.LoginAsync(request);
            var data = result.GetData<UserLoginPostResponse>();

            //Assert
            Assert.True(result.Succeeded);
            Assert.True(data != null);
            Assert.True(!string.IsNullOrWhiteSpace(data.Token));
        }
    }
}
