using Ballpark.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Models.Team
{
    public class TeamDetail
    {
        [Display(Name = "Team ID Number")]
        public int TeamID { get; set; }

        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        public string Location { get; set; }

        [Display(Name = "Home Stadium")]
        public int VenueID { get; set; }

    }
}
