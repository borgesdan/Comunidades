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

        [StringLength(FullNameLength)]
        [Required(AllowEmptyStrings = false)]
        public string FullName { get; set; } = null!;

        [StringLength(UserNameLength)]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; } = null!;

        [StringLength(EmailLength)]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; } = null!;

        [Required]
        public DateTime CreationDate { get; set; }        

        [Required]
        public DateTime LastModification { get; set; }

        [Required]
        public DataStatus Status { get; set; }

        [StringLength(PasswordHashLength)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordHash { get; set; } = null!;

        [StringLength(PasswordSaltLength)]
        [Required(AllowEmptyStrings = false)]
        public string PasswordSalt { get; set; } = null!;

        public ICollection<CommunityEntity> Communities { get; set; } = [];

        /// <summary>
        /// O tamanho máximo para um nome. O valor representa o número de caracteres do nome de D. Pedro I.
        /// </summary>
        public const int FullNameLength = 146;
        /// <summary>O tamanho máximo para um apelido.</summary>
        public const int UserNameLength = 12;
        /// <summary>O tamanho máximo para um email.</summary>
        public const int EmailLength = 256;
        /// <summary>O tamanho máximo da senha no formato hash.</summary>
        public const int PasswordHashLength = 44;
        /// <summary>O tamanho máximo da senha fornecida pelo usuário.</summary>
        public const int PasswordToUserMaxLength = 16;
        /// <summary>O tamanho minímo da senha fornecida pelo usuário.</summary>
        public const int PasswordToUserMinLength = 8;
        /// <summary>O tamanho máximo do valor Salt para senha.</summary>
        public const int PasswordSaltLength = 24;
    }
}
