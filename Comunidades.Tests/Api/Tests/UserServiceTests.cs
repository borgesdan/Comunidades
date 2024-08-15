using Comunidades.ApiService.Models.Responses;
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
                .Get();

            //Act
            var result = await userService.Object.CreateAsync(userCreateRequest!);            
            var data = result.GetData<UserCreatePostResponse>();

            //Assert
            Assert.True(result.Succeeded);
            Assert.True(data != null);
            Assert.True(data.Uid != Guid.Empty);
        }
    }
}
