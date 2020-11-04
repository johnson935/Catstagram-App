using Catstagram.Server.Controllers.Cats.Model;
using Catstagram.Server.Controllers.Cats.Models;
using Catstagram.Server.Infrastructure;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    using static Infrastructure.WebConstants;
    
    [Authorize]
    public class CatsController : ApiController
    {
        private readonly ICatsService catsService;
        private readonly ICurrentUserService currentUser;
        public CatsController(
            ICatsService catsService,
            ICurrentUserService currentUser)
        {
            this.catsService = catsService;
            this.currentUser = currentUser;
        }
  
        [HttpGet]
        public async Task<IEnumerable<CatsListingServiceModel>> Mine()
        {
            var userId = this.currentUser.GetId();
            return await this.catsService.ByUser(userId);
        }

        [HttpGet]
        [Route(RouteId)]
        public async Task<ActionResult<CatDetailsServiceModel>> Details(int id)
        =>
            await this.catsService.Details(id);

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.currentUser.GetId();
            var id = await this.catsService.Create(model.ImageUrl, model.Description, userId);
            return Created(nameof(this.Create), id);
        }

        [HttpPut]
        public async Task<ActionResult> Update(UpdateCatRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.catsService.Update(model.Id, model.Description, userId);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        [Route(RouteId)]
        public async Task<ActionResult> Delete(int id)
        {
            var userId = this.currentUser.GetId();

            var deleted = await this.catsService.Delete(id, userId);

            if (!deleted)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
