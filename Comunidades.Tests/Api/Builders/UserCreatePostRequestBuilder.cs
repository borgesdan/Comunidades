using Bogus;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;

namespace Comunidades.Tests.Api.Builders
{
    public class UserCreatePostRequestBuilder : BaseBuilder<UserCreatePostRequest>
    {
        public override BaseBuilder<UserCreatePostRequest> Default(int numberOfItems = 1)
        {
            for (int i = 0; i < numberOfItems; i++) 
            {
                var person = new Person(locale: PT_BR);

                var entity = new UserCreatePostRequest
                {
                    FullName = FakeBuilder.Name.FullName(),
                    Email = person.Email,
                    UserName = person.UserName.Length < UserEntity.UserNameLength ? person.UserName : person.UserName.Substring(0, UserEntity.UserNameLength),
                    Password = FakeBuilder.Random.AlphaNumeric(8)
                };

                Entities.Add(entity);
            }

            return this;
        }
    }
}
