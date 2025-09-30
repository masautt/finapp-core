namespace Models.Auth;

public class LoginResponseDto
{
    public string AccessToken { get; set; }
    public string TokenType { get; set; }
    public int ExpiresIn { get; set; }
    public long ExpiresAt { get; set; }
    public string RefreshToken { get; set; }
}