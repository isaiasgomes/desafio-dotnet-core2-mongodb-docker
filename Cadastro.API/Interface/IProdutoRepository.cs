using Cadastro.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Interface
{
    public interface IProdutoRepository
    {
        Task <IEnumerable<Produto>> GetAllProdutos();

        Task<Produto> GetProduto(string codigo);

        Task AddProduto(Produto produto);

        Task<bool> RemoveProduto(string codigo);

        Task<bool> UpdateProduto(string codigo, Produto produto);

        Task<bool> UpdateProdutoObj(string codigo, Produto produto);

        Task<bool> RemoveAllProdutos();

        Task<string> CreateIndex();
    }
}
