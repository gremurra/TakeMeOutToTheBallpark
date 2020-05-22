using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Data
{
    public class Profile
    {
        [Key]
        public int ProfileID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FavTeam { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }

        //public int TotalGames { get { return Events.Count; } }      //still at zero, even after adding an event

        ////public virtual List<Event> Events
        //{
        //    get
        //    {
        //        using (var cxt = new ApplicationDbContext())
        //        {
        //            var list =
        //                cxt.Events
        //                .Where(e => e.ProfileID == ProfileID)
        //                .Select(e =>
        //                new Event
        //                {
        //                    EventID = e.EventID,
        //                    VenueName = e.VenueName

        //                });
        //            return list.ToList();
        //        }
        //    }    //adding to new List of Events???
    }
}

