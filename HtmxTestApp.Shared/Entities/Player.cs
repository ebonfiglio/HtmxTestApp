using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Shared.Entities
{
    public class Player
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [ForeignKey("Position")]
        public Guid PositionId { get; set; }

        public virtual Position Position { get; set; }

        [ForeignKey("Team")]
        public Guid TeamId { get; set; }

        public virtual Team Team { get; set; }

        [ForeignKey("Country")]
        public Guid CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual IEnumerable<GameLog> GameLogs { get; set; }
    }
}
