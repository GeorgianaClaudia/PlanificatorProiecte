using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Repositories.Implementation
{
    public class AngajatService : IAngajatService
    {
        private readonly DatabaseContext context;
        public AngajatService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Angajat model)
        {
            try
            {
                context.Angajati.Add(model);
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

                context.Angajati.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Angajat FindById(int id)
        {
            return context.Angajati.Find(id);
        }

        //metoda GetAll returneaza o colectie IEnumerable a tuturor angajatilor din context.proiecte
        //ToList le va aduce pe toate odata
        public IEnumerable<Angajat> GetAll()

        {

            return context.Angajati.ToList();
        }

        public bool Update(Angajat model)
        {
            try
            {
                context.Angajati.Update(model);
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
