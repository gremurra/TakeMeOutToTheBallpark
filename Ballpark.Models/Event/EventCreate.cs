using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Models.Event
{
    public class EventCreate
    {
        [Display(Name = "Profile ID Number")]
        public int ProfileID { get; set; }

        [Required]
        [Display(Name = "Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTimeOffset DateOfGame { get; set; }

        [Required]
        [Display(Name = "Venue Name")]
        public string VenueName { get; set; }

        [Required]
        [Display(Name = "Home Team ID Number")]
        public int TeamID { get; set; }

        [Required]
        [Display(Name = "Home Team")]
        public string TeamName { get; set; }

        [Required]
        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }

        [Required]
        public string Result { get; set; }

        [Required]
        public string Comments { get; set; }
    }
}
