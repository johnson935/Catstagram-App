using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{

    public class CatsController : ApiController
    {
        private readonly ICatsService catsService;

        public CatsController(ICatsService catsService)
        {
            this.catsService = catsService;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();
            var id = await this.catsService.Create(model.ImageUrl, model.Description, userId);
            return Created(nameof(this.Create), id);
        }
    }
}
