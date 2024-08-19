using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Enums;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Interfaces;

namespace Comunidades.ApiService.Services
{
    public class CommunityService : BaseService, ICommunityService
    {
        readonly IUserRepository userRepository;
        readonly ICommunityRepository communityRepository;

        public CommunityService(ICommunityRepository communityRepository, IUserRepository userRepository)
        {
            this.communityRepository = communityRepository;
            this.userRepository = userRepository;
        }

        public async Task<IServiceResult> CreateAsync(CommunityCreatePostRequest request) 
        {
            request.Sanitize();

            try
            {
                //Obtém o criador pelo Uid
                var userCreatorId = await userRepository.SelectAsync(u => u.Id, u => u.Uid == request.CreatorUid);

                if (userCreatorId == 0)
                    return BadRequest();

                var dateNow = DateTime.Now;

                var community = new CommunityEntity()
                {
                    CreatorId = userCreatorId,
                    CreationDate = dateNow,
                    LastModification = dateNow,
                    Status = DataStatus.Active,
                    Uid = Guid.NewGuid(),
                    Description = request.Description!,
                    Name = request.Name!,
                };

                await communityRepository.CreateAsync(community);
                return Ok();

            }
            catch (Exception ex) 
            {
                return InternalError();
            }
        }
    }
}
