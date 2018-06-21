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
                return _database.GetCollection<Produto>("Produto");
            }
        }
    }
}
