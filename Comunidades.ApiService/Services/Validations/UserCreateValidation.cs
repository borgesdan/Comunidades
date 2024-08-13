using Comunidades.ApiService.Extensions;
using FluentValidation;

namespace Comunidades.ApiService.Services.Validations
{
    public class UserCreateValidation : AbstractValidator<UserCreateRequest>
    {
        public UserCreateValidation() 
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage(ErrorEnum.UserCreateInvalidName.GetDescription());
        }
    }
}
