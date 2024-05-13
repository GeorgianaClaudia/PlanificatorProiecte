using Microsoft.EntityFrameworkCore;

namespace PlanificatorProiecte.Models.Domain
{
    public class DatabaseContext:DbContext

    {
        public  DatabaseContext(DbContextOptions<DatabaseContext>options):base(options)
        {
            
        }
        public DbSet<Proiect> Proiecte { get; set; }
        public DbSet<Angajat> Angajati { get; set; }
        public DbSet<StareAlocare> StariAlocare { get; set; }
        public DbSet<Alocare> Alocari { get; set; }

    }
}
