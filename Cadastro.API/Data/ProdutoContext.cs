using Cadastro.API.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Data
{
    public class ProdutoContext
    {
        private readonly IMongoDatabase _database = null;

        public ProdutoContext(IOptions<Settings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public IMongoCollection<Produto> Produtos
        {
            get
            {
                //var collection = _database.GetCollection<Produto>("Produto");

                //int currentPage = 1, pageSize = 2;

                //double totalDocuments =  collection.Count(FilterDefinition<Produto>.Empty);

                //var totalPages = Math.Ceiling(totalDocuments / pageSize);

                //IMongoCollection<Produto> Result = null;

                //for (int i = 1; i <= totalPages; i++)
                //{
                //    //int count = 1;
                //    Result = (IMongoCollection<Produto>)collection.Find(FilterDefinition<Produto>.Empty)
                //        .Skip((currentPage - 1) * pageSize)
                //        .Limit(pageSize);

                //}


                return _database.GetCollection<Produto>("Produto");

            }
        }

        public IMongoCollection<Categoria> Categorias
        {
            get
            {
                return _database.GetCollection<Categoria>("Categor");
            }
        }
    }
}
