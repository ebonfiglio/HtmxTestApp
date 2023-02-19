using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Country")]
        public Guid? CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public virtual IEnumerable<Player>? Players { get; set; }

        public virtual ICollection<Game>? HomeGames { get; set; }
        public virtual ICollection<Game>? AwayGames { get; set; }
    }
}
