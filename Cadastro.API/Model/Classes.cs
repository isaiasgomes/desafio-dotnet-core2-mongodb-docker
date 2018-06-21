using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.API.Model
{
    public class Produto
    {
        [BsonId]
        public ObjectId InternalId { get; set; }

        [BsonElement("Codigo")]
        public string Codigo { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }

        [BsonElement("Descricao")]
        public string Descricao { get; set; }

        [BsonElement("URL_Imagem")]
        public string URL_Imagem { get; set; }

        [BsonElement("Preco")]
        public double Preco { get; set; }

        [BsonElement("Marca")]
        public string Marca { get; set; }

        
        [BsonElement("Categoria")]
        public  Categoria Categoria { get; set; }
    }

    public class Categoria
    {
        public ObjectId _id { get; set; }

        [BsonElement("Codigo")]
        public string Codigo { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }


    }

    public class Settings
    {
        public string ConnectionString;
        public string Database;
    }
}
