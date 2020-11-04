
using Catstagram.Server.Controllers.Profiles.Models;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Catstagram.Server.Controllers.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext context;

        public ProfileService(CatstagramDbContext context)
        {
            this.context = context;
        }
        public async Task<ProfileServiceModel> ByUser(string userId, bool allInformation = false)
        =>  await this.context
            .Users
            .Where(u => u.Id == userId)
            .Select(u =>  allInformation
                ? new PublicProfileServiceModel
                {
                    Name = u.Profile.Name,
                    Biography = u.Profile.Biography,
                    Gender = u.Profile.Gender.ToString(),
                    ProfilePhotoUrl = u.Profile.ProfilePhotoUrl,
                    WebSite = u.Profile.WebSite,
                    IsPrivate = u.Profile.IsPrivate
                }
                : new ProfileServiceModel
                {
                    Name = u.Profile.Name,
                    ProfilePhotoUrl = u.Profile.ProfilePhotoUrl,
                    IsPrivate = u.Profile.IsPrivate
                })
            .FirstOrDefaultAsync();
        
        public async Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string name, 
            string profilePhotoUrl, 
            string webSite, 
            string biography, 
            Gender gender, 
            bool isPrivate)
        {
            var user = await this.context
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(p => p.Id == userId);

            if (user == null)
            {
                return "User does not exist";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }
            var result = await this.ChangeProfileEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            var usernameResult = await this.ChangeProfileUserName(user, userId, email);
            if (usernameResult.Failure)
            {
                return result;
            }

            this.ChangeProfile(
                user.Profile,
                name,
                profilePhotoUrl,
                webSite,
                biography,
                gender,
                isPrivate
                );

            await this.context.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChangeProfileEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var existingEmail = await this.context
                    .Users
                    .AnyAsync(u => u.Id != userId && u.Email == email);

                if (existingEmail)
                {
                    return "The provided email is already taken";
                }
                user.Email = email;
            }

            return true;
        }

        private async Task<Result> ChangeProfileUserName(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExist = await this.context
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);

                if (userNameExist)
                {
                    return "The provided user name is already taken";
                }
                user.UserName = userName;
            }

            return true;
        }

        private void ChangeProfile(
            Profile profile,
            string name,
            string profilePhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate
            )
        {
            if (profile.Name != name)
            {
                profile.Name = name;
            }

            if (profile.ProfilePhotoUrl != profilePhotoUrl)
            {
                profile.ProfilePhotoUrl = profilePhotoUrl;
            }

            if (profile.WebSite != webSite)
            {
                profile.WebSite = webSite;
            }

            if (profile.Biography != biography)
            {
                profile.Biography = biography;
            }

            if (profile.Gender != gender)
            {
                profile.Gender = gender;
            }

            if (profile.IsPrivate != isPrivate)
            {
                profile.IsPrivate = isPrivate;
            }
        }

        public async Task<bool> IsPrivate(string userId)
        => await this.context.Profiles
            .Where(p => p.UserId == userId)
            .Select(p => p.IsPrivate)
            .FirstOrDefaultAsync();
    }
}
