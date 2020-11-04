
using Catstagram.Server.Infrastructure.Services;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Follows
{
    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);
    }
}
