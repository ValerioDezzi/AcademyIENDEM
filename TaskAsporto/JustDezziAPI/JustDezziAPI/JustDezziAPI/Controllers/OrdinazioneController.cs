using JustDezziAPI.DTO;
using JustDezziAPI.Services;
using JustDezziAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustDezziAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdinazioneController : Controller
    {
        private readonly OrdinazioneService _service;
        public OrdinazioneController(OrdinazioneService service)
        {
            _service = service;
        }
        [HttpPost("inserisciOrdinazione")]
        public ActionResult InserisciOrdinazione(OrdinazioneDTO objOrd)
        {
            List<string> listaErrori = new List<string>();
            if (objOrd == null || objOrd.UtenteRif < 0 || objOrd.Codice is not null)
            {
                listaErrori.Add("Carrello non valido");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            if (_service.InserisciOrdinazione(objOrd))
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
