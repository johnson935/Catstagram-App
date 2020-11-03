using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Cats
{
    public interface ICatsService
    {
        public Task<int> Create(string imageUrl, string description, string userId);
    }
}
