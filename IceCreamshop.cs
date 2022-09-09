using System.Diagnostics;//used for Stopwatch class

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("The current time is " + DateTime.Now);

Stopwatch stopwatch = new Stopwatch();

int ChooseDataBase = 0;
int CustomerFirstChoice = 0;
int ChooseCone = 0;
int chooseFlavor = 0;
int chooseNumberOfBalls = 0;
int chooseTopping = 0;
int newReser = 0;
int id = -1;
int settingAndBills = 0;

int bills = -1;


SqlServer.SqlServer.createTables(); //create new connection to SQL, an create empty tables
while(true){

{
    
    Console.WriteLine("_____________________");
    Console.WriteLine("Welcome to IceCream Shop :");
    Console.WriteLine("Choose DataBase: ");
    Console.WriteLine(" 1- SQL: ");
    Console.WriteLine(" 2- MondgoDB: ");
    ChooseDataBase = Int32.Parse(Console.ReadLine());
    Console.WriteLine("");
    Console.WriteLine("(-1) - for exit");

    switch (ChooseDataBase)
    {
        case 1:
            Console.WriteLine("1 - Start new Reservation");
            Console.WriteLine("2 - Go Out From The Shop");
            Console.WriteLine("3 - Settings and Bills");
            CustomerFirstChoice = Int32.Parse(Console.ReadLine());    
            break;
        case 2:
            //MongoDB.MongoDB.createDB(); //create new connection to SQL, an create empty tables
            MongoDB.Program.MongoDataBase();
            break;    
        defualt:
            break;    

    }
    switch (CustomerFirstChoice)
    {
        //new reservation
        case 1:
            Business_Logic.Business_Logic.FillIngreadiantsTables(16);
            id = Business_Logic.Business_Logic.FillSalesTable();
            Console.WriteLine("How many balls would you like to eat? (choose number greater than 1 :)");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How do you want to eat your icecream? :");
            Console.WriteLine("1- Regular cone");
            Console.WriteLine("2- Speacial cone");
            Console.WriteLine("3- Box");      
            ChooseCone = Int32.Parse(Console.ReadLine());
            break;
        case 2:
        Console.WriteLine("Thank you for visiting us, see you next time :)");
        ChooseCone = 0;
        newReser=-1;
        break; // TODO: implement in other class  

        case 3:
                // dont forget to update all the other fields
                while(settingAndBills != 5){
                Console.WriteLine("Welcome to Settings and Bills");
                Console.WriteLine("1 - Costumer Reservation");
                Console.WriteLine("2 - Day Bills");
                Console.WriteLine("3 - Uncomplete sales");
                Console.WriteLine("4 - Most commom ingreadiant and topping");
                Console.WriteLine("5 - Go out from settings and bills");
                bills = Int32.Parse(Console.ReadLine());
                switch(bills)
                {
                    case 1:
                        Console.WriteLine("Please enter you id sale you got in the end of your reservation: ");
                        int temp = Int32.Parse(Console.ReadLine());
                        SqlServer.SqlServer.CostumerReservation(temp);
                        ChooseCone = 0;
                        newReser=-1;
                        break;

                    case 2:
                        Console.WriteLine("The day bills are: ");
                        SqlServer.SqlServer.DayBills();
                        ChooseCone = 0;
                        newReser=-1;
                        break;

                    case 3: 
                         Console.WriteLine("The uncomplete sales are: ");
                         SqlServer.SqlServer.UncompleteSales();
                         ChooseCone = 0;
                         newReser=-1;
                         break; 

                    case 4:
                        Console.WriteLine("The most commom ingreadiant and topping are: ");
                        SqlServer.SqlServer.MostCommomIngreadiantAndTopping();
                        ChooseCone = 0;
                        newReser=-1;
                        break;
                    case 5:
                        settingAndBills =5; 
                        newReser=-1;
                        break;    
                    default:
                        break;     
                }            

                }
                
        defualt:
            break;


    }
    // after each ball let the costumer option to pick topping 
    switch (ChooseCone)
    {
        case 0:
            break;
        case 1: //regular con
            while(chooseNumberOfBalls > 3) 
            {
            Console.WriteLine("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(1,chooseNumberOfBalls, true);
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
            if(chooseNumberOfBalls == 1 ){}///////???????

            else{ Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor,chooseNumberOfBalls, false);}
            
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16,chooseNumberOfBalls, false);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            SqlServer.SqlServer.updateSaleSum(id);
            }
            Console.WriteLine("Have you finished your order? (0-no , 1-yes)");
            newReser = Int32.Parse(Console.ReadLine());
            
            break;
            
        case 2: //speacial cone
            while(chooseNumberOfBalls > 3) 
            {
            Console.WriteLine("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(2,chooseNumberOfBalls, true);
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
            if(chooseNumberOfBalls == 1 ){}

            else{ Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor,chooseNumberOfBalls, false);}
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16,chooseNumberOfBalls, false);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            
            SqlServer.SqlServer.updateSaleSum(id);
            }
            Console.WriteLine("Have you finished your order? (0-no , 1-yes)");
            newReser = Int32.Parse(Console.ReadLine());
            
            break;  
        case 3: //BOX 
             
             
            Business_Logic.Business_Logic.FillCustomerResevationTable(3,chooseNumberOfBalls, true);
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
            if(chooseNumberOfBalls == 1 ){}

            else{ Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor,chooseNumberOfBalls, false);}
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15,chooseNumberOfBalls, false);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16,chooseNumberOfBalls, false);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            
            SqlServer.SqlServer.updateSaleSum(id);
             }
            Console.WriteLine("Have you finished your order? (0-no , 1-yes)");
            newReser = Int32.Parse(Console.ReadLine());
             
            break;
        default:
            break;

    }
    
    switch(newReser){
        
        case 1:
            Console.WriteLine("Thank you for your order!, Your id is: " + id);
            break;   
        case 0:
            Console.WriteLine("Please choose again your order!");
            newReser= 1;
            SqlServer.SqlServer.updateSaleSumToZero(id);
            break;
        default:
            continue;
    }
    
} while (newReser != 1);

}
Console.WriteLine("Thank you for your time");

// static void MongoDataBase(){
//     int FirstChoice=0;
//     Console.WriteLine("1 - Start new Reservation");
//     Console.WriteLine("2 - Go Out From The Shop");
//     Console.WriteLine("3 - Settings and Bills");
//     FirstChoice = Int32.Parse(Console.ReadLine());
//     switch(FirstChoice){
//         case 1:
//         MongoDB.MongoDB.FillIngredientTable();
//         MongoDB.MongoDB.FillSalesTable();
//         // id = Business_Logic.Business_Logic.FillSalesTable();
//         //     Console.WriteLine("How many balls would you like to eat? (choose number greater than 1 :)");
//         //     chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
//         //     Console.WriteLine("How do you want to eat your icecream? :");
//         //     Console.WriteLine("1- Regular cone");
//         //     Console.WriteLine("2- Speacial cone");
//         //     Console.WriteLine("3- Box");      
//         //     ChooseCone = Int32.Parse(Console.ReadLine());
//             break;
//         case 2:
//             break;
//         case 3:
//             break;
//         default:
//             break;

//     }

//}


