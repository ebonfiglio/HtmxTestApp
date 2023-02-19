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

        [ForeignKey("HomeTeam")]
        public Guid HomeTeamId { get; set; }

        public virtual Team HomeTeam { get; set; }

        public int HomeTeamScore { get; set; }

        [ForeignKey("AwayTeam")]
        public Guid AwayTeamId { get; set; }

        public virtual Team AwayTeam { get; set; }

        public int AwayTeamScore { get; set; }

        public virtual IEnumerable<GameLog> GameLogs { get; set; }

        public bool IsFinished { get; set; }
    }
}
