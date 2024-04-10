using GestioneEsa.Models;
using GestioneEsa.Services;
using GestioneEsa.Utils;
using Microsoft.AspNetCore.Mvc;

namespace GestioneEsa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContenitoreCelesteController : Controller
    {
        private readonly ContenitoreCelesteService _service;
        public ContenitoreCelesteController(ContenitoreCelesteService service)
        {
            _service = service;
        }
        [HttpGet("allcontenitori")]
        public ActionResult<Risposta> ElencoContenitori()
        {
            return Ok(new Risposta()
            {
                Status = "SUCCESS",
                Data = _service.PrendiliTutti()
            });
        }
        

        
        
    }
}
