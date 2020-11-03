using System.ComponentModel.DataAnnotations;

namespace Catstagram.Server.Controllers.Cats
{
    public class CatsListingResponseModel
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
