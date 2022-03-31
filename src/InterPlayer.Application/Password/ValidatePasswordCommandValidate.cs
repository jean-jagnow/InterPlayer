using FluentValidation;
using InterPlayer.Application.PropertyValidators;
using InterPlayer.Core.Password;

namespace InterPlayer.Application.Password;

public sealed class ValidatePasswordCommandValidate : AbstractValidator<ValidatePasswordCommand>
{
    public ValidatePasswordCommandValidate(IPasswordChecker passwordChecker)
    {
        RuleFor(x => x.Password)
        .SetValidator(new PasswordPropertyValidator(passwordChecker));
    }
}