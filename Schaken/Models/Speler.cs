using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Schaken.Models;

namespace Schaken.Models
{
    public enum Dagen { Vrijdag, Zaterdag, Zondag };
    public class Speler
    {
        public int Id { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Naam moet minimaal 2 karakters bevatten")]
        public string Naam { get; set; }
        public ICollection<Partij> Partijen { get; set; }
    }
}
