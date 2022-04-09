using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProaAtividade.API.models;

namespace ProaAtividade.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtividadeController : ControllerBase
    {
        public IEnumerable<Atividade> Atividades = new List<Atividade>(){
            new Atividade(1),
            new Atividade(2),
            new Atividade(3)
            };
        [HttpGet]
        public IEnumerable<Atividade> Get()
        {
            return Atividades;
        }

        [HttpGet("{id}")]
        public Atividade Get(int id)
        {
            return Atividades.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost("{id}")]
        public IEnumerable<Atividade> Post(Atividade atividade)
        {
            return Atividades.Append<Atividade>(atividade);
        }
    }
}