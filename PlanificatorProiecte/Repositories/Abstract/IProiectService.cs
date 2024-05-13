using PlanificatorProiecte.Models.Domain;

namespace PlanificatorProiecte.Repositories.Abstract
{
    public interface IProiectService
    {
        bool Add(Proiect model);
        bool Update(Proiect model);
        bool Delete(int id);

        Proiect FindById(int id);
        IEnumerable<Proiect> GetAll();


    }
}
