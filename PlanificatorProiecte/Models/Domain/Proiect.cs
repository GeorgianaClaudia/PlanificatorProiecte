using System.ComponentModel.DataAnnotations;

namespace PlanificatorProiecte.Models.Domain
{
    public class Proiect
    {
        public int Id { get; set; }
        [Required]
        public string NumeProiect { get; set; }
        public string Descriere { get; set; }

    }
}
