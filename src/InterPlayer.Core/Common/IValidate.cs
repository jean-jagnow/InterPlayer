namespace InterPlayer.Core.Common;

public interface IValidate<TValue>
{
    ValidateResult Validate(TValue value);
}