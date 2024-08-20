using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services;
using Comunidades.Tests.Api.Builders;
using Comunidades.Tests.Api.MockExtensions.Repositories;
using Moq;

namespace Comunidades.Tests.Api.Tests.Services
{
    public class CommunityServiceTest : BaseServiceTest
    {
        readonly Mock<CommunityRepository> communityRepository;
        readonly Mock<UserRepository> userRepository;
        readonly CommunityService communityService;

        public CommunityServiceTest() 
        {
            communityRepository = new Mock<CommunityRepository>(AppDbContextMock.Object);
            userRepository = new Mock<UserRepository>(AppDbContextMock.Object);
            communityService = new CommunityService(communityRepository.Object, userRepository.Object);
        }

        [Fact]
        public async Task CreateAsync_ReturnOk()
        {
            //Arrange
            var request = new CommunityCreatePostRequestBuilder()
                .Default()
                .Get();            

            userRepository.MockSelectAsync(1);
            communityRepository.MockCreateAsync(1);

            //Act
            var result = await communityService.CreateAsync(request);

            //Assert
            Assert.True(result.Succeeded);
        }
    }
}
