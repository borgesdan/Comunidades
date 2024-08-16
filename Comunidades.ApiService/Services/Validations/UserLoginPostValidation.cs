using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using FluentValidation;

namespace Comunidades.ApiService.Services.Validations
{
    public class UserLoginPostValidation : AbstractValidator<UserLoginPostRequest>
    {
        public UserLoginPostValidation()
        {
            RuleFor(x => x.Email)
               .NotEmpty()
               .WithMessage(ErrorEnum.UserInvalidEmail.GetDescription())
               .MaximumLength(UserEntity.FullNameLength)
               .WithMessage(ErrorEnum.UserEmailOutOfRange.GetDescription())
               .EmailAddress()
               .WithMessage(ErrorEnum.UserInvalidEmail.GetDescription());

            RuleFor(x => x.Password)
               .NotEmpty()
               .WithMessage(ErrorEnum.UserInvalidPassword.GetDescription())
               .MaximumLength(UserEntity.PasswordToUserMaxLength)
               .WithMessage(ErrorEnum.UserInvalidPassword.GetDescription())
               .MinimumLength(UserEntity.PasswordToUserMinLength)
               .WithMessage(ErrorEnum.UserInvalidPassword.GetDescription());
        }
    }
}
