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

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(ErrorEnum.UserInvalidUserName.GetDescription())
                .MaximumLength(UserEntity.NameLength)
                .WithMessage(ErrorEnum.UserUserNameOutOfRange.GetDescription());

            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(ErrorEnum.UserInvalidEmail.GetDescription())
               .MaximumLength(UserEntity.NameLength)
               .WithMessage(ErrorEnum.UserEmailOutOfRange.GetDescription())
               .EmailAddress()
               .WithMessage(ErrorEnum.UserInvalidEmail.GetDescription());

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(ErrorEnum.UserInvalidPassword.GetDescription())
               .MaximumLength(UserEntity.PasswordLength)
               .WithMessage(ErrorEnum.UserInvalidPassword.GetDescription());
        }
    }
}
