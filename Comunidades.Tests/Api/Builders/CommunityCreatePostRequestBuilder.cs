using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;

namespace Comunidades.Tests.Api.Builders
{
    public class CommunityCreatePostRequestBuilder : BaseBuilder<CommunityCreatePostRequest>
    {
        public override BaseBuilder<CommunityCreatePostRequest> Default(int numberOfItems = 1)
        {
            for (int i = 0; i < numberOfItems; i++) 
            {
                var entity = new CommunityCreatePostRequest
                {
                    CreatorUid = FakeBuilder.Random.Guid(),
                    Description = FakeBuilder.Random.String(CommunityEntity.DescriptionLength - 10),
                    Name = FakeBuilder.Random.String(CommunityEntity.NameLength - 10),
                };

                Entities.Add(entity);
            }

            return this;
        }
    }
}
