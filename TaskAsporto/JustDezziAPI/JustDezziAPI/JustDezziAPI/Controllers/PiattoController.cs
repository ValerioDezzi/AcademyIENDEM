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
    public class PiattoController : Controller
    {
        private readonly PiattoService _service;
        public PiattoController(PiattoService service)
        {
            _service = service;
        }
        [HttpGet("listaPiatti")]
        public ActionResult<List<PiattoDTO>> ElencoPiatti()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }
        [HttpPost("inserisciPiatto")]
        public IActionResult InserisciPiatto(PiattoDTO piattoDTO)
        {
            List<string> listaErrori = new List<string>();
            if (string.IsNullOrEmpty(piattoDTO.Cod))
            {
                listaErrori.Add("Codice vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(piattoDTO.Nom))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(piattoDTO.Des))
            {
                listaErrori.Add("Descrizione vuota");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            if (piattoDTO.Pre<=0)
            {
                listaErrori.Add("Prezzo vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (piattoDTO.RistoranteRif<=0)
            {
                listaErrori.Add("Ristorante non inserito");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }


            if (_service.InserisciPiatto(piattoDTO))
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
        [HttpDelete("eliminaPiatto/{codice}")]
        public ActionResult Delete(string codice)
        {
            if (_service.Elimina(new PiattoDTO() { Cod = codice }))
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
        [HttpPut("modificaPiatto")]
        public ActionResult EffettuaModifica(PiattoDTO nuovo)
        {
            List<string> listaErrori = new List<string>();

            if (string.IsNullOrEmpty(nuovo.Cod))
            {
                listaErrori.Add("Codice vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(nuovo.Nom))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (string.IsNullOrEmpty(nuovo.Des))
            {
                listaErrori.Add("Descrizione vuota");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            if (nuovo.Pre <= 0)
            {
                listaErrori.Add("Prezzo vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (nuovo.RistoranteRif <0)
            {
                listaErrori.Add("Ristorante non inserito");
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

            Piatto esistente = _service.PrendiByCodice(nuovo.Cod);
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
                return Ok("Piatto aggiornato con successo.");
            }
            else
            {
                return StatusCode(500, "Si è verificato un errore durante l'aggiornamento dell'utente.");
            }

        }
    }
}
