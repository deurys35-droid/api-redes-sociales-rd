using Microsoft.AspNetCore.Mvc;
using Redes_Sociales_API.Services;

namespace RedesSocialesRD_API.Controllers
{
    [ApiController]
    [Route("api/redes")]
    public class RedesSocialesController : ControllerBase
    {
        private readonly ServicioCSV _servicio;

        public RedesSocialesController()
        {
            _servicio = new ServicioCSV();
        }

        [HttpGet("resumen-sentimiento")]
        public IActionResult ResumenSentimiento()
        {
            var datos = _servicio.LeerPublicaciones();

            var resultado = datos
                .GroupBy(x => x.Sentimiento)
                .Select(g => new
                {
                    Sentimiento = g.Key,
                    Total = g.Count()
                });

            return Ok(resultado);
        }

        [HttpGet("por-plataforma")]
        public IActionResult PorPlataforma()
        {
            var datos = _servicio.LeerPublicaciones();

            var resultado = datos
                .GroupBy(x => x.Plataforma)
                .Select(g => new
                {
                    Plataforma = g.Key,
                    Total = g.Count()
                });

            return Ok(resultado);
        }
    }
}
