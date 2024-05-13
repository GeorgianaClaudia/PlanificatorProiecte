using PlanificatorProiecte.Models.Domain;

namespace PlanificatorProiecte.Repositories.Abstract
{
    public interface IStareAlocareService
    {
        bool Add(StareAlocare model);
        bool Update(StareAlocare model);
        bool Delete(int id);

        StareAlocare FindById(int id);
        IEnumerable<StareAlocare> GetAll();
    }
}
