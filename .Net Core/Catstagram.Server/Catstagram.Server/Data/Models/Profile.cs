using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Data.Models
{
    using static Validation.User;
    public class Profile
    { 
        [Key]
        [Required]
        public string UserId { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }
        public string WebSite { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string Biography { get; set; }
        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
