using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using InterPlayer.Application.Password;
using InterPlayer.Core.Common;
using InterPlayer.Core.Password;

namespace InterPlayer.Application.PropertyValidators;

public class PasswordPropertyValidator : IPropertyValidator<ValidatePasswordCommand, string>
{
    private readonly IPasswordChecker passwordChecker;

    public PasswordPropertyValidator(IPasswordChecker passwordChecker)
    {
        this.passwordChecker = passwordChecker;
    }

    public string Name { get; } = nameof(Password);

    public string GetDefaultMessageTemplate(string errorCode)
        => string.Empty;

    public bool IsValid(ValidationContext<ValidatePasswordCommand> context, string value)
    {
        var result = passwordChecker.Validate(context.InstanceToValidate.Password);
        if (result.Type == ValidateResultType.Failed)
            foreach (var item in result.Errors)
                context.AddFailure(new ValidationFailure(Name, item));

        return result.Type != ValidateResultType.Failed;
    }
}