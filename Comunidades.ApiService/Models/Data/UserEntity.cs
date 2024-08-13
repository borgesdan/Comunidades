using Comunidades.ApiService.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Comunidades.ApiService.Models.Data
{
    /// <summary>
    /// Representa a tabela de dados do usuário.
    /// </summary>    
    public class UserEntity : BaseEntity
    {
        public const int NameLength = 256;

        [StringLength(NameLength)]
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }

        [Required]
        public Guid Uid { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        [Required]
        public DataStatus Status { get; set; }
    }
}
