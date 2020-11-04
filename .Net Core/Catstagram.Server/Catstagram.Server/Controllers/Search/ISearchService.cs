
using Catstagram.Server.Controllers.Search.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Search
{
    public interface ISearchService
    {
        Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query);
    }
}
