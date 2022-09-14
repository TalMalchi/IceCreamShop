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
            
            MongoDemo db = new MongoDemo("IceCreamShop2");
            
            coneTypeMongo SconeTypeMongo = new coneTypeMongo(){
                coneType_id = 1,
                coneType_price = 2,
                coneType_Type = "Cone"
            };
            toppingMongo StoppingMongo = new toppingMongo(){
                topping_id = 1,
                topping_price = 2,
                topping_Type = "Chocolate"
            };
            flavorMongo SflavorMongo = new flavorMongo(){
                flavor_id = 1,
                flavor_price = 2,
                flavor_Type = "Vanilla"
            };
            //db.insertRecord("Sales", new SalesMongo { Date = Date.Now, Price = 0});
            SalesMongo sale = new SalesMongo{
                Date = DateTime.Now.ToString(),
                Price = 0,
                SreservationMongo = new reservationMongo{
                numberOfBalls = 0,
                
                MyCone = SconeTypeMongo,
                topping = StoppingMongo,
                flavor = SflavorMongo
            

            }
                }; 
                
            
            //ObjectId nowID = sale.Id;
            ingredientsMongo.IngredientsMongo.fillIngredientsDocument();
            db.insertRecord("Sales", sale);
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
    
        



    }
}