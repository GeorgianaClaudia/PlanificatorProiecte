using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlanificatorProiecte.Models.Domain
{
    public class Alocare
    {
        public int Id { get; set; }
        [Required]

        public string Nume { get; set; }
        [Required]
        public int ProiectId { get; set; }
        [Required]
        public int StareAlocareId { get; set; }
        [Required]
        public int AngajatID { get; set; }
        [Required]
        public DateTime Termen { get; set; }

        [NotMapped]
        public string? NumeProiect { get; set; }
        [NotMapped]
        public string? NumeAngajat{get; set;}
        [NotMapped]
        public string? NumeStareAlocare { get; set; }
        [NotMapped]
        public List<SelectListItem>? AngajatList { get; set; }
        [NotMapped]
        public List<SelectListItem>? StareAlocareList { get; set; }
        [NotMapped]
        public List<SelectListItem>? ProiectList { get; set; }

    }
}
