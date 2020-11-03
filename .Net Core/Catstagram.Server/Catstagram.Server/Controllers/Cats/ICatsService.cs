using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public interface ICatsService
    {
        public Task<IEnumerable<CatsListingResponseModel>> ByUser(string userId);
        public Task<int> Create(string imageUrl, string description, string userId);
    }
}
