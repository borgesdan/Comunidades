using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories;
using Moq;

namespace Comunidades.Tests.Api.MockExtensions.Repositories
{
    public static class UserRepositoryMockExtensions
    {
        public static void MockCreateAsync(this Mock<UserRepository> mock, UserEntity entity, UserEntity @return = null)
            => mock
            .Setup(m => m.CreateAsync(entity))
            .ReturnsAsync(@return);
    }
}
