
using MongoDB.Driver;
using MongoDB.Bson;


using System.Collections;

namespace MongoDB
{
    class MongoDB
    {
        public static void createDB()
        {
            Console.WriteLine("createDB_MONGO");

            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("IceCreamShop");
            var dbList = database.ListCollectionNames().ToList();
            //for checking
            // Console.WriteLine("The list of databases on this server is: ");
            // foreach (var db in dbList)
            // {
            //     Console.WriteLine(db);
            // }
        }
        public static void FillIngredientTable()
        {
            Console.WriteLine("FillCustomerResevationTable_MONGO");

            //insert to the open databaes to ingredient collection
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("IceCreamShop");
            Console.WriteLine("The list of databases on this server is: ");
            var collection = database.GetCollection<BsonDocument>("Ingredients");

            
            var document = new BsonDocument
            { 
                {"Ingredients", new BsonArray
                {
                    new BsonDocument
                    {
                        {"name", "Regular Cone"},
                        {"price", 0}
                    },
                    new BsonDocument
                    {
                        {"name", "Special Cone"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"name", "Box"},
                        {"price", 5}
                    },
                    new BsonDocument
                    {
                        {"name", "Chocolate"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Vanilla"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Mekufelet"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Mint"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Mocha"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Rum Raisin"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Mint Chocolate Chip"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Mekupelet"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Cocunut"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Gluten Free"},
                        {"price", 7}
                    },
                    new BsonDocument
                    {
                        {"name", "Maple Topping"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"name", "Chocolate Topping"},
                        {"price", 2}
                    },
                    new BsonDocument
                    {
                        {"name", "Peanuts Topping"},
                        {"price", 2}
                    }
                }

                }

            };
            //insert
            Console.WriteLine("Inserting a document into the collection");
            collection.InsertMany(new[] { document });
        }

    public static void FillSalesTable()
        {
            Console.WriteLine("FillCustomerResevationTable_MONGO");

            //insert to the open databaes to ingredient collection
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("IceCreamShop");
            Console.WriteLine("The list of databases on this server is: ");
            var collection = database.GetCollection<BsonDocument>("Sales");

            //fill the collection with price=0 and the current date and inserst it to the collection
            var document = new BsonDocument
            { 
                {"Sales", new BsonArray
                {
                    new BsonDocument
                    {
                        {"price", 0},
                        {"date", DateTime.Now}
                    }
                }

                }

            };
            Console.WriteLine("Inserting a document into the collection");
            collection.InsertMany(new[] { document });

        }
    }
}