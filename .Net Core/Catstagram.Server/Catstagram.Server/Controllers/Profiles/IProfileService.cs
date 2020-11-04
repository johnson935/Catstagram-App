
using Catstagram.Server.Controllers.Cats.Model;
using Catstagram.Server.Controllers.Profiles.Models;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);

        Task<Result> Update(
            string userId,
            string email,
            string userName,
            string name,
            string profilePhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate);
    }
}
