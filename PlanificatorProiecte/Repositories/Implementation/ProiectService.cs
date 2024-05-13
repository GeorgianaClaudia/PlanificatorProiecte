using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Repositories.Implementation
{
    public class ProiectService : IProiectService
    {
        private readonly DatabaseContext context;
        public ProiectService(DatabaseContext context) 
        {
            this.context= context;
        }
        public bool Add(Proiect model)
        {
            try
            {
                context.Proiecte.Add(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { 
                return false;
            }
        }
    

        public bool Delete(int id)
        {
            try
            {
                var data = this.FindById(id);
                if (data == null)
                    return false;

                context.Proiecte.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Proiect FindById(int id)
        {
            return context.Proiecte.Find(id);
        }

        //metoda GetAll returneaza o colectie IEnumerable a tuturor proiectelor din context.proiecte
        //ToList le va aduce pe toate odata
        public IEnumerable<Proiect> GetAll()
        {
            return context.Proiecte.ToList();
        }

        public bool Update(Proiect model)
        {
            try
            {
                context.Proiecte.Update(model);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
