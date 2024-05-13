using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Repositories.Implementation
{
    public class StareAlocareService : IStareAlocareService
    {
        private readonly DatabaseContext context;
        public StareAlocareService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(StareAlocare model)
        {
            try
            {
                context.StariAlocare.Add(model);
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

                context.StariAlocare.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public StareAlocare FindById(int id)
        {
            return context.StariAlocare.Find(id);
        }

        //metoda GetAll returneaza o colectie IEnumerable a tuturor starilor alocare din context.StariAlocare
        //ToList le va aduce pe toate odata
        public IEnumerable<StareAlocare> GetAll()
        {
            return context.StariAlocare.ToList();
        }

        public bool Update(StareAlocare model)
        {
            try
            {
                context.StariAlocare.Update(model);
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
