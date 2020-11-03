using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
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
    }
}
