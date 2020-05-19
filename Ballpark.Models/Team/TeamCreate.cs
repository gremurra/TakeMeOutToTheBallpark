﻿using Ballpark.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Models.Team
{
    public class TeamCreate
    {
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [Required]
        public Sport Sport { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Venue ID")]
        public int VenueID { get; set; }
        [Display(Name = "Home Venue")]
        public string VenueName { get; set; }
    }
}
