using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories;
using Moq;
using System.Linq.Expressions;

namespace Comunidades.Tests.Api.MockExtensions.Repositories
{
    public static class UserRepositoryMockExtensions
    {
        public static void MockCreateAsync(this Mock<UserRepository> mock, int @return)
            => mock
            .Setup(m => m.CreateAsync(It.IsAny<UserEntity>()))
            .ReturnsAsync(@return);       

        public static void MockSelectAsync<TSeletedType>(this Mock<UserRepository> mock, TSeletedType @return) 
            => mock
            .Setup(m => m.SelectAsync(It.IsAny<Expression<Func<UserEntity, TSeletedType>>>(), It.IsAny<Expression<Func<UserEntity, bool>>>()))
            .ReturnsAsync(@return);

        public static void MockCountAsync(this Mock<UserRepository> mock, int @return)
           => mock
           .Setup(m => m.CountAsync(It.IsAny<Expression<Func<UserEntity, bool>>>()))
           .ReturnsAsync(@return);
    }
}
