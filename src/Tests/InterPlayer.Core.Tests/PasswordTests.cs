using InterPlayer.Core.Common;
using InterPlayer.Core.Password;
using Xunit;

namespace InterPlayer.Core.Tests;

public class PasswordTests
{
    private readonly PasswordChecker checker;

    public PasswordTests()
    {
        this.checker = new PasswordChecker(new());
    }

    [Fact]
    public void RequireMinimunCharacters()
    {
        int size = 4;
        Assert.True(checker.HasMinimunCharacters("abcd", size));

        Assert.True(checker.HasMinimunCharacters("abcde", size));

        Assert.False(checker.HasMinimunCharacters("abc", size));
    }

    [Fact]
    public void RequireDigit()
    {
        Assert.False(checker.HasDigit("abc"));
        Assert.True(checker.HasDigit("abc1"));
    }

    [Fact]
    public void RequireUpperCase()
    {
        Assert.False(checker.HasUpperCase("abc"));
        Assert.True(checker.HasUpperCase("abB"));
    }

    [Fact]
    public void RequireLowerCase()
    {
        Assert.True(checker.HasLowerCase("AbC"));
        Assert.False(checker.HasLowerCase("AAABBB"));
    }

    [Fact]
    public void RequireSpecialCharacter()
    {
        Assert.True(checker.HasCharacterPattern("AAABBB@123", "!@#$%^&*()-+"));
        Assert.True(checker.HasCharacterPattern("AAABBB+$%123", "!@#$%^&*()-+"));
        Assert.False(checker.HasCharacterPattern("AAABBB123", "!@#$%^&*()-+"));
    }

    [Fact]
    public void RepeatedCharacters()
    {
        Assert.True(checker.HasRepeatedCharacters("AAABBB@123"));
        Assert.False(checker.HasRepeatedCharacters("ABC@123"));
    }

    [Theory]
    [InlineData("Bantu@190247c")]
    [InlineData("Senha@1234")]
    public void ValidatePassowd_Valids(string value)
    {
        Assert.True(new PasswordChecker(new()
        {
            AllowRepeatedCharacters = false,
            RequireDigit = true,
            RequireLowerCase = true,
            RequireMinimunCharacters = 9,
            RequireSpecialCharacter = true,
            RequireUpperCase = true,
            SpecialCharacterPattern = "!@#$%^&*()-+"
        }).Validate(value).Type == ValidateResultType.Succeeded);
    }

    [Theory]
    [InlineData("aa")]
    [InlineData("aaBC@12")]
    [InlineData("AAAAA")]
    [InlineData("1234")]
    [InlineData("1234@")]
    [InlineData("1234@A")]
    [InlineData("1234@a")]
    public void ValidatePassowd_Invalid(string value)
    {
        Assert.True(new PasswordChecker(new()
        {
            AllowRepeatedCharacters = false,
            RequireDigit = true,
            RequireLowerCase = true,
            RequireMinimunCharacters = 9,
            RequireSpecialCharacter = true,
            RequireUpperCase = true,
            SpecialCharacterPattern = "!@#$%^&*()-+"
        }).Validate(value).Type == ValidateResultType.Failed);
    }
}