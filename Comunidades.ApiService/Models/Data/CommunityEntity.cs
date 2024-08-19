using Comunidades.ApiService.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunidades.ApiService.Models.Data
{
    [Table("Community")]
    public class CommunityEntity : BaseEntity
    {
        [Required]
        public int CreatorId { get; set; }

        [Required]
        public Guid Uid { get; set; }

        [StringLength(NameLength)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; } = null!;

        [StringLength(DescriptionLength)]
        [Required(AllowEmptyStrings = false)]
        public string Description { get; set; } = null!;

        [Required]
        public DateTime CreationDate { get; set; }        

        [Required]
        public DateTime LastModification { get; set; }

        [Required]
        public DataStatus Status { get; set; }

        public UserEntity Creator { get; set; } = null!;

        /// <summary>O tamanho máximo para um nome.</summary>
        public const int NameLength = 100;
        /// <summary>O tamanho máximo para descrição do texto, baseado em um Lorem Ipsum de 5 parágrafos e 560 palavras.</summary>
        public const int DescriptionLength = 3750;
    }
}
