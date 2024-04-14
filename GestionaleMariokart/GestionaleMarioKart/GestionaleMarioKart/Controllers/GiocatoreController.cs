using GestionaleMarioKart.DTO;
using GestionaleMarioKart.Models;
using GestionaleMarioKart.Services;
using GestionaleMarioKart.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace GestionaleMarioKart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GiocatoreController : Controller
    {
        private readonly GiocatoreService _service;
        public GiocatoreController(GiocatoreService service)
        {
            _service = service;
        }



        [HttpGet("listagiocatori")]
        public ActionResult<List<GiocatoreDTO>> ElencoGiocatori(GiocatoreService _service)
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }

        [HttpPost("inseriscigiocatore")]
        public IActionResult InserisciGiocatore(GiocatoreDTO objGioc)
        {
            List<string> listaErrori = new List<string>();

            if (objGioc.Nom is not null && objGioc.Nom.Trim().Equals(""))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (_service.Inserisci(objGioc))
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
        [HttpDelete("elimina/{varNom}")]
        public ActionResult Delete(string varNom)
        {
            if (_service.Elimina(new GiocatoreDTO() { Nom = varNom }))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });

            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Eliminazione non effettuata"
            });
        }

        [HttpGet("modifica/{nomeRicerca}/{nuovoNome}")]
        public ActionResult ModificaNome(string nomeRicerca,string nuovoNome)
        {
            if(_service.ModificaNome(new GiocatoreDTO() { Nom=nomeRicerca,},nuovoNome))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS"
                });
            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Modifica non effettuata"
            });


        }



    }
}

