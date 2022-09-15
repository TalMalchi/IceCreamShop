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
   class Program{
    
        public static void newSale()
        {
            int chooseNumberOfBalls=0;
            int FirstChoice=0;
            int ChooseCone=0;
            int chooseFlavor=0;
            int chooseTopping=0;
            string [] ingredients = {"","Regular Cone", "Special Cone", "Box", "Chocolate", "Vanilla", "Mekufelet", "Mint", "Mocha", "Rum Raisin", "Mint Chocolate Chip", "Mekupelet", "Cocunut", "Gluten Free","Maple Topping", "Chocolate Topping" , "Peanuts Topping"};
            int [] prices = {0,0,2,5,6,6,6,6,6,6,6,6,6,6,2,2,2,0};
            
            List<flavorMongo> flavorslist = new List<flavorMongo>();

            coneTypeMongo ConeType = new coneTypeMongo();
            toppingMongo toppingMongo= new toppingMongo();
            flavorMongo flavorMongo= new flavorMongo();
            ObjectId Nowid = new ObjectId();
            
            MongoDemo db = new MongoDemo("IceCreamShop2");        
            Console.WriteLine("1 - Start new Reservation");
            Console.WriteLine("2 - Go Out From The Shop");
            Console.WriteLine("3 - Settings and Bills");
            FirstChoice = Int32.Parse(Console.ReadLine());
            //coneTypeMongo SconeTypeMongo = new coneTypeMongo(){};
            switch(FirstChoice){
                case 1:
                                           
                        ingredientsMongo.IngredientsMongo.fillIngredientsDocument();
                        Console.WriteLine("How many balls would you like to eat? (choose number greater than 1 :)");
                        chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("How do you want to eat your icecream? :");
                        Console.WriteLine("1- Regular cone");
                        Console.WriteLine("2- Speacial cone");
                        Console.WriteLine("3- Box");      
                        ChooseCone = Int32.Parse(Console.ReadLine());
                    break;
                case 2:
                    
                    break;
                case 3:
                    break;
                default:
                    break;

            }
            
            switch(ChooseCone){
                
                case 1:
                     //regular cone
                     ConeType.coneType_id=1;
                     ConeType.coneType_price=0;
                     ConeType.coneType_Type="Regular Cone";

                    while(chooseNumberOfBalls > 3) 
                    {
                    Console.WriteLine("You can't choose more than 3 balls");
                    Console.WriteLine("Please choose again number of balls: ");
                    chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
                    }
                    for(int i = chooseNumberOfBalls ; i>0 ; i--){
                    Console.WriteLine("Choose ypur Flavour :");
                    Console.WriteLine("4 - Chocolate");
                    Console.WriteLine("5 - Vanilla");
                    Console.WriteLine("6 - Strawberry");
                    Console.WriteLine("7 - Mint");
                    Console.WriteLine("8 - Mocha");
                    Console.WriteLine("9 - Rum Raisin");
                    Console.WriteLine("10 - Mint Chocolate Chip");
                    Console.WriteLine("11 - Mekupelet");
                    Console.WriteLine("12 - Cocunut");
                    Console.WriteLine("13 - Gluten Free");
                    chooseFlavor= Int32.Parse(Console.ReadLine());
                    if(chooseNumberOfBalls == 1 ){
                        flavorMongo.flavor_id= chooseFlavor;
                            flavorMongo.flavor_price=7;
                            flavorMongo.flavor_Type= ingredients[chooseFlavor];
                    }

                    else{ 
                            flavorMongo.flavor_id= chooseFlavor;
                            flavorMongo.flavor_price= prices[chooseFlavor];
                            flavorMongo.flavor_Type= ingredients[chooseFlavor];
                            


                    }
                    Console.WriteLine("Which topping do you like to add?");
                    Console.WriteLine("14 - Chocolate");
                    Console.WriteLine("15 - Maple Syrup");
                    Console.WriteLine("16 - Peanuts");
                    Console.WriteLine("17 - No Topping");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                    switch(chooseTopping){
                        case 14:
                        if(chooseFlavor != 4 && chooseFlavor != 11){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                        }
                        else{
                            Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                        case 15:
                            if(chooseFlavor != 5){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                        }
                        else{
                            Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                            
                        case 16:
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                            break;
                        case 17:
                            break;    
                        default:
                            break;
                    }
                            }
                    
                    break;
                case 2:
                    //special cone
                    ConeType.coneType_id=2;
                    ConeType.coneType_price=2;
                    ConeType.coneType_Type="Special Cone";
                    while(chooseNumberOfBalls > 3) 
                    {
                    Console.WriteLine("You can't choose more than 3 balls");
                    Console.WriteLine("Please choose again number of balls: ");
                    chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
                    }
                    for(int i = chooseNumberOfBalls ; i>0 ; i--){
                    Console.WriteLine("Choose ypur Flavour :");
                    Console.WriteLine("4 - Chocolate");
                    Console.WriteLine("5 - Vanilla");
                    Console.WriteLine("6 - Strawberry");
                    Console.WriteLine("7 - Mint");
                    Console.WriteLine("8 - Mocha");
                    Console.WriteLine("9 - Rum Raisin");
                    Console.WriteLine("10 - Mint Chocolate Chip");
                    Console.WriteLine("11 - Mekupelet");
                    Console.WriteLine("12 - Cocunut");
                    Console.WriteLine("13 - Gluten Free");
                    chooseFlavor= Int32.Parse(Console.ReadLine());
                    if(chooseNumberOfBalls == 1 ){
                        flavorMongo.flavor_id= chooseFlavor;
                        flavorMongo.flavor_price= 7;
                        flavorMongo.flavor_Type= ingredients[chooseFlavor];
                    }

                    else{ 
                            flavorMongo.flavor_id= chooseFlavor;
                            flavorMongo.flavor_price= prices[chooseFlavor];
                            flavorMongo.flavor_Type= ingredients[chooseFlavor];
                            


                    }
                    Console.WriteLine("Which topping do you like to add?");
                    Console.WriteLine("14 - Chocolate");
                    Console.WriteLine("15 - Maple Syrup");
                    Console.WriteLine("16 - Peanuts");
                    Console.WriteLine("17 - No Topping");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                    switch(chooseTopping){
                        case 14:
                        if(chooseFlavor != 4 && chooseFlavor != 11){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                        }
                        else{
                            Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                        case 15:
                            if(chooseFlavor != 5){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                        }
                        else{
                            Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                            
                        case 16:
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= prices[chooseTopping];
                            toppingMongo.topping_Type= ingredients[chooseTopping];
                            break;
                        case 17:
                            break;    
                        default:
                            break;
                    }
                            }
                    
                    
                    
                    break;
                case 3:
                    //box
                    ConeType.coneType_id=3;
                    ConeType.coneType_price=3;
                    ConeType.coneType_Type="Box";
                    while(chooseNumberOfBalls > 3) 
                    {
                    Console.WriteLine("You can't choose more than 3 balls");
                    Console.WriteLine("Please choose again number of balls: ");
                    chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
                    }
                    for(int i = chooseNumberOfBalls ; i>0 ; i--){
                    Console.WriteLine("Choose ypur Flavour :");
                    Console.WriteLine("4 - Chocolate");
                    Console.WriteLine("5 - Vanilla");
                    Console.WriteLine("6 - Strawberry");
                    Console.WriteLine("7 - Mint");
                    Console.WriteLine("8 - Mocha");
                    Console.WriteLine("9 - Rum Raisin");
                    Console.WriteLine("10 - Mint Chocolate Chip");
                    Console.WriteLine("11 - Mekupelet");
                    Console.WriteLine("12 - Cocunut");
                    Console.WriteLine("13 - Gluten Free");
                    chooseFlavor= Int32.Parse(Console.ReadLine());
                    if(chooseNumberOfBalls == 1 ){
                        flavorMongo.flavor_id= chooseFlavor;
                        flavorMongo.flavor_price= 7;
                        flavorMongo.flavor_Type= ingredients[chooseFlavor];
                    }

                    else{ 
                        for(int j = chooseNumberOfBalls ; j>0 ; j--){
                        flavorMongo f1 = new flavorMongo();
                        f1.flavor_id= chooseFlavor;
                        f1.flavor_price= prices[chooseFlavor];
                        f1.flavor_Type= ingredients[chooseFlavor];
                        flavorslist.Add(f1);

                        
                        }
                            
                            


                    }
                    Console.WriteLine("Which topping do you like to add?");
                    Console.WriteLine("14 - Chocolate");
                    Console.WriteLine("15 - Maple Syrup");
                    Console.WriteLine("16 - Peanuts");
                    Console.WriteLine("17 - No Topping");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                    switch(chooseTopping){
                        case 14:
                        if(chooseFlavor != 4 && chooseFlavor != 11){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= 2;
                            toppingMongo.topping_Type= "Chocolate";
                        }
                        else{
                            Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                        case 15:
                            if(chooseFlavor != 5){
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= 2;
                            toppingMongo.topping_Type= "Maple Syrup";
                        }
                        else{
                            Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                            chooseTopping = Int32.Parse(Console.ReadLine());
                        }
                            break;
                            
                        case 16:
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= 2;
                            toppingMongo.topping_Type= "Peanuts";
                            break;
                        case 17:
                            toppingMongo.topping_id= chooseTopping;
                            toppingMongo.topping_price= 0;
                            toppingMongo.topping_Type= "No"; 
                            break;   
                        default:
                            break;
                    }
                            }
                    

                    
                    break;
                default:
                    break;

            }


            
            //db.insertRecord("Sales", new SalesMongo { Date = DateTime.Now.ToString(), Price = 0});
            SalesMongo sale = new SalesMongo{
                Date = DateTime.Now.ToString(),
                Price = 2,
                SreservationMongo = new reservationMongo{
                numberOfBalls = chooseNumberOfBalls,
                
                MyCone = ConeType,
                topping = toppingMongo,
                flavor = flavorslist
            
            }
                }; 
            db.insertRecord("Sales", sale);
            Nowid = db.getLastRecord("Sales");
            Console.WriteLine(Nowid);
            //db.upsert("Sales", Nowid, "SreservationMongo.MyCone.coneType_price",3);
            
            // ingredientsMongo.IngredientsMongo.fillIngredientsDocument();
            
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