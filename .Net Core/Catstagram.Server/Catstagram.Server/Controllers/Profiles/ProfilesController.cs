using Catstagram.Server.Controllers.Follows;
using Catstagram.Server.Controllers.Identity.Models;
using Catstagram.Server.Controllers.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    using static Infrastructure.WebConstants;
    [Authorize]
    public class ProfilesController: ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;
        private readonly IFollowService follows;
        public ProfilesController(IProfileService profiles,
            ICurrentUserService currentUser,
            IFollowService follows)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
            this.follows = follows;
        }
        [HttpGet]
        public async Task<ProfileServiceModel> Mine()
        => await this.profiles.ByUser(this.currentUser.GetId(), allInformation: true);

        [AllowAnonymous]
        [HttpGet]
        [Route(RouteId)]
        public async Task<ProfileServiceModel> Details(string id)
        {
            var includeAllInformation = await this.follows.IsFollower(id, this.currentUser.GetId());

            if (!includeAllInformation)
            {
               includeAllInformation = !await this.profiles.IsPrivate(id);
            }
            return await this.profiles.ByUser(id, includeAllInformation);
        }
        [HttpPut]
        public async Task<ActionResult> Update(UpdateProfileRequestModel model)
        {
            var userId = this.currentUser.GetId();

            var result = await this.profiles.Update(
                userId,
                model.Email,
                model.UserName,
                model.Name,
                model.ProfilePhotoUrl,
                model.WebSite,
                model.Biography,
                model.Gender,
                model.IsPrivate);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
