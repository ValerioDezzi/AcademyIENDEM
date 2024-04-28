using GestFerrAuth.DTO;
using GestFerrAuth.Models;
using GestFerrAuth.Services;
using GestFerrAuth.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestFerrAuth.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProdottoController : Controller
    {
        private readonly ProdottoService _service;

        public ProdottoController(ProdottoService service)
        {
            _service = service;
        }

        [HttpGet("filtrati")]
        public ActionResult<List<ProdottoDto>> ElencoProdottiFiltrati()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciProdottiFiltrati()


            });
        }

        [HttpGet("nonfiltrati")]
        public ActionResult<List<ProdottoDto>> ElencoProdottiNonFiltrati()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.RestituisciTutti()
            });
        }

        [HttpPost("inserisci")]
        public IActionResult InserisciProdotto(ProdottoDto objProd)
        {
            List<string> listaErrori = new List<string>();
            if (objProd.Nom is not null && objProd.Nom.Trim().Equals(""))
            {
                listaErrori.Add("Nome vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (objProd.Cat is not null && objProd.Cat.Trim().Equals(""))
            {
                listaErrori.Add("Categoria vuota");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }

            if (objProd.Pre < 0)
            {
                listaErrori.Add("prezzo vuoto");
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = listaErrori
                });
            }


            if (_service.InserisciProdotto(objProd))
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
        [HttpDelete("elimina/{codice}")]
        public ActionResult Delete(string codice)
        {
            if (_service.Elimina(new ProdottoDto() { Cod = codice }))
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
        [HttpPost("modifica")]
        public ActionResult EffettuaModifica(ProdottoDto nuovo)
        {
            if (nuovo.Cod is null && nuovo.Nom is null && nuovo.Cat is null && nuovo.Des is null
                && nuovo is null)
            {
                return Ok(new Risposta()
                {
                    Status = "ERROR",
                    Data = "Modifica non effettuata"
                });
            }

                ProdottoDto? vecchio = _service.PrendiByCodice(nuovo);
                if (vecchio is null )
                    return Ok(new Risposta()
                    {
                        Status = "ERROR",
                        Data = "Elemento non trovato"
                    });
                if(_service.Aggiorna(vecchio,nuovo))
                return Ok(new Risposta()
                {
                    Status = "SUCCESS",
                    Data = "Modifica effettuata"
                });
            return Ok(new Risposta()
            {
                Status = "ERROR",
                Data = "Elemento non trovato"
            });



        }

    }
}
