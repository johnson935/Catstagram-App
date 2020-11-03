using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Controllers.Cats.Model
{
    public class CatsListingServiceModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
