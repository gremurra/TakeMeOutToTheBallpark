﻿using Ballpark.Data;
using Ballpark.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(ProfileCreate model)
        {
            var entity =
                new Profile()
                {
                    OwnerID = _userId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    FavTeam = model.FavTeam,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Profiles.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProfileListItem> GetProfiles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Profiles
                    .Where(e => e.OwnerID == _userId)
                    .Select(
                        e =>
                        new ProfileListItem
                        {
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            FavTeam = e.FavTeam,
                            CreatedUtc = e.CreatedUtc
                        }
                        );

                return query.ToArray();
            }
        }

        public ProfileDetail GetProfileByID (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Profiles
                    .Single(e => e.ProfileID == id && e.OwnerID == _userId);
                return
                    new ProfileDetail
                    {
                        ProfileID = entity.ProfileID,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        FavTeam = entity.FavTeam,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
    }
}
