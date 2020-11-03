namespace Catstagram.Server.Controllers.Identity
{
    public interface IIdentityService
    {
        public string GenerateJwtToken(string userId, string userName, string secret);
    }
}
