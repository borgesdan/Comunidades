using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Enums;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Models.Responses;
using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Interfaces;
using Comunidades.ApiService.Services.Validations;

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

            var validatorResult = ValidatorHelper.Validate<CommunityCreatePostValidation, CommunityCreatePostRequest>(request);

            if (!validatorResult.IsValid)
                return BadRequest(validatorResult.Errors.FirstOrDefault()?.ErrorMessage);

            try
            {
                //Obtém o criador pelo Uid
                var userCreatorId = await userRepository.SelectAsync(u => u.Id, u => u.Uid == request.CreatorUid);

                if (userCreatorId == 0)
                    return BadRequest(ErrorEnum.CommunityInvalidCreator);

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

                var createResult = await communityRepository.CreateAsync(community);

                if (createResult == 0)
                    return InternalError(ErrorEnum.InternalCreateDbError);

                var response = new CommunityCreatePostResponse() { Uid = community.Uid };

                return Ok(response);
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError);
            }
        }
    }
}
