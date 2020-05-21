using Ballpark.Data;
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
                    ProfileID = model.ProfileID,
                    DateOfGame = model.DateOfGame,
                    VenueName = model.VenueName,
                    TeamID = model.TeamID,
                    TeamName = model.TeamName,
                    AwayTeam = model.AwayTeam,
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
                            EventID = e.EventID,
                            DateOfGame = e.DateOfGame,
                            VenueName = e.VenueName,
                            TeamName = e.TeamName,
                            AwayTeam = e.AwayTeam,
                            Result = e.Result
                        }
                        );

                var eventList = query.ToArray();
                eventList.OrderBy(e => e.DateOfGame);
                return eventList;
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
                        VenueName = entity.VenueName,
                        TeamName = entity.TeamName,
                        AwayTeam = entity.AwayTeam,
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
                entity.VenueName = model.VenueName;
                entity.TeamName = model.TeamName;
                entity.AwayTeam = model.AwayTeam;
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
