namespace Comunidades.ApiService.Models.Requests
{
    public class UserCreatePostRequest
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }

        public void Sanitize()
        {
            FullName = FullName?.Trim();
            Email = Email?.Trim();
            Password = Password?.Trim();
            UserName = UserName?.Trim();
        }
    }
}
