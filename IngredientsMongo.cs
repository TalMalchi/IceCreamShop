using System;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections;
namespace ingredientsMongo{
    class IngredientsMongo{
        public static void fillIngredientsDocument(){
        var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        var client = new MongoClient(settings);
        var database = client.GetDatabase("IceCreamShop2");
        Console.WriteLine("The list of databases on this server is: ");
        var collection = database.GetCollection<BsonDocument>("Ingredients");   
        var document = new BsonDocument
            { 
                {"Ingredients", new BsonArray
                {
                    new BsonDocument
                    {
                        {"id",1},
                        {"name", "Regular Cone"},
                        {"price", 0}
                    },
                    new BsonDocument
                    {
                        {"id",2},
                        {"name", "Special Cone"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"id",3},
                        {"name", "Box"},
                        {"price", 5}
                    },
                    new BsonDocument
                    {
                        {"id",4},
                        {"name", "Chocolate"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",5},
                        {"name", "Vanilla"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",6},
                        {"name", "Strawberry"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",7},
                        {"name", "Mint"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",8},
                        {"name", "Mocha"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",9},
                        {"name", "Rum Raisin"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",10},
                        {"name", "Mint Chocolate Chip"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",11},
                        {"name", "Mekupelet"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",12},
                        {"name", "Cocunut"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",13},
                        {"name", "Gluten Free"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"id",14},
                        {"name", "Chocolate Topping"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"id",15},
                        {"name", "Maple Topping"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"id",16},
                        {"name", "Peanuts Topping"},
                        {"price", 2}
                    },
                     new BsonDocument
                    {
                        {"id",17},
                        {"name", "No Topping"},
                        {"price", 0}
                       
                    }
                }

                }
            };
            collection.InsertMany(new[] { document });
}
}
}
   


    
