using Comunidades.ApiService.Services;

namespace Comunidades.ApiService.Shared
{
    public class Password
    {
        public string Hash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty;

        /// <summary>
        /// Obtém um objeto PasswordHash. O salt será criado internamente caso seja nulo.
        /// </summary>        
        static public Password GetPasswordHash(string password, string? salt = null, int hashInteration = 3)
        {
            salt ??= PasswordHasher.GenerateSalt();
            string passwordPaper = new(salt.Reverse().ToArray());
            string passwordHash = PasswordHasher.ComputeHash(password, salt, passwordPaper, hashInteration);

            return new Password()
            {
                Hash = passwordHash,
                Salt = salt,
            };
        }
    }
}
