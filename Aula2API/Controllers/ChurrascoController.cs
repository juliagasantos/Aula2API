using Aula2API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChurrascoController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody] List<ConvidadoDTO> convidados)
        {
            var totalConvidados = 0;
            double litrosBebida = 0;
            double kilosCarne = 0;
            var totalHomens = 0;
            var totalMulheres = 0;
            var totalCriancas = 0;

            foreach (var convidado in convidados)
            {
                if (convidado.Idade >= 11)
                {
                    if (convidado.Sexo == "Masculino")
                    {
                        litrosBebida = litrosBebida + 1.200;
                        kilosCarne = kilosCarne + 400;
                        totalHomens++;
                    }
                    else
                    {
                        litrosBebida = litrosBebida + 1.000;
                        kilosCarne = kilosCarne + 300;
                        totalMulheres++;
                    }
                }
                else
                {
                    litrosBebida = litrosBebida + 600;
                    kilosCarne = kilosCarne + 200;
                    totalCriancas++;
                }

                totalConvidados++;
            }

            var resultado = new ChurrascoResultadoDTO
            {
                TotalConvidados = totalConvidados,
                TotalMulheres = totalMulheres,
                TotalHomens = totalHomens,
                TotalCriancas = totalCriancas,
                KilosCarne = kilosCarne,
                LitrosBebida = litrosBebida
            };

            return Ok(resultado);
        }
    }
}