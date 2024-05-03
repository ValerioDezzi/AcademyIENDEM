using JustDezziAPI.DTO;
using JustDezziAPI.Models;
using JustDezziAPI.Services;
using JustDezziAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustDezziAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RistoranteController : Controller
    {
        private readonly RistoranteService _service;
        public RistoranteController(RistoranteService service)
        {
            _service = service;
        }
        [HttpGet("listaRistoranti")]
        public ActionResult<List<RistoranteDTO>> ElencoRistoranti()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }
        [HttpPost("inserisciRistorante")]
        public IActionResult InserisciRistorante(RistoranteDTO ristDTO)
        {
            List<string> listaErrori = new List<string>();
            if (string.IsNullOrEmpty(ristDTO.Cod))
            {
                listaErrori.Add("Codice vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(ristDTO.Nom))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(ristDTO.Ind))
            {
                listaErrori.Add("indirizzo vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            if (string.IsNullOrEmpty(ristDTO.Tip))
            {
                listaErrori.Add("Tipologia vuota");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (ristDTO.Ape.Equals(TimeSpan.Zero) || ristDTO.Chi.Equals(TimeSpan.Zero))
            {
                listaErrori.Add("orari non inseriti");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            
            if (_service.InserisciRistorante(ristDTO))
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
        [HttpDelete("eliminaRistorante/{codice}")]
        public ActionResult Delete(string codice)
        {
            if (_service.Elimina(new RistoranteDTO() { Cod = codice }))
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
        [HttpPut("modificaRistorante")]
        public ActionResult EffettuaModifica(RistoranteDTO nuovo)
        {
            List<string> listaErrori = new List<string>();

            if (string.IsNullOrEmpty(nuovo.Nom))
            {
                listaErrori.Add("Nome vuoto");

            }

            if (string.IsNullOrEmpty(nuovo.Tip))
            {
                listaErrori.Add("tipologia non valida");
            }

            if (string.IsNullOrEmpty(nuovo.Ind))
            {
                listaErrori.Add("indirizzo vuoto");

            }
            if (nuovo.Ape.Equals(TimeSpan.Zero) || nuovo.Chi.Equals(TimeSpan.Zero))
            {
                listaErrori.Add("orari non inseriti");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (listaErrori.Count > 0)
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            Ristorante esistente = _service.PrendiByCodice(nuovo.Cod);
            if (esistente == null)
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = "Ristorante non trovato",
                });
            }
            if (_service.Aggiorna(esistente, nuovo))
            {
                return Ok("Ristorante aggiornato con successo.");
            }
            else
            {
                return StatusCode(500, "Si è verificato un errore durante l'aggiornamento dell'utente.");
            }

        }
    }
}
