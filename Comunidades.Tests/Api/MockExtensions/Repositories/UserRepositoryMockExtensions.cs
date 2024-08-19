using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Interfaces;
using Moq;
using System;
using System.Linq.Expressions;

namespace Comunidades.Tests.Api.MockExtensions.Repositories
{
    public static class UserRepositoryMockExtensions
    {
        public static void MockCreateAsync(this Mock<UserRepository> mock, UserEntity @return)
            => mock
            .Setup(m => m.CreateAsync(It.IsAny<UserEntity>()))
            .ReturnsAsync(@return);

        public static void MockToQuery(this Mock<UserRepository> mock, IQueryable<UserEntity> @return)
            => mock
            .Setup(m => m.ToQuery())
            .Returns(@return);

        public static void MockSelectAsync<TSeletedType>(this Mock<UserRepository> mock, TSeletedType @return) 
            => mock
            .Setup(m => m.SelectAsync(It.IsAny<Expression<Func<UserEntity, TSeletedType>>>(), It.IsAny<Expression<Func<UserEntity, bool>>>()))
            .ReturnsAsync(@return);
    }
}
