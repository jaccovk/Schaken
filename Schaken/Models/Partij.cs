using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Schaken.Models;

namespace Schaken.Models
{
    public enum Uitslag { Verloren, Remise, Gewonnen }
    public class Partij
    {
        public int Id { get; set; }
        public Dagen Dag { get; set; }
        public Uitslag Uitslag { get; set; }

        [ForeignKey("Speler")]
        public int SpelerId { get; set; }
        public Speler Speler { get; set; }
    }
}
