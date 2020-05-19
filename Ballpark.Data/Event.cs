using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Data
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        [Required]
        public int ProfileID { get; set; }
        [Required]
        public DateTimeOffset DateOfGame { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public int TeamID { get; set; }
        [Required]
        public string TeamName { get; set; }
        [Required]
        public string AwayTeam { get; set; }
        [Required]
        public string Result { get; set; }
        public string Comments { get; set; }
        [ForeignKey(nameof(ProfileID))]
        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(TeamID))]
        public virtual Team Team { get; set; }
    }
}
