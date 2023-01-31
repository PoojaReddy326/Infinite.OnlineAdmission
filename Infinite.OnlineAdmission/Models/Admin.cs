using System.ComponentModel.DataAnnotations;

namespace Infinite.OnlineAdmission.Models
{
    public class Admin:Login
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

