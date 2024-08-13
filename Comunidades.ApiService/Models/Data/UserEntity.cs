using System.ComponentModel.DataAnnotations;

namespace Comunidades.ApiService.Models.Data
{
    public class UserEntity : BaseEntity
    {
        [StringLength(256)]
        [Required(AllowEmptyStrings = false)]
        public string? Name { get; set; }
    }
}
