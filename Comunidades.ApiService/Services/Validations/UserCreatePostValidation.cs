using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using FluentValidation;

namespace Comunidades.ApiService.Services.Validations
{
    public class UserCreatePostValidation : AbstractValidator<UserCreatePostRequest>
    {
        public UserCreatePostValidation() 
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage(ErrorEnum.UserInvalidFullName.GetDescription())
                .MaximumLength(UserEntity.FullNameLength)
                .WithMessage(ErrorEnum.UserFullNameOutOfRange.GetDescription());

            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage(ErrorEnum.UserInvalidUserName.GetDescription())
                .MaximumLength(UserEntity.UserNameLength)
                .WithMessage(ErrorEnum.UserUserNameOutOfRange.GetDescription());

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
