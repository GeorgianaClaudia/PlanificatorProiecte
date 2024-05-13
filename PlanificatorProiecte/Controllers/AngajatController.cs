using Microsoft.AspNetCore.Mvc;
using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;

namespace PlanificatorProiecte.Controllers
{
    public class AngajatController : Controller
    {
        private readonly IAngajatService angajatService;
        public AngajatController(IAngajatService angajatService)
        {
            this.angajatService = angajatService;
        }
        //Metoda Add care returneaza un view cu acelasi nume
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Angajat model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = angajatService.Add(model);
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
            var record = angajatService.FindById(id);
            return View(record);//view primeste inregistrarea care se modifica
        }
        [HttpPost]
        public IActionResult Update(Angajat model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = angajatService.Update(model);
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
                var result = angajatService.Delete(id);

                return RedirectToAction("GetAll");//dupa stergere intotdeauna mergem la metoda GetAll

            }
        }


        public IActionResult GetAll()
        {

            var data = angajatService.GetAll();
            return View(data);

        }
    }
}
