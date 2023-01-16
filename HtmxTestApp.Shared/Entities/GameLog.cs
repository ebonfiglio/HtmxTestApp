using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Shared.Entities
{
    public class GameLog
    {
        public Guid Id { get; set; }

        [ForeignKey("Game")]
        public Guid GameId { get; set; }

        public virtual Game Game { get; set; }

        [ForeignKey("Player")]
        public Guid PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int Points { get; set; }

        public int Assists { get; set; }

        public int Rebounds { get; set; }
    }
}
