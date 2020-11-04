
using Catstagram.Server.Controllers.Profiles.Models;
using Catstagram.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext context;

        public ProfileService(CatstagramDbContext context)
        {
            this.context = context;
        }
        public async Task<ProfileServiceModel> ByUser(string userId)
        => await this.context
            .Users
            .Where(u => u.Id == userId)
            .Select(u => new ProfileServiceModel
            {
                Name = u.Profile.Name,
                Biography = u.Profile.Biography,
                Gender = u.Profile.Gender.ToString(),
                ProfilePhotoUrl = u.Profile.ProfilePhotoUrl,
                WebSite = u.Profile.WebSite,
                IsPrivate = u.Profile.IsPrivate
            })
            .FirstOrDefaultAsync();
    }
}
