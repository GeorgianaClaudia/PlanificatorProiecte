using System.ComponentModel.DataAnnotations;

namespace PlanificatorProiecte.Models.Domain
{
    public class Angajat
    {
        public int Id { get; set; }
        [Required]

        public string NumeAngajat { get; set; }

    }
}
