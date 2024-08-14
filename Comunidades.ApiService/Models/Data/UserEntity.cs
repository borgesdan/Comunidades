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
        public const int NameLength = 256;
        public const int UserNameLength = 12;
        public const int EmailLength = 256;
        public const int PasswordLength = 16;

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

        [StringLength(PasswordLength)]
        [Required(AllowEmptyStrings = false)]
        public string? Password { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DataStatus Status { get; set; }

        [Required]
        public DateTime LastModification { get; set; }
    }
}
