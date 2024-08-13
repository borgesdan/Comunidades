using System.ComponentModel.DataAnnotations;

namespace Comunidades.ApiService.Models.Data
{
    /// <summary>
    /// Entidade base com implementações padrão.
    /// </summary>
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
