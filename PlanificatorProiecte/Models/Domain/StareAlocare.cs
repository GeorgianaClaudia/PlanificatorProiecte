using System.ComponentModel.DataAnnotations;

namespace PlanificatorProiecte.Models.Domain
{
    public class StareAlocare
    {
        public int Id { get; set; }
        [Required]
        public string NumeStareAlocare { get; set; }


    }
}
