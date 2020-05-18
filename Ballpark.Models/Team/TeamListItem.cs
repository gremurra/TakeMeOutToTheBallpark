using Ballpark.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballpark.Models.Team
{
    public class TeamListItem
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public Sport Sport { get; set; }
    }
}
