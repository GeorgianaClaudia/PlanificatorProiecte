using Microsoft.AspNetCore.Mvc;
using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;
using PlanificatorProiecte.Repositories.Implementation;
using System.Linq;

namespace PlanificatorProiecte.Controllers
{
    public class ProiectController : Controller
    {
        private readonly IProiectService proiectService;
        public ProiectController(IProiectService proiectService)
        {
            this.proiectService = proiectService;
        }
        //Metoda Add care returneaza un view cu acelasi nume
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Proiect model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = proiectService.Add(model);
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
            var record = proiectService.FindById(id);
            return View(record);//view primeste inregistrarea care se modifica
        }
        [HttpPost]
        public IActionResult Update(Proiect model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = proiectService.Update(model);
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
            var result = proiectService.Delete(id);

             return RedirectToAction("GetAll");//dupa stergere intotdeauna mergem la metoda GetAll

            }
        }


        public IActionResult GetAll()
        {

            var data = proiectService.GetAll();
            return View(data);

        }


    } 
            
}
    
