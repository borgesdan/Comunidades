using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories;
using Moq;

namespace Comunidades.Tests.Api.MockExtensions.Repositories
{
    public static class CommunityRepositoryMockExtensions
    {
        public static void MockCreateAsync(this Mock<CommunityRepository> mock, int @return)
            => mock
            .Setup(m => m.CreateAsync(It.IsAny<CommunityEntity>()))
            .ReturnsAsync(@return);
    }
}
