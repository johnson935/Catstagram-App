﻿namespace Catstagram.Server.Controllers.Profiles.Models
{
    using Catstagram.Server.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Catstagram.Server.Data.Validation.User;
    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }
        public string UserName { get; set; }
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }
        public string WebSite { get; set; }

        [MaxLength(MaxBiographyLength)]
        public string Biography { get; set; }
        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }
    }
}
