using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.API.Infra;
using Cadastro.API.Interface;
using Cadastro.API.Model;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.API.Controllers
{
    [Produces("application/json")]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [NoCache]
        [HttpGet]
        [EnableQuery]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _produtoRepository.GetAllProdutos();
        }


        [NoCache]
        [HttpGet]
        [Route("pagination")]
        public async Task<IEnumerable<Produto>> Get(int top, int skip, bool ascending)
        {
            return await _produtoRepository.Pagination(top, skip, ascending);
        }


        [HttpGet("{codigo}")]
        public async Task<Produto> Get(string codigo)
        {
            return await _produtoRepository.GetProduto(codigo) ?? new Produto();
        }


        [HttpPost]
        public void Post([FromBody] Produto produto)
        {
            _produtoRepository.AddProduto(new Produto
            {
                Codigo = produto.Codigo,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                URL_Imagem = produto.URL_Imagem,
                Preco = produto.Preco,
                Marca = produto.Marca,
                Categoria = produto.Categoria

        });
        }


        [HttpPut("{codigo}")]
        public void Put(string codigo, [FromBody]Produto produto)
        {
             _produtoRepository.UpdateProdutoObj(codigo, produto);
        }


        [HttpDelete("{codigo}")]
        public void Delete(string codigo)
        {
            _produtoRepository.RemoveProduto(codigo);
        }
    }
}
