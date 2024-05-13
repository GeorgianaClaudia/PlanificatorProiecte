using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Repositories.Implementation
{
    public class AlocareService : IAlocareService
    {
        private readonly DatabaseContext context;
        public AlocareService(DatabaseContext context)
        {
            this.context = context;
        }
        public bool Add(Alocare model)
        {
            try
            {
                context.Alocari.Add(model);
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

                context.Alocari.Remove(data);
                context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Alocare FindById(int id)
        {
            return context.Alocari.Find(id);
        }

        //metoda GetAll returneaza o colectie IEnumerable a tuturor Alocarilor din context.Alocari dupa termeni de cautare
        //ToList le va aduce pe toate odata
        public IEnumerable<Alocare> GetAll(string searchTermAngajat, string searchTermProiect)
        {
            var query = from alocare in context.Alocari
                        join angajat in context.Angajati on alocare.AngajatID equals angajat.Id
                        join stareAlocare in context.StariAlocare on alocare.StareAlocareId equals stareAlocare.Id
                        join proiect in context.Proiecte on alocare.ProiectId equals proiect.Id
                        select new Alocare
                        {
                            Id = alocare.Id,
                            AngajatID = alocare.AngajatID,
                            ProiectId = alocare.ProiectId,
                            StareAlocareId = alocare.StareAlocareId,
                            Termen = alocare.Termen,
                            Nume = alocare.Nume,
                            NumeProiect = proiect.NumeProiect,
                            NumeAngajat = angajat.NumeAngajat,
                            NumeStareAlocare = stareAlocare.NumeStareAlocare
                        };

            if (!string.IsNullOrEmpty(searchTermAngajat))
            {
                query = query.Where(a => a.NumeAngajat.Contains(searchTermAngajat));
            }

            if (!string.IsNullOrEmpty(searchTermProiect))
            {
                query = query.Where(a => a.NumeProiect.Contains(searchTermProiect));
            }

            return query.ToList();
        }

        public bool Update(Alocare model)
        {
            try
            {
                var existingRecord = context.Alocari.Find(model.Id);
                if (existingRecord == null)
                    return false;

                // Update the properties of the existing record with the new values
                existingRecord.AngajatID = model.AngajatID;
                existingRecord.ProiectId = model.ProiectId;
                existingRecord.StareAlocareId = model.StareAlocareId;
                existingRecord.Termen = model.Termen;
                existingRecord.Nume = model.Nume;

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
