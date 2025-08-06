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

            //LINQ
            // totalConvidados = convidados.Count();
            // totalCriancas = convidados.Count(c => c.Idade <= 10);
            // totalHomens = convidados.Count(h => h.Idade > 10 && h.Sexo == "Masculino");
            // totalMulheres = convidados.Count(m => m.Idade > 10 && m.Sexo == "Feminino");
            // var QtdeCarnePorHome = 0.200m; (n sei)
            // totalCarne = (totalCriancas * 0.200m) + (totalHomens* 0.400m) + (totalMulheres * 0.300m);
            // toalBebida = (totalCriancas * 0.600m) + (totalHomens * 1.200m) + (totalMulheres * 1.000m);


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