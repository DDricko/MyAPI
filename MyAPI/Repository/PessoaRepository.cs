using MyAPI.Dao;
using MyAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAPI.Repository
{
    public class PessoaRepository
    {
        private readonly DaoPessoa _daoPessoa;

        public PessoaRepository()
        {
            _daoPessoa = new DaoPessoa();
        }

        public List<Pessoa> GetPessoas
        {
            get
            {
                return _daoPessoa.GetPessoas();
            }
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            _daoPessoa.InserirPessoa(pessoa);
        }
    }
}
