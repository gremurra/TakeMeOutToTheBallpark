using Ballpark.Data;
using Ballpark.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Services
{
    public class VenueService
    {
        public VenueService()
        {

        }

        public bool CreateVenue(VenueCreate model)
        {
            var entity =
                new Venue()
                {
                    VenueName = model.VenueName,
                    Location = model.Location,
                    YearOpened = model.YearOpened,
                    Capacity = model.Capacity,
                    IsActive = model.IsActive
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Venues
                    .Select(
                        e =>
                        new VenueListItem
                        {
                            VenueID = e.VenueID,
                            VenueName = e.VenueName,
                            Location = e.Location,
                            YearOpened = e.YearOpened,
                            Capacity = e.Capacity,
                            IsActive = e.IsActive
                        }
                        );

                return query.ToArray();
            }
        }

        public VenueDetail GetVenueByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                    .Venues
                    .Single(e => e.VenueID == id);
                return
                    new VenueDetail
                    {
                        VenueID = entity.VenueID,
                        VenueName = entity.VenueName,
                        Location = entity.Location,
                        YearOpened = entity.YearOpened,
                        Capacity = entity.Capacity,
                        IsActive = entity.IsActive,
                    };
            }
        }

        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Venues
                    .Single(e => e.VenueID == model.VenueID);

                entity.VenueID = model.VenueID;
                entity.VenueName = model.VenueName;
                entity.Location = model.Location;
                entity.YearOpened = model.YearOpened;
                entity.Capacity = model.Capacity;
                entity.IsActive = model.IsActive;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteVenue(int venueID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Venues
                    .Single(e => e.VenueID == venueID);

                ctx.Venues.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
