using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmxTestApp.Shared.Entities
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string ShortName { get; set; }

        public int Number { get; set; }
    }
}
