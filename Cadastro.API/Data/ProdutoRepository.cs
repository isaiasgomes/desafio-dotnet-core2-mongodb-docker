using Cadastro.API.Interface;
using Cadastro.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Data
{
    public class ProdutoRepository : IProdutoRepository
    {

        private readonly ProdutoContext _context = null;

        public ProdutoRepository(IOptions<Settings> settings)
        {
            _context = new ProdutoContext(settings);
        }


        public async Task AddProduto(Produto produto)
        {
            try
            {
                await _context.Produtos.InsertOneAsync(produto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Produto>> GetAllProdutos()
        {
            
            try
            {
                return await _context.Produtos.Find(_ => true).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }


        public async Task<IEnumerable<Produto>> Pagination(int top, int skip, bool ascending)
        {
            var query = _context.Produtos.Find(e => true).Skip(skip).Limit(top);

            if (ascending)
                return await query.SortBy(p => p.Codigo).ToListAsync();
            else
                return await query.SortByDescending(p => p.Codigo).ToListAsync();
        }



        public async Task<Produto> GetProduto(string codigo)
        {
            try
            {
                ObjectId internalId = GetInternalId(codigo);
                return await _context.Produtos
                                .Find(produto => produto.Codigo == codigo || produto.InternalId == internalId)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> RemoveAllProdutos()
        {
            try
            {
                DeleteResult actionResult = await _context.Produtos.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> RemoveProduto(string codigo)
        {
            try
            {
                DeleteResult actionResult = await _context.Produtos.DeleteOneAsync(
                     Builders<Produto>.Filter.Eq("Codigo", codigo));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateProduto(string codigo, Produto produto)
        {
            var filter = Builders<Produto>.Filter.Eq(s => s.Codigo, codigo);
            var update = Builders<Produto>.Update
                            .Set(s => s.Nome, produto.Nome)
                            .Set(s => s.Descricao, produto.Descricao)
                            .Set(s => s.URL_Imagem, produto.URL_Imagem)
                            .Set(s => s.Preco, produto.Preco)
                            .Set(s => s.Marca, produto.Marca)
                            .Set(s => s.Categoria, produto.Categoria);

            try
            {
                UpdateResult actionResult = await _context.Produtos.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
               
                throw ex;
            }
        }

        public async Task<bool> UpdateProdutoObj(string codigo, Produto produto)
        {
            var item = await GetProduto(codigo) ?? new Produto();
            item.Nome = produto.Nome;
            item.Descricao = produto.Descricao;
            item.URL_Imagem = produto.URL_Imagem;
            item.Preco = produto.Preco;
            item.Marca = produto.Marca;
            item.Categoria = produto.Categoria;

            return await UpdateProduto(codigo, item);
        }


        public async Task<string> CreateIndex()
        {
            try
            {
                return await _context.Produtos.Indexes
                                .CreateOneAsync(Builders<Produto>
                                .IndexKeys
                                .Ascending(produto => produto.Nome)
                                .Ascending(produto => produto.Descricao)
                                .Ascending(produto => produto.URL_Imagem)
                                .Ascending(produto => produto.Preco)
                                .Ascending(produto => produto.Marca)
                                .Ascending(produto => produto.Categoria));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

      
    }
}
