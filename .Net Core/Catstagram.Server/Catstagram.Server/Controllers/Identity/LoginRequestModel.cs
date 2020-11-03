using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Controllers.Identity
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
