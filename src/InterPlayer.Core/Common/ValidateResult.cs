namespace InterPlayer.Core.Common;

public class ValidateResult
{
    private List<string> _errors { get; set; } = new();
    public ValidateResultType Type { get; private set; }
    public IReadOnlyList<string> Errors => _errors;

    public static ValidateResult Failed(List<string> errors)
        => new ValidateResult
        {
            _errors = errors,
            Type = ValidateResultType.Failed
        };

    public static ValidateResult Succeeded()
        => new ValidateResult
        {
            Type = ValidateResultType.Succeeded
        };
}