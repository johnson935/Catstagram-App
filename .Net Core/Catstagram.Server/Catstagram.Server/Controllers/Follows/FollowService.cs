using Catstagram.Server.Data;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Follows
{
    public class FollowService : IFollowService
    {
        private readonly CatstagramDbContext context;

        public FollowService(CatstagramDbContext context)
            => this.context = context;
        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed = await this.context
                .Follows
                .AnyAsync(f => f.UserId == userId && f.FollowerId == followerId);
            if (userAlreadyFollowed)
            {
                return "User already followed";
            }

            var publicProfile = await this.context
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(p => !p.IsPrivate)
                .FirstOrDefaultAsync();

            this.context.Follows.Add(new Data.Models.Follow
            {
                UserId = userId,
                FollowerId = followerId,
                IsApproved = publicProfile,

            });

            await this.context.SaveChangesAsync();

            return true;
        }
    }
}
