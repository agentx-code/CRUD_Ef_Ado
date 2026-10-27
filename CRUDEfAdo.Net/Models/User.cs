using System.ComponentModel.DataAnnotations;

namespace CRUDEfAdo.Net.Models
{
    public class User
    {
        [Key]
        [Required]
        public int  Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Images { get; set; }
    }
}
