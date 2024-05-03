using JustDezziAPI.DTO;
using JustDezziAPI.Services;
using JustDezziAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustDezziAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarrelloController : Controller
    {
        private readonly CarrelloService _service;
        public CarrelloController(CarrelloService service)
        {
            _service = service;
        }
        [HttpGet("listaCarrelli")]
        public ActionResult<List<CarrelloDTO>> ElencoCarrelli()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }
        [HttpGet("prendiCarrello/{utenteRif}")]
        public ActionResult<CarrelloDTO> PrendiCarrello(int utenteRif)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.PrendiByUtente(utenteRif)
            });
        }
        [HttpPost("inserisciCarrello")]
        public ActionResult InserisciCarrello(CarrelloDTO objCar)
        {
            List<string> listaErrori = new List<string>();
            if(objCar == null|| objCar.UtenteRif<0)
            {
                listaErrori.Add("Carrello non valido");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            if(_service.InserisciCarrello(objCar))
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
        [HttpDelete("{uteRif}")]
        public IActionResult EliminaDipendente(int uteRif)
        {
            if (_service.Elimina(new CarrelloDTO() { UtenteRif = uteRif }))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Utente non trovato"
            });
        }
    }
}
