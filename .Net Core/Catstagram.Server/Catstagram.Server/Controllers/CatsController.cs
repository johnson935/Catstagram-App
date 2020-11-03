using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Data.Models.Cats;
using Catstagram.Server.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers
{

    public class CatsController : ApiController
    {
        private readonly CatstagramDbContext dbContext;

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCatRequestModel model)
        {
            var userId = this.User.GetId();
            var cat = new Cat
            {
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                UserId = userId
            };

            this.dbContext.Add(cat);

            await this.dbContext.SaveChangesAsync();

            return Created(nameof(this.Create), cat.Id);
        }
    }
}
