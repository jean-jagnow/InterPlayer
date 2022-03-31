using FluentValidation.Results;

namespace InterPlayer.Application.Common.Exceptions;

public class ApplicationValidationException : Exception
{
    public ApplicationValidationException() : base("Ocorrerm um ou mais erros de validação.")
    {
        Errors = new Dictionary<string, string[]>();
    }

    public ApplicationValidationException(IEnumerable<ValidationFailure> failures) : this()
    {
        Errors = failures
            .Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage))
            .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
            .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
    }

    public IDictionary<string, string[]> Errors { get; }
}