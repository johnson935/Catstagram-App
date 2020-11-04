
using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Controllers.Identity.Models
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
