using MongoDB.Driver;

namespace ApiMongodb.Context
{
    public class Mongodb
    {
        public MongoClient MongoClient;
        public IMongoDatabase db;

        public Mongodb()
        {
            MongoClient = new MongoClient("mongodb://admin:admin@localhost:27017/?authSource=admin&readPreference=primary&ssl=false");
            //crea la bd 
            db = MongoClient.GetDatabase("Example");
        }
    }
}
