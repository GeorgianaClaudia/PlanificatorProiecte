using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using PlanificatorProiecte.Models.Domain;
using PlanificatorProiecte.Repositories.Abstract;



namespace PlanificatorProiecte.Controllers
{
    public class AlocareController : Controller
    {
        private readonly IAlocareService alocareService;
        private readonly IStareAlocareService stareAlocareService;
        private readonly IAngajatService angajatService;
        private readonly IProiectService proiectService;
        public AlocareController(IAlocareService alocareService, IStareAlocareService stareAlocareService, IAngajatService angajatService, IProiectService proiectService)
        {
            this.alocareService = alocareService;
            this.stareAlocareService = stareAlocareService;
            this.angajatService = angajatService;
            this.proiectService = proiectService;
        }
        //Metoda Add care returneaza un view cu acelasi nume
        public IActionResult Add()
        {
            var model = new Alocare();
            model.AngajatList = angajatService.GetAll().Select(a => new SelectListItem { Text = a.NumeAngajat, Value = a.Id.ToString() }).ToList();
            model.ProiectList = proiectService.GetAll().Select(a => new SelectListItem { Text = a.NumeProiect, Value = a.Id.ToString() }).ToList();
            model.StareAlocareList = stareAlocareService.GetAll().Select(a => new SelectListItem { Text = a.NumeStareAlocare, Value = a.Id.ToString() }).ToList();
            return View(model);
           
        }
        [HttpPost]
        public IActionResult Add(Alocare model)
        {
            model.AngajatList = angajatService.GetAll().Select(a => new SelectListItem { Text = a.NumeAngajat, Value = a.Id.ToString(), Selected=a.Id==model.AngajatID }).ToList();
            model.ProiectList = proiectService.GetAll().Select(a => new SelectListItem { Text = a.NumeProiect, Value = a.Id.ToString(), Selected = a.Id == model.ProiectId }).ToList();
            model.StareAlocareList = stareAlocareService.GetAll().Select(a => new SelectListItem { Text = a.NumeStareAlocare, Value = a.Id.ToString(), Selected = a.Id == model.StareAlocareId }).ToList();

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = alocareService.Add(model);
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
            var model = alocareService.FindById(id);
            model.AngajatList = angajatService.GetAll().Select(a => new SelectListItem { Text = a.NumeAngajat, Value = a.Id.ToString(), Selected = a.Id == model.AngajatID }).ToList();
            model.ProiectList = proiectService.GetAll().Select(a => new SelectListItem { Text = a.NumeProiect, Value = a.Id.ToString(), Selected = a.Id == model.ProiectId }).ToList();
            model.StareAlocareList = stareAlocareService.GetAll().Select(a => new SelectListItem { Text = a.NumeStareAlocare, Value = a.Id.ToString(), Selected = a.Id == model.StareAlocareId }).ToList();
            return View(model);//view primeste inregistrarea care se modifica
        }
        [HttpPost]
        public IActionResult Update(Alocare model)
        {
            model.AngajatList = angajatService.GetAll().Select(a => new SelectListItem { Text = a.NumeAngajat, Value = a.Id.ToString(), Selected = a.Id == model.AngajatID }).ToList();
            model.ProiectList = proiectService.GetAll().Select(a => new SelectListItem { Text = a.NumeProiect, Value = a.Id.ToString(), Selected = a.Id == model.ProiectId }).ToList();
            model.StareAlocareList = stareAlocareService.GetAll().Select(a => new SelectListItem { Text = a.NumeStareAlocare, Value = a.Id.ToString(), Selected = a.Id == model.StareAlocareId }).ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = alocareService.Update(model);
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
                var result = alocareService.Delete(id);

                return RedirectToAction("GetAll");//dupa stergere intotdeauna mergem la metoda GetAll

            }
        }


        public IActionResult GetAll(string searchTermAngajat, string searchTermProiect)
        {
            var data = alocareService.GetAll(searchTermAngajat, searchTermProiect);

            return View(data);
        }

        public IActionResult DownloadExcel(string searchTermAngajat, string searchTermProiect)
        {
            using (var workbook = new XLWorkbook())
            {
                // Create a worksheet in the workbook
                var worksheet = workbook.Worksheets.Add("Alocari");

                // Set the column headers
                worksheet.Cell(1, 1).Value = "Proiect";
                worksheet.Cell(1, 2).Value = "Descriere Alocare";
                worksheet.Cell(1, 3).Value = "Stare Alocare";
                worksheet.Cell(1, 4).Value = "Termen de realizare";
                worksheet.Cell(1, 5).Value = "Angajat";

                // Populate the data rows
                var alocari = alocareService.GetAll(searchTermAngajat, searchTermProiect);

                int row = 2;
                foreach (var alocare in alocari)
                {
                    worksheet.Cell(row, 1).Value = alocare.NumeProiect;
                    worksheet.Cell(row, 2).Value = alocare.Nume;
                    worksheet.Cell(row, 3).Value = alocare.NumeStareAlocare;
                    worksheet.Cell(row, 4).Value = alocare.Termen;
                    worksheet.Cell(row, 5).Value = alocare.NumeAngajat;
                    row++;
                }

                // Create a memory stream to store the Excel file
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    // Set the position of the stream back to 0 to read from the beginning
                    stream.Position = 0;

                    // Define the content type and file name
                    var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    var fileName = "alocari.xlsx";

                    // Return the file as a downloadable attachment
                    return File(stream.ToArray(), contentType, fileName);
                }
            }
        }
    }
        
       







}

