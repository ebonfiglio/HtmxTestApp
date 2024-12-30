using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual Country? Country { get; set; }
        [JsonIgnore]
        public virtual IEnumerable<Player>? Players { get; set; }
        [JsonIgnore]
        public virtual ICollection<Game>? HomeGames { get; set; }
        [JsonIgnore]
        public virtual ICollection<Game>? AwayGames { get; set; }
    }
}
