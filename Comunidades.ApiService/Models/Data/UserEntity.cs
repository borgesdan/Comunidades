using Comunidades.ApiService.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunidades.ApiService.Models.Data
{
    /// <summary>
    /// Representa a tabela de dados do usuário.
    /// </summary>    
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        [Required]
        public Guid Uid { get; set; }

        [StringLength(NameLength)]
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [StringLength(UserNameLength)]
        [Required(AllowEmptyStrings = false)]
        public string? UserName { get; set; }

        [StringLength(EmailLength)]
        [Required(AllowEmptyStrings = false)]
        public string? Email { get; set; }        

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DataStatus Status { get; set; }

        [Required]
        public DateTime LastModification { get; set; }

        [StringLength(PasswordHashLength)]
        [Required(AllowEmptyStrings = false)]
        public string? PasswordHash { get; set; }

        [StringLength(PasswordSaltLength)]
        [Required(AllowEmptyStrings = false)]
        public string? PasswordSalt { get; set; }

        public const int NameLength = 256;
        public const int UserNameLength = 12;
        public const int EmailLength = 256;
        public const int PasswordHashLength = 44;
        public const int PasswordToUserLength = 16;
        public const int PasswordSaltLength = 24;
    }
}
