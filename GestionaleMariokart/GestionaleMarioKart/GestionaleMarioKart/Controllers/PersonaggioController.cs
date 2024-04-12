using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Services;
using GestionaleMarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestionaleMarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaggioController : Controller
    {
        private readonly PersonaggioService _service;
        public PersonaggioController(PersonaggioService service) 
        { 
            _service = service;
        }

        [HttpGet("listapersonaggi")]
        public ActionResult<List<Personaggio>> ElencoPersonaggi(PersonaggioService _service)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }
        [HttpPost("inseriscipersonaggio")]
        public IActionResult InserisciPersonaggio(PersonaggioDTO objPers)
        {
            List<string> listaErrori = new List<string>();

            if (objPers.Nom is not null && objPers.Nom.Trim().Equals(""))
                listaErrori.Add("Nome vuoto");
            if (objPers.Cat is not null && objPers.Cat.Trim().Equals(""))
                listaErrori.Add("Categoria vuota");
            if (objPers.Cost <0 )
                listaErrori.Add("Costo Invalido");

            if (_service.Inserisci(objPers))
            {
                return Ok(new Risposta()
                {
                    Status="SUCCESS"
                });
            }
            else
            {
                listaErrori.Add("Inserimento fallito");
            }

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = listaErrori
            });
        }


    }
}
