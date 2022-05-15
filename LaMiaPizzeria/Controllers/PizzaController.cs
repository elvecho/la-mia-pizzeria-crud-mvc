using LaMiaPizzeria.Models;
using LaMiaPizzeria.Models.utils;
using Microsoft.AspNetCore.Mvc;

namespace LaMiaPizzeria.Controllers
{
    public class PizzaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Pizza> pizze = PizzaData.GetPizza();
            return View("Homepage", pizze);
        }
        [HttpGet]
        public IActionResult Dettagli(int id)
        {
            Pizza PizzaTrovata = GetPizzaById(id);

            if (PizzaTrovata != null)
            {
                return View("Dettagli", PizzaTrovata);
            }
            else
            {
                return View("il post con l id " + id + " non è stato trovato");
            }

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("FormPizza");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza NuovaPizza)
        {
            if (!ModelState.IsValid)
            {
                return View("FormPizza");
            }
            Pizza PizzaConId = new Pizza(PizzaData.GetPizza().Count, NuovaPizza.Prezzo, NuovaPizza.Title, NuovaPizza.description, NuovaPizza.image);
            PizzaData.GetPizza().Add(PizzaConId);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Update(int id)
        {
            Pizza PizzaDaModificare = GetPizzaById(id);
            if (PizzaDaModificare == null)
            {
                return NotFound();

            }
            else
            {
                return View("Update", PizzaDaModificare);
            }
        }
        [HttpPost]
        public IActionResult Update(int id, Pizza modello)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", modello);
            }
            Pizza PizzaDaModificare = GetPizzaById(id);

            if (PizzaDaModificare != null)
            {
                PizzaDaModificare.Title = modello.Title;
                PizzaDaModificare.description = modello.description;
                PizzaDaModificare.image = modello.image;
                PizzaDaModificare.Prezzo = modello.Prezzo;

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            int PizzaDaRimuovere = -1;

            List<Pizza> postlist = PizzaData.GetPizza();

            for (int i = 0; i < PizzaData.GetPizza().Count; i++)
            {
                if (postlist[i].Id == id)
                {
                    PizzaDaRimuovere = i;
                }
            }
            if (PizzaDaRimuovere != -1)
            {
                PizzaData.GetPizza().RemoveAt(PizzaDaRimuovere);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }


        }
        private Pizza GetPizzaById(int id)
        {
            Pizza PizzaTrovata = null;

            foreach (Pizza post in PizzaData.GetPizza())
            {
                if (post.Id == id)
                {
                    PizzaTrovata = post;
                    break;
                }
            }
            return PizzaTrovata;
        }
    }
}
