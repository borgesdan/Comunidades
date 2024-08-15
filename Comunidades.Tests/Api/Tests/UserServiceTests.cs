using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services;
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
            var userCreateRequest = new UserCreatePostRequest
            {
                FullName = "Full Name User",
                Email = "danilo@email.com",
                Password = "password",
                UserName = "dan.bs."
            };

            //Act
            var result = await userService.Object.CreateAsync(userCreateRequest);            

            //Assert
            Assert.True(result.Succeeded);
        }
    }
}
