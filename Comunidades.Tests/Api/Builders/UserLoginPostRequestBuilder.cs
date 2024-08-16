using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;

namespace Comunidades.Tests.Api.Builders
{
    public class UserLoginPostRequestBuilder : BaseBuilder<UserLoginPostRequest>
    {
        public override BaseBuilder<UserLoginPostRequest> Default(int numberOfItems = 1)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                var person = NewPerson();

                var entity = new UserLoginPostRequest
                {
                    Email = person.Email,
                    Password = person.Random.AlphaNumeric(UserEntity.PasswordToUserMaxLength),
                };

                Entities.Add(entity);
            }

            return this;
        }
    }
}
