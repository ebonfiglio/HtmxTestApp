using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HtmxTestApp.Shared.Entities
{
    public class Team
    {
        [Key]
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual IEnumerable<Player>? Players { get; set; }

        public virtual ICollection<Game>? WinningGames { get; set; }
        public virtual ICollection<Game>? LosingGames { get; set; }
    }
}
