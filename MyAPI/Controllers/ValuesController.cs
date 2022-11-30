using Microsoft.AspNetCore.Mvc;
using MyAPI.Model;
using MyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly PessoaRepository _pessoaRepository;

        public ValuesController()
        {
            _pessoaRepository = new PessoaRepository();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            return _pessoaRepository.GetPessoas;
        }

        [HttpPost]
        public void Post([FromBody] Pessoa pessoa)
        {
            _pessoaRepository.InserirPessoa(pessoa);
        }
    }
}
