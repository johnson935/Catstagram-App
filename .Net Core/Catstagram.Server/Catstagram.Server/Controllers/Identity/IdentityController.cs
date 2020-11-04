using Catstagram.Server.Controllers.Identity.Models;
using Catstagram.Server.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Identity
{
    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;
        private readonly IIdentityService identityService;

        public IdentityController(
            UserManager<User> userManager,
            IIdentityService identityService,
            IOptions<AppSettings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
            this.identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserRequestModel model)
        {
            var user = new User
            {
                Email = model.Email,
                UserName = model.Username,
            };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<object>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                return this.Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return this.Unauthorized();
            }

            var encryptedToken = this.identityService.GenerateJwtToken(user.Id, user.UserName, this.appSettings.Secret);

            return new LoginResponseModel
            {
                Token = encryptedToken
            };
         }
    }
}
