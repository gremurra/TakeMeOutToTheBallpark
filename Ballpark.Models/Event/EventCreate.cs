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
        [Required]
        public DateTimeOffset DateOfGame { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public int TeamName { get; set; }
        [Required]
        public string AwayTeam { get; set; }
        [Required]
        public string Result { get; set; }
        [Required]
        public string Comments { get; set; }
    }
}
