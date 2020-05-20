﻿using Ballpark.Data;
using Ballpark.Models.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Services
{
    public class TeamService
    {
        public TeamService()
        {

        }

        public bool CreateTeam(TeamCreate model)        //creates instance of Team
        {
            var entity =
                new Team()
                {
                    TeamName = model.TeamName,
                    VenueName = model.VenueName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams() //see all Teams 
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Teams
                    .Select(
                        e =>
                        new TeamListItem
                        {
                            TeamID = e.TeamID,
                            TeamName = e.TeamName,
                            VenueName = e.VenueName
                        }
                        );

                return query.ToArray();
            }
        }

        public TeamDetail GetTeamByID (int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamID == id);
                return
                    new TeamDetail
                    {
                        TeamID = entity.TeamID,
                        TeamName = entity.TeamName,
                        VenueID = entity.VenueID,
                    };
            }
        }

        public bool UpdateTeam(TeamEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamID == model.TeamID);

                entity.TeamName = model.TeamName;
                entity.VenueID = model.VenueID;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTeam(int teamID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamID == teamID);

                ctx.Teams.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
