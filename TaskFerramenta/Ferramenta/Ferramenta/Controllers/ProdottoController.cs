using Ferramenta.Models;
using Ferramenta.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Ferramenta.Controllers
{
    [ApiController]
    [Route("ferramenta")]
    public class ProdottoController : Controller
    {
        [HttpGet]
        public IActionResult ElencoProdotti()
        {
            return Ok(ProdottoRepo.getInstance().GetAll());
        }


        [HttpGet("{valCodice}")]
        public IActionResult DettaglioProdotto(string codice) 
        {
            Prodotti? prod= ProdottoRepo.getInstance().Get(codice);
            if(prod is not null) 
                return Ok(prod);
            return NotFound();
        }


        [HttpPost]
        public IActionResult InserisciProdotto(Prodotti prod)
        {
            if (ProdottoRepo.getInstance().Insert(prod))
                return Ok(); 
            return BadRequest();
        }


        [HttpDelete("codice/{varCodice}")]
        public IActionResult EliminaProdotto(string varCodice) 
        {
            if (ProdottoRepo.getInstance().Delete(varCodice))
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public IActionResult ModificaProdotto(Prodotti prod)
        {
            if(ProdottoRepo.getInstance().Update(prod))
                return Ok();
            return BadRequest();
        }
       
    }
   
}
