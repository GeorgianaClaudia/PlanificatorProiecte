using PlanificatorProiecte.Models.Domain;

namespace PlanificatorProiecte.Repositories.Abstract
{
    public interface IAngajatService
    {
        bool Add(Angajat model);
        bool Update(Angajat model);
        bool Delete(int id);

        Angajat FindById(int id);
        IEnumerable<Angajat> GetAll();


    }
}
