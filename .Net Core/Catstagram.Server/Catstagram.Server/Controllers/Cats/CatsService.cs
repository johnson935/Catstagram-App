using Catstagram.Server.Controllers.Cats.Model;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public class CatsService : ICatsService
    {
        private readonly CatstagramDbContext context;

        public CatsService(CatstagramDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(string imageUrl, string description, string userId)
        {
            var cat = new Cat
            {
                Description = description,
                ImageUrl = imageUrl,
                UserId = userId
            };

            this.context.Add(cat);

            await this.context.SaveChangesAsync();

            return cat.Id;
        }

        public async Task<IEnumerable<CatsListingServiceModel>> ByUser(string userId)
        => await this.context
                    .Cats
                    .Where(c => c.UserId == userId)
            .Select(c => new CatsListingServiceModel
            {
                Id = c.Id,
                ImageUrl = c.ImageUrl
            }).ToListAsync();

        public async Task<CatDetailsServiceModel> Details(int id)
            => await this.context
                .Cats
                .Where(c => c.Id == id)
                .Select(c => new CatDetailsServiceModel
                {
                    Id = c.Id,
                    UserId = c.UserId,
                    ImageUrl = c.ImageUrl,
                    Description = c.Description,
                    username = c.User.UserName
                })
                .FirstOrDefaultAsync();
        public async Task<bool> Update(int id, string desciption, string userId)
        {
            var cat = await this.context
                .Cats
                .Where(c => c.Id == id && c.UserId == userId)
                .FirstOrDefaultAsync();

            if (cat == null)
            {
                return false;
            }

            cat.Description = desciption;

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
