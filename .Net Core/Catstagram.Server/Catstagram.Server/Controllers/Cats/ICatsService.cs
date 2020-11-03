using Catstagram.Server.Controllers.Cats.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public interface ICatsService
    {
        public Task<bool> Delete(int id, string userId);
        public Task<bool> Update(int id, string description, string userId);
        public Task<CatDetailsServiceModel> Details(int id);
        public Task<IEnumerable<CatsListingServiceModel>> ByUser(string userId);
        public Task<int> Create(string imageUrl, string description, string userId);
    }
}
