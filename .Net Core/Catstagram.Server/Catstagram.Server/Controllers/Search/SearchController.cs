using Catstagram.Server.Controllers.Search.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Search
{
    public class SearchController : ApiController
    {
        private readonly ISearchService search;

        public SearchController(ISearchService search)
            => this.search = search;

        [HttpGet]
        [AllowAnonymous]
        [Route(nameof(Profiles))]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
         => await this.search.Profiles(query);
    }
}
