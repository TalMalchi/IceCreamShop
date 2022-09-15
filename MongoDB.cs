using System;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDBS;
// using MongoDB.Bson;
// using MongoDB;
// using SqlServer;
using System.Diagnostics;
using ingredientsMongo;



namespace MongoDataBase
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectId Nowid = new ObjectId();
            MongoDemo db = new MongoDemo("IceCreamShop2");
            coneTypeMongo SconeTypeMongo = new coneTypeMongo(){
                coneType_id = 1,
                coneType_price = 22,
                coneType_Type = "Cone"
            };
            toppingMongo StoppingMongo = new toppingMongo(){
                topping_id = 1,
                topping_price = 12,
                topping_Type = "Chocolateeeeeee"
            };
            flavorMongo SflavorMongo = new flavorMongo(){
                flavor_id = 3,
                flavor_price = 2,
                flavor_Type = "VanillaVanilla"
            };
            //db.insertRecord("Sales", new SalesMongo { Date = DateTime.Now.ToString(), Price = 0});
            SalesMongo sale = new SalesMongo{
                Date = DateTime.Now.ToString(),
                Price = 2,
                SreservationMongo = new reservationMongo{
                numberOfBalls = 2,
                
                MyCone = SconeTypeMongo,
                topping = StoppingMongo,
                flavor = SflavorMongo
            

            }
                }; 
                
            Nowid = db.getLastRecord("Sales");
            Console.WriteLine(Nowid);
            db.upsert("Sales", Nowid, "SreservationMongo.MyCone.coneType_price",3);
            
            ingredientsMongo.IngredientsMongo.fillIngredientsDocument();
            // db.insertRecord("Sales", sale);
            Stopwatch stopwatch = new Stopwatch();
    }
        
    }
    //////////////////////////////////////////////////
 

    // Class to connect to MongoDB  
    public class MongoDemo
    {
        private IMongoDatabase db;

        public MongoDemo(string dataBaseName)
        {
            var client = new MongoClient();
            db = client.GetDatabase(dataBaseName);
        }

        public void insertRecord<T>(string table, T record)
        {
            var collection = db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
    
        
        // function that returns athe last id of the collection
        public ObjectId getLastRecord(string table)
        {
            var collection = db.GetCollection<BsonDocument>(table);
            var filter = new BsonDocument();
            var sort = Builders<BsonDocument>.Sort.Descending("_id");
            var document = collection.Find(filter).Sort(sort).Limit(1).First();
            return document["_id"].AsObjectId;
        }

        // this function upsert a record in the collection - ###TODO: update the final price
        public void upsert<T>(string table, ObjectId id,string whatToUpdate, T newValue)
        {
            var collection = db.GetCollection<T>(table);
            var filter = Builders<T>.Filter.Eq("_id", id);
            var update = Builders<T>.Update.Set(whatToUpdate, newValue);
            collection.UpdateOne(filter, update);



        }


    }
}