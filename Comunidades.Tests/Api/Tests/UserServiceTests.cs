using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services;
using Comunidades.Tests.Api.Builders;
using Moq;

namespace Comunidades.Tests.Api.Tests
{
    public class UserServiceTests : BaseTest
    {
        readonly Mock<UserRepository> userRepository;
        readonly Mock<UserService> userService;

        public UserServiceTests() 
        {
            userRepository = new Mock<UserRepository>(AppDbContextMock.Object);
            userService = new Mock<UserService>(userRepository.Object);
        }

        [Fact]
        public async Task CreateAsyncReturnOk()
        {
            //Arrange
            var userCreateRequest = new UserCreatePostRequestBuilder()
                .Default()
                .Build();

            //Act
            var result = await userService.Object.CreateAsync(userCreateRequest);            

            //Assert
            Assert.True(result.Succeeded);
        }
    }
}
