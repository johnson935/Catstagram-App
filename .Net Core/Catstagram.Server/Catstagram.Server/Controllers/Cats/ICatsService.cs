using Catstagram.Server.Controllers.Cats.Model;
using Catstagram.Server.Infrastructure.Services;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public interface ICatsService
    {
         Task<Result> Delete(int id, string userId);
         Task<Result> Update(int id, string description, string userId);
         Task<CatDetailsServiceModel> Details(int id);
         Task<IEnumerable<CatsListingServiceModel>> ByUser(string userId);
         Task<int> Create(string imageUrl, string description, string userId);
    }
}
