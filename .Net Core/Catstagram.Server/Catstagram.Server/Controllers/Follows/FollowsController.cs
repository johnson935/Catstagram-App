using Catstagram.Server.Controllers.Follows.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Follows
{
    [Authorize]
    public class FollowsController : ApiController
    {
        private readonly IFollowService follows;
        private readonly ICurrentUserService currentUser;

        public FollowsController(
            ICurrentUserService currentUser,
            IFollowService follows)
        {
            this.currentUser = currentUser;
            this.follows = follows;
        }
        [HttpPost]
        public async Task<ActionResult> Follow(FollowRequestModel model)
        {
            var result = await this.follows
                .Follow(
                model.UserId,
                this.currentUser.GetId());

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
