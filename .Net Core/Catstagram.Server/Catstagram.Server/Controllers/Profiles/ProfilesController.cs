﻿using Catstagram.Server.Controllers.Identity.Models;
using Catstagram.Server.Controllers.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    public class ProfilesController: ApiController
    {
        private readonly IProfileService profiles;
        private readonly ICurrentUserService currentUser;

        public ProfilesController(IProfileService profiles,
            ICurrentUserService currentUser)
        {
            this.profiles = profiles;
            this.currentUser = currentUser;
        }
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ProfileServiceModel>> Mine()
        => await this.profiles.ByUser(this.currentUser.GetId());
    
        [HttpPut]
        [Authorize]
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
