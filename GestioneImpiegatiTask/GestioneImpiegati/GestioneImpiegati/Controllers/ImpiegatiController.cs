using GestioneImpiegati.Models;
using GestioneImpiegati.Repos;
using GestioneImpiegati.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestioneImpiegati.Controllers
{
    public class ImpiegatiController : Controller
    {
        private readonly ImpiegatiService _service;
        private readonly RepartoService _repservice;
        public ImpiegatiController(ImpiegatiService service, RepartoService repservice)
        {
            _service = service;
            _repservice = repservice;
        }
        public IActionResult Lista()
        {
            List<Impiegati> elenco = _service.ElencoImpiegati();

            return View(elenco);
        }
        public IActionResult Inserimento()
        {
            ViewBag.ListaReparti = RepartoLista();
            return View();
        }

        [HttpPost]
        public RedirectResult Salvataggio(Impiegati objImpiegati)
        {
            if (_service.InserisciImpiegato(objImpiegati))
                return Redirect("/Impiegati/Lista");
            else
                return Redirect("/Impiegati/Errore");
        }
        public List<Reparto> RepartoLista()
        {
            return _repservice.ElencoTuttiReparti();
        }
    }
}
