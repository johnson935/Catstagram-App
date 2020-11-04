using Catstagram.Server.Controllers.Cats.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public interface ICatsService
    {
         Task<bool> Delete(int id, string userId);
         Task<bool> Update(int id, string description, string userId);
         Task<CatDetailsServiceModel> Details(int id);
         Task<IEnumerable<CatsListingServiceModel>> ByUser(string userId);
         Task<int> Create(string imageUrl, string description, string userId);
    }
}
