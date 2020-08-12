using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string email { get; set; }
    }
}
