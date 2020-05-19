using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Data
{
    public enum Sport { Baseball = 1, Basketball, Football, Hockey}
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public Sport Sport { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int VenueID { get; set; }
        public string VenueName { get; set; }
        [ForeignKey(nameof(VenueID))]
        public virtual Venue Venue { get; set; }
    }
}
