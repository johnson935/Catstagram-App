
using Catstagram.Server.Controllers.Cats.Model;
using Catstagram.Server.Controllers.Profiles.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string userId);
    }
}
