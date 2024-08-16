using FluentValidation;
using FluentValidation.Results;

namespace Comunidades.ApiService.Services.Validations
{
    public static class ValidatorHelper
    {
        public static ValidationResult Validate<TValidator, TFor>(TFor request) where TValidator : AbstractValidator<TFor>
        {
            TValidator? validator = default;

            if (validator == null)
                return new ValidationResult();

            var result = validator.Validate(request);
            return result;
        }
    }
}
