namespace InterPlayer.Core.Password;

public class Options
{
    public int RequireMinimunCharacters { get; set; }
    public bool RequireDigit { get; set; }
    public bool RequireUpperCase { get; set; }
    public bool RequireLowerCase { get; set; }
    public bool RequireSpecialCharacter { get; set; }
    public bool AllowRepeatedCharacters { get; set; }
    public string SpecialCharacterPattern { get; set; } = string.Empty;
}