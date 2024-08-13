using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using FluentValidation;

namespace Comunidades.ApiService.Services.Validations
{
    public class UserCreateValidation : AbstractValidator<UserCreateRequest>
    {
        public UserCreateValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorEnum.UserInvalidName.GetDescription())
                .MaximumLength(UserEntity.NameLength)
                .WithMessage(ErrorEnum.UserNameOutOfRange.GetDescription());
        }
    }
}
