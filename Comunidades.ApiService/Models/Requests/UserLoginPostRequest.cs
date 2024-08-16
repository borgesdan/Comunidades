namespace Comunidades.ApiService.Models.Requests
{
    public class UserLoginPostRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public void Sanitize()
        {
            Email = Email?.Trim() ?? string.Empty;
            Password = Password?.Trim() ?? string.Empty;
        }
    }
}
