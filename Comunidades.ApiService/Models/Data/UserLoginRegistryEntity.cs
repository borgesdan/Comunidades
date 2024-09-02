using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comunidades.ApiService.Models.Data
{
    [Table("UserLogin")]
    public class UserLoginRegistryEntity : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public DateTime LoginDate { get; set; }       

        public UserEntity? User { get; set; }
    }
}
