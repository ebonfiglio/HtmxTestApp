using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HtmxTestApp.Shared.Entities
{
    public class Game
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("WinningTeam")]
        public Guid WinningTeamId { get; set; }

        public virtual Team WinningTeam { get; set; }

        public int WinningTeamScore { get; set; }

        [ForeignKey("LosingTeam")]
        public Guid LosingTeamId { get; set; }

        public virtual Team LosingTeam { get; set; }

        public int LosingTeamScore { get; set; }

        public virtual IEnumerable<GameLog> GameLogs { get; set; }
    }
}
