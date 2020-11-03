using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Controllers.Cats.Model
{
    public class CatDetailsServiceModel : CatsListingServiceModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }
        public string username { get; set; }
    }
}
