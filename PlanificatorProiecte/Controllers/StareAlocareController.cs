using Microsoft.AspNetCore.Mvc;
using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Controllers
{
    public class StareAlocareController : Controller
    {
        private readonly IStareAlocareService stareAlocareService;
        public StareAlocareController(IStareAlocareService stareAlocareService)
        {
            this.stareAlocareService = stareAlocareService;
        }
        //Metoda Add care returneaza un view cu acelasi nume
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(StareAlocare model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = stareAlocareService.Add(model);
            if (result)
            {
                TempData["msg"] = "Adaugat cu succes!";
                return RedirectToAction(nameof(Add));
            }
            TempData["msg"] = "Eroare";
            return View(model);
        }


        public IActionResult Update(int id)
        {
            //gasim inregistrarea care se modifica
            var record = stareAlocareService.FindById(id);
            return View(record);//view primeste inregistrarea care se modifica
        }
        [HttpPost]
        public IActionResult Update(StareAlocare model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = stareAlocareService.Update(model);
            if (result)
            {
                TempData["msg"] = "Modificat cu succes!";
                return RedirectToAction(nameof(GetAll));
            }
            TempData["msg"] = "Eroare";
            return View(model);
        }


        public IActionResult Delete(int id)
        {
            {
                var result = stareAlocareService.Delete(id);

                return RedirectToAction("GetAll");//dupa stergere intotdeauna mergem la metoda GetAll

            }
        }


        public IActionResult GetAll()
        {

            var data = stareAlocareService.GetAll();
            return View(data);

        }
    }
}
