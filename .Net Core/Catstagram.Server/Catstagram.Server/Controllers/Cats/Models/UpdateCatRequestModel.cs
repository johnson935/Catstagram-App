using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Catstagram.Server.Controllers.Cats.Models
{
    using static Data.Validation.Cat;
    public class UpdateCatRequestModel
    {
        
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}
