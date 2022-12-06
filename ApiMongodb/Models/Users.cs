using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiMongodb.Models
{
    public class Users
    {
        //para el id en mongo
        [BsonId]
        public ObjectId id { get; set; }
        public string FirstName { get; set; }
        public int Phone {get; set; }
    }
}
