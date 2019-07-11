using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProDB.Models
{
    public class Protagonist
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Vorname")]
        public string firstName { get; set; }
        [Display(Name = "Nachname")]
        public string lastName { get; set; }
        [Display(Name = "Letzte Buchung")]
        public DateTime lastBooking { get; set; }
    }
}
