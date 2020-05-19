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

        public bool CreateEvent(EventCreate model)     //creates the instance of Note
        {
            var entity =
                new Event()
                {
                    DateOfGame = model.DateOfGame,
                    VenueName = model.VenueName,
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

                return query.ToArray();
            }
        }
    }
}
