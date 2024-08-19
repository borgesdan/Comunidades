using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using FluentValidation;

namespace Comunidades.ApiService.Services.Validations
{
    public class CommunityCreatePostValidation : AbstractValidator<CommunityCreatePostRequest>
    {
        public CommunityCreatePostValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorEnum.CommunityEmptyName.GetDescription())
                .MaximumLength(CommunityEntity.NameLength)
                .WithMessage(ErrorEnum.CommunityNameOutOfRange.GetDescription());

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage(ErrorEnum.CommunityEmptyDescription.GetDescription())
                .MaximumLength(CommunityEntity.DescriptionLength)
                .WithMessage(ErrorEnum.CommunityDescriptionOutOfRange.GetDescription());

            RuleFor(x => x.CreatorUid)
                .NotEmpty()
                .WithMessage(ErrorEnum.CommunityInvalidCreator.GetDescription());
        }
    }
}
