using Catstagram.Server.Controllers.Search.Models;
using Catstagram.Server.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Search
{
    public class SearchService : ISearchService
    {
        private readonly CatstagramDbContext context;

        public SearchService(CatstagramDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
         => await this.context
            .Users
            .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
            u.Profile.Name.ToLower().Contains(query.ToLower()))
            .Select(u => new ProfileSearchServiceModel
            {
                UserId = u.Id,
                Username = u.UserName,
                ProfilePhotoUrl = u.Profile.ProfilePhotoUrl
            })
            .ToListAsync();
    }
}
