using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Data
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Required]
        public int VenueID { get; set; }
        public string VenueName { get; set; }

        [ForeignKey(nameof(VenueID))]
        public virtual Venue Venue { get; set; }
    }
}
