using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Services;
using GestionaleMarioKart.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestionaleMarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SquadraController : Controller
    {
        private readonly SquadraService _service;
        public SquadraController(SquadraService service)
        {
            _service = service;
        }

        [HttpGet("listasquadre")]
        public ActionResult<List<Squadra>> ElencoSquadre(SquadraService _service)
        {
            return _service.RestituisciTutti();
        }
        [HttpPost("inseriscisquadra")]
        public IActionResult InserisciSquadra(SquadraDTO objSqua)
        {
            List<string> listaErrori = new List<string>();
            if (string.IsNullOrEmpty(objSqua.Nome))
                listaErrori.Add("Nome vuoto");
            if (objSqua.Pers50 == 0|| objSqua.Pers100 == 0||objSqua.Pers150 == 0)
            {
                listaErrori.Add("Riferimento a un personaggio non valido");
            }
            if (_service.Inserisci(objSqua))
            {
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
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
