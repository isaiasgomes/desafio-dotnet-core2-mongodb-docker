using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cadastro.API.Interface;
using Cadastro.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cadastro.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Seed")]
    public class SeedController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;

        public SeedController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //api/seed/init
        [HttpGet("{setting}")]
        public string Get(string setting)
        {
            if (setting == "init")
            {
                _produtoRepository.RemoveAllProdutos();
                var name = _produtoRepository.CreateIndex();

                _produtoRepository.AddProduto(new Produto()
                {
                    Codigo = "1",
                    Nome = "Produto 1",
                    Descricao = "Descrição 1",
                    URL_Imagem = "http://get-software.com.co/en/2017/09/debugging-netcore-docker-vscode/",
                    Preco = 1,
                    Marca = "Marca 1",
                    Categoria = "1"
                });
                //Categoria = new Categoria() { Codigo="1", Nome="Categoria 1"} });
                _produtoRepository.AddProduto(new Produto()
                {
                    Codigo = "2",
                    Nome = "Produto 2",
                    Descricao = "Descrição 2",
                    URL_Imagem = "http://get-software.com.co/en/2017/09/debugging-netcore-docker-vscode/",
                    Preco = 2,
                    Marca = "Marca 2",
                    Categoria = "2"
                });

                //Categoria = new Categoria() { Codigo = "2", Nome = "Categoria 2" }});
                _produtoRepository.AddProduto(new Produto()
                {
                    Codigo = "3",
                    Nome = "Produto 3",
                    Descricao = "Descrição 3",
                    URL_Imagem = "http://get-software.com.co/en/2017/09/debugging-netcore-docker-vscode/",
                    Preco = 3,
                    Marca = "Marca 3",
                    Categoria = "3"
                });

                //Categoria = new Categoria() { Codigo = "3", Nome = "Categoria 3" }});
                _produtoRepository.AddProduto(new Produto()
                {
                    Codigo = "4",
                    Nome = "Produto 4",
                    Descricao = "Descrição 4",
                    URL_Imagem = "http://get-software.com.co/en/2017/09/debugging-netcore-docker-vscode/",
                    Preco = 4,
                    Marca = "Marca 4",
                    Categoria = "4"
                });

                    //Categoria = new Categoria() { Codigo = "4", Nome = "Categoria 4" }});

                return "Banco de dados ProdutoDb foi criado, e a coleção 'Produtos' foi gerada com 4 produtos";
            }

            return "Unknown";
        }

    }
}