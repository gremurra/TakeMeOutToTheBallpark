﻿using Ballpark.Data;
using Ballpark.Models.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Services
{
    public class EventService
    {

        public EventService()
        {
        }

        public bool CreateEvent(EventCreate model)     //creates the instance of Event
        {
            var entity =
                new Event()
                {
                    DateOfGame = model.DateOfGame,
                    ProfileID = model.ProfileID,
                    HomeID = model.HomeTeamID,
                    AwayID = model.AwayTeamID,
                    Result = model.Result,
                    Comments = model.Comments
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Events
                    .Select(
                        e =>
                        new EventListItem
                        {
                            DateOfGame = e.DateOfGame,
                            EventID = e.EventID,
                            VenueName = e.HomeTeam.Venue.VenueName,
                            HomeTeam = e.HomeTeam.TeamName,
                            AwayTeam = e.AwayTeam.TeamName,
                            Result = e.Result
                        }
                        );

                var eventList = query.ToArray();
                var orderedEventList = eventList.OrderBy(e => e.DateOfGame);
                return orderedEventList;
            }
        }

        public EventDetail GetEventByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventID == id);
                return
                    new EventDetail
                    {
                        EventID = entity.EventID,
                        DateOfGame = entity.DateOfGame,
                        VenueName = entity.HomeTeam.Venue.VenueName,
                        HomeTeam = entity.HomeTeam.TeamName,
                        AwayTeam = entity.AwayTeam.TeamName,
                        Result = entity.Result,
                        Comments = entity.Comments
                    };
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventID == model.EventID);

                entity.DateOfGame = model.DateOfGame;
                entity.HomeID = model.HomeTeamID;
                entity.AwayID = model.AwayTeamID;
                entity.Result = model.Result;
                entity.Comments = model.Comments;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent (int eventID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Events
                    .Single(e => e.EventID == eventID);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
