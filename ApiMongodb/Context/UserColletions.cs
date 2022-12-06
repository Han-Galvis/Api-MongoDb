using ApiMongodb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace ApiMongodb.Context
{
    public class UserColletions
    {
        Mongodb Mongodb = new  Mongodb();
        IMongoCollection<Users> Colletions;
        public UserColletions()
        {
            //crea la coleccion
            Colletions = Mongodb.db.GetCollection<Users>("User");
        }

        public List<Users> GetUsers()
        {
            try
            {
               return Colletions.Find(new BsonDocument()).ToList();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Users GetUsersId(string Id)
        {
            try
            {
                return Colletions.Find(new BsonDocument { { "_id", new ObjectId(Id)} }).First();
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Users InsertUsers(Users users)
        {
            try
            {
               Colletions.InsertOne(users);
                return users;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public Users UpdateUsers(Users users)
        {
            try
            {
                var filter = Builders<Users>.Filter.Eq(x => x.id, users.id);
                Colletions.ReplaceOne(filter, users);
                return users;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteUsers(string Id)
        {
            try
            {
             var filter = Builders<Users>.Filter.Eq(x => x.id, new ObjectId(Id));
             Colletions.DeleteOne(filter);
            }catch(Exception ex)
            {
                return ex.Message;
            }
            return "Ingresado";
        }

        


    }
}
