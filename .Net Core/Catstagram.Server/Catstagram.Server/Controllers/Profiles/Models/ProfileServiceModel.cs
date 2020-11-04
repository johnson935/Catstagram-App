using Catstagram.Server.Data.Models;

namespace Catstagram.Server.Controllers.Profiles.Models
{
    public class ProfileServiceModel
    {
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public bool IsPrivate { get; set; }
    }
}
