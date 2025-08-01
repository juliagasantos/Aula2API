using Aula2API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aula2API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        [HttpPost("aluno")]

        public ActionResult Post([FromBody]AlunoDTO aluno)
        {
            var media = (aluno.Nota1 + aluno.Nota2 + aluno.Nota3 + aluno.Nota4) / 4;
            var situacao = (media >= 6) ? "Aprovado" : "Reprovado";
            var resultado = new MediaResultadoDTO
            {
                Aluno = aluno.Nome,
                Media = media,
                Situacao = situacao
            };
            return Ok(resultado);
        }

        [HttpPost("alunos")]
        public ActionResult Post([FromBody] List<AlunoDTO> alunos)
        {
            var resultados = new List<MediaResultadoDTO>();

            //percorrendo a lista de alunos
            foreach (var aluno in alunos)
            {
                var media = (aluno.Nota1 + aluno.Nota2 + aluno.Nota3 + aluno.Nota4) / 4;
                var situacao = (media >= 6) ? "Aprovado" : "Reprovado";
                resultados.Add(new MediaResultadoDTO
                {
                    Aluno = aluno.Nome,
                    Media = media,
                    Situacao = situacao
                });
            }
            return Ok(resultados);
        }
    }
}
