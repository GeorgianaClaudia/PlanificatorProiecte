using PlanificatorProiecte.Models.Domain;

namespace PlanificatorProiecte.Repositories.Abstract
{
    public interface IAlocareService
    {
        bool Add(Alocare model);
        bool Update(Alocare model);
        bool Delete(int id);

        Alocare FindById(int id);
        IEnumerable<Alocare> GetAll(string searchTermAngajat, string searchTermProiect);
        


    }
}
