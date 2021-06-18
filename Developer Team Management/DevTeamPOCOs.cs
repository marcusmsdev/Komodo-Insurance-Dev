using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Developer_Team_Management
{
    public enum TeamName
    {
        Aspens = 1,
        Charters
    }

    public class TeamContent
    {
        public TeamName NameOfTeam { get; set; }
        public int TeamId { get; set; }

        public TeamContent() { }

        public TeamContent(TeamName nameOfTeam, int teamId)
        {
            NameOfTeam = nameOfTeam;
            TeamId = teamId;

        }
    }
}
