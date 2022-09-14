
// using MongoDB.Driver;
// using MongoDB.Bson;


// using System.Collections;

// namespace MongoDB
// {
//     class MongoDB
//     {
//         // public static void createDB()
//         // {
//         //     Console.WriteLine("createDB_MONGO");

//         //     var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
//         //     settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//         //     var client = new MongoClient(settings);
//         //     var database = client.GetDatabase("IceCreamShop");
//         //     var dbList = database.ListCollectionNames().ToList();

//         // }
//         public static void FillIngredientTable()
//         {
//             Console.WriteLine("FillCustomerResevationTable_MONGO");

//             //insert to the open databaes to ingredient collection
//             var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
//             settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//             var client = new MongoClient(settings);
//             var database = client.GetDatabase("IceCreamShop");
//             Console.WriteLine("The list of databases on this server is: ");
//             var collection = database.GetCollection<BsonDocument>("Ingredients");

            
//             var document = new BsonDocument
//             { 
//                 {"Ingredients", new BsonArray
//                 {
//                     new BsonDocument
//                     {
//                         {"id",1},
//                         {"name", "Regular Cone"},
//                         {"price", 0}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",2},
//                         {"name", "Special Cone"},
//                         {"price", 2}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",3},
//                         {"name", "Box"},
//                         {"price", 5}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",4},
//                         {"name", "Chocolate"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",5},
//                         {"name", "Vanilla"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",6},
//                         {"name", "Strawberry"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",7},
//                         {"name", "Mint"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",8},
//                         {"name", "Mocha"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",9},
//                         {"name", "Rum Raisin"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",10},
//                         {"name", "Mint Chocolate Chip"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",11},
//                         {"name", "Mekupelet"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",12},
//                         {"name", "Cocunut"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",13},
//                         {"name", "Gluten Free"},
//                         {"price", 7}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",14},
//                         {"name", "Chocolate Topping"},
//                         {"price", 2}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",15},
//                         {"name", "Maple Topping"},
//                         {"price", 2}
//                     },
//                     new BsonDocument
//                     {
//                         {"id",16},
//                         {"name", "Peanuts Topping"},
//                         {"price", 2}
//                     },
//                      new BsonDocument
//                     {
//                         {"id",17},
//                         {"name", "No Topping"},
//                         {"price", 0}
                       
//                     }
//                 }

//                 }

//             };
//             //insert
//             Console.WriteLine("Inserting a document into the collection");
//             collection.InsertMany(new[] { document });
//         }

//     public static int FillSalesTable()
//     {
//             int id_sale=1;
//             Console.WriteLine("FillSalesTable_MONGO");

//             //insert to the open databaes to ingredient collection
//             var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
//             settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//             var client = new MongoClient(settings);
//             var database = client.GetDatabase("IceCreamShop");
//             Console.WriteLine("The list of databases on this server is: ");
//             var collection = database.GetCollection<BsonDocument>("Sales");

//             //fill the collection with price=0 and the current date and inserst it to the collection
//             var document = new BsonDocument
//             { 
//                 {"Sales", new BsonArray
//                 {
//                     new BsonDocument
//                     {
//                         {"id_sale", id_sale},
//                         {"price", 0},
//                         {"date", DateTime.Now}
                        
//                     }
//                 }

//                 }

//             };
//             id_sale++;
//             Console.WriteLine("Inserting a document into the collection");
//             collection.InsertMany(new[] { document });
//             return id_sale--;

//         }

//     public static void FillCustomerResevationTable(int id_Ingredient,int id_sale, int Number_of_balls, bool flag){
//             Console.WriteLine("FillCustomerResevationTable_MONGO");

//             //insert to the open databaes to ingredient collection
//             var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
//             settings.ServerApi = new ServerApi(ServerApiVersion.V1);
//             var client = new MongoClient(settings);
//             var database = client.GetDatabase("IceCreamShop");
//             Console.WriteLine("The list of databases on this server is: ");
//             var collection = database.GetCollection<BsonDocument>("CustomerResevation");

//             //fill the collection with price=0 and the current date and inserst it to the collection
//             var document = new BsonDocument
//             { 
//                 {"CustomerResevation", new BsonArray
//                 {
//                     new BsonDocument
//                     {
//                         {"id_Ingredient", id_Ingredient},
//                         {"id_sale", id_sale}
//                         // {"Number_of_balls", Number_of_balls},
//                         // {"flag", flag}
                        
//                     }
//                 }

//                 }

//             };
//             Console.WriteLine("Inserting a document into the collection");
//             collection.InsertMany(new[] { document });

        

//     }
//     }
// class Program{
//     public static void MongoDataBase(){
//     int FirstChoice=0;
//     int chooseNumberOfBalls=0;
//     int ChooseCone=0;
//     int chooseFlavor=0;
//     int chooseTopping=0;
//     int id_sale=0;
//     Console.WriteLine("1 - Start new Reservation");
//     Console.WriteLine("2 - Go Out From The Shop");
//     Console.WriteLine("3 - Settings and Bills");
//     FirstChoice = Int32.Parse(Console.ReadLine());
    
//     switch(FirstChoice){
//         case 1:
//         MongoDB.FillIngredientTable();
//         id_sale=MongoDB.FillSalesTable();
//         // id = Business_Logic.Business_Logic.FillSalesTable();
//             Console.WriteLine("How many balls would you like to eat? (choose number greater than 1 :)");
//             chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
//             Console.WriteLine("How do you want to eat your icecream? :");
//             Console.WriteLine("1- Regular cone");
//             Console.WriteLine("2- Speacial cone");
//             Console.WriteLine("3- Box");      
//             ChooseCone = Int32.Parse(Console.ReadLine());
//             break;
        
//         case 2:
//             Console.WriteLine("Thank you for visiting us, see you next time :)");
//             ChooseCone = 0;
//             break;
//         case 3:
//             break;
//         default:
//             break;

//     }
//     switch(ChooseCone){
//         case 1:
//         while(chooseNumberOfBalls > 3) 
//             {
//             Console.WriteLine("You can't choose more than 3 balls");
//             Console.WriteLine("Please choose again number of balls: ");
//             chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
//             }
//              for(int i = chooseNumberOfBalls ; i>0 ; i--){
            
//             Console.WriteLine("Choose ypur Flavour :");
//             Console.WriteLine("4 - Chocolate");
//             Console.WriteLine("5 - Vanilla");
//             Console.WriteLine("6 - Strawberry");
//             Console.WriteLine("7 - Mint");
//             Console.WriteLine("8 - Mocha");
//             Console.WriteLine("9 - Rum Raisin");
//             Console.WriteLine("10 - Mint Chocolate Chip");
//             Console.WriteLine("11 - Mekupelet");
//             Console.WriteLine("12 - Cocunut");
//             Console.WriteLine("13 - Gluten Free");
//             chooseFlavor= Int32.Parse(Console.ReadLine());
//             if(chooseNumberOfBalls == 1){}

//             else{MongoDB.FillCustomerResevationTable(chooseFlavor,id_sale,chooseNumberOfBalls,true);}
            
//             Console.WriteLine("Which topping do you like to add?");
//             Console.WriteLine("14 - Chocolate");
//             Console.WriteLine("15 - Maple Syrup");
//             Console.WriteLine("16 - Peanuts");
//             Console.WriteLine("17 - No Topping");
            
//             chooseTopping = Int32.Parse(Console.ReadLine());
//             switch(chooseTopping){
//                 case 14:
//                 if(chooseFlavor != 4 && chooseFlavor != 11){
//                     MongoDB.FillCustomerResevationTable(14,id_sale,chooseNumberOfBalls,true);
//                 }
//                 else{
//                     Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
//                     chooseTopping = Int32.Parse(Console.ReadLine());
//                 }
//                     break;
//                 case 15:
//                      if(chooseFlavor != 5){
//                     MongoDB.FillCustomerResevationTable(15,id_sale,chooseNumberOfBalls,true);
//                 }
//                 else{
//                     Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
//                     chooseTopping = Int32.Parse(Console.ReadLine());
//                 }
//                     break;
                    
//                 case 16:
//                     MongoDB.FillCustomerResevationTable(16,id_sale,chooseNumberOfBalls,true);
//                     break;
//                 case 17:
//                     break;    
//                 default:
//                     break;
//             }
//             //SqlServer.SqlServer.updateSaleSum(id);
//             }
//             Console.WriteLine("Have you finished your order? (0-no , 1-yes)");
//             //newReser = Int32.Parse(Console.ReadLine());
            
//             break;
//         case 2:
//             break;
//         case 3:
//             break;
//         default:
//             break;
//     }
//     }
// }
// }