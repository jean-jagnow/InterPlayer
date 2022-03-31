using InterPlayer.Core.Common;

namespace InterPlayer.Core.Password;

public class PasswordChecker : IPasswordChecker
{
    protected Options options;

    public PasswordChecker(Options options)
    {
        this.options = options;
    }

    public virtual ValidateResult Validate(string value)
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        var erros = new List<string>();

        if (!HasMinimunCharacters(value, options.RequireMinimunCharacters))
            erros.Add(string.Format(Messages.RequireMinimunCharacters, options.RequireMinimunCharacters));

        if (options.RequireDigit && !HasDigit(value))
            erros.Add(string.Format(Messages.RequireDigit, options.RequireDigit));

        if (options.RequireUpperCase && !HasUpperCase(value))
            erros.Add(string.Format(Messages.RequireUpperCase, options.RequireUpperCase));

        if (options.RequireLowerCase && !HasLowerCase(value))
            erros.Add(string.Format(Messages.RequireLowerCase, options.RequireLowerCase));

        if (!options.AllowRepeatedCharacters && HasRepeatedCharacters(value))
            erros.Add(string.Format(Messages.AllowRepeatedCharacters, options.AllowRepeatedCharacters));

        if (options.RequireSpecialCharacter)
        {
            if (!HasCharacterPattern(value, options.SpecialCharacterPattern))
                erros.Add(string.Format(Messages.SpecialCharacterPattern, options.SpecialCharacterPattern));
        }

        if (erros.Any())
            return ValidateResult.Failed(erros);

        return ValidateResult.Succeeded();
    }

    public virtual bool HasMinimunCharacters(string value, int size)
        => !string.IsNullOrWhiteSpace(value) && value.Length >= size;

    public virtual bool HasDigit(string value)
        => value.Any(x => char.IsDigit(x));

    public virtual bool HasUpperCase(string value)
        => value.Any(x => char.IsUpper(x));

    public virtual bool HasLowerCase(string value)
        => value.Any(x => char.IsLower(x));

    public virtual bool HasRepeatedCharacters(string value)
        => !value.GroupBy(x => x).All(x => x.Count() == 1);

    public virtual bool HasCharacterPattern(string value, string pattern)
        => value.Any(x => pattern.Contains(x));
}