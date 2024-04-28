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
    public class UtenteController : Controller
    {
        private readonly UtenteService _service;
        public UtenteController(UtenteService utenteService)
        {
            _service = utenteService;
        }

        [HttpGet("listaUtenti")]
        public ActionResult<List<UtenteDTO>> ElencoUtenti()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }
        [HttpPost("inserisciUtente")]
        public IActionResult InserisciProdotto(UtenteDTO objUte)
        {
            List<string> listaErrori = new List<string>();
            if (objUte.Nom is not null && objUte.Nom.Trim().Equals(""))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (objUte.Pas is not null && objUte.Pas.Trim().Equals("") && objUte.Pas.Length < 8)
            {
                listaErrori.Add("Password non valida");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (objUte.Ind is not null && objUte.Ind.Trim().Equals(""))
            {
                listaErrori.Add("indirizzo vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }


            if (_service.InserisciUtente(objUte))
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
        [HttpDelete("eliminaUtente/{nome}")]
        public ActionResult Delete(string nome)
        {
            if (_service.Elimina(new UtenteDTO() { Nom = nome }))
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
        [HttpPut("modificaUtente")]
        public ActionResult EffettuaModifica(UtenteDTO nuovo)
        {
            List<string> listaErrori = new List<string>();

            if (string.IsNullOrEmpty(nuovo.Nom))
            {
                listaErrori.Add("Nome vuoto");
                
            }

            if (string.IsNullOrEmpty(nuovo.Ema))
            { 
                listaErrori.Add("email non valida");
            }

            if (string.IsNullOrEmpty(nuovo.Ind))
            {
                listaErrori.Add("indirizzo vuoto");
                
            }

            if (listaErrori.Count > 0)
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }
            
            Utente esistente = _service.PrendiByNome(nuovo.Nom);
            if (esistente == null)
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = "Utente non trovato",
                });
            }
            if(_service.Aggiorna(esistente,nuovo))
            {
                return Ok("Utente aggiornato con successo.");
            }
            else
            {
                return StatusCode(500, "Si è verificato un errore durante l'aggiornamento dell'utente.");
            }

        }

    }
}
