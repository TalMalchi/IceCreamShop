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
int extraBalls=0;
int chooseTopping = 0;
int newReser = 0;

/*
 need to add while true loop for each costumer reservation, need to check if the auto increament works
 how so we know that a costumer end his reservation and start a new one?
 in the end the costumer will choose -1 and will "pay" and we will start over the reservation, if
 he wants not to pay (regrats) we will sum 0 to the sales table
*/
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
            //SqlServer.SqlServer.createTables(); //create new connection to SQL, an create empty tables
            Console.WriteLine("1 - Start new Reservation");
            Console.WriteLine("2 - Go Out From The Shop");
            Console.WriteLine("3 - Settings and Bills");
            CustomerFirstChoice = Int32.Parse(Console.ReadLine());

            break;
        case 2:
            Console.WriteLine("MongoDB System");
            break;

    }
    switch (CustomerFirstChoice)
    {
        //new reservation
        case 1:
            Business_Logic.Business_Logic.FillIngreadiantsTables(16);
            Business_Logic.Business_Logic.FillSalesTable();
            Console.WriteLine("How many balls would you like to eat? (choose number greater than 1 :)");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            Console.WriteLine("How do you want to eat your icecream? :");
            Console.WriteLine("1- Regular cone");
            Console.WriteLine("2- Speacial cone");
            Console.WriteLine("3- Box");      
            ChooseCone = Int32.Parse(Console.ReadLine());
        defualt:
            break;


    }
    // after each ball let the costumer option to pick topping 
    switch (ChooseCone)
    {
        case 1: //regular con
            while(chooseNumberOfBalls > 3) 
            {
            Console.WriteLine("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(1);
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
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            SqlServer.SqlServer.updateSaleSum();
            // dont think it needed, maybe to add for loop according to the number of balls 
            // and due to it update the flavours, plus we need to save specific number 
            // because the topping.
            // Console.WriteLine("Do you want extra balls? (1-yes, 2-no)");
            // extraBalls = Int32.Parse(Console.ReadLine());
            }



        // need to add the flavours!
            break;
        case 2: //speacial cone
            while(chooseNumberOfBalls > 3) 
            {
            Console.WriteLine("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(2);
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
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            //Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            SqlServer.SqlServer.updateSaleSum();
            // dont think it needed, maybe to add for loop according to the number of balls 
            // and due to it update the flavours, plus we need to save specific number 
            // because the topping.
            // Console.WriteLine("Do you want extra balls? (1-yes, 0-no)");
            // extraBalls = Int32.Parse(Console.ReadLine());
            }
            break;  
            // need to add the flavours!
        case 3: //BOX 
             
             
            Business_Logic.Business_Logic.FillCustomerResevationTable(3);
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
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            Console.WriteLine("Which topping do you like to add?");
            Console.WriteLine("14 - Chocolate");
            Console.WriteLine("15 - Maple Syrup");
            Console.WriteLine("16 - Peanuts");
            Console.WriteLine("17 - No Topping");
            chooseTopping = Int32.Parse(Console.ReadLine());
            switch(chooseTopping){
                case 14:
                if(chooseFlavor != 4 && chooseFlavor != 11){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(14);
                }
                else{
                    Console.WriteLine("You can't add chocolate topping to chocolate icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                case 15:
                     if(chooseFlavor != 5){
                    Business_Logic.Business_Logic.FillCustomerResevationTable(15);
                }
                else{
                    Console.WriteLine("You can't add maple topping to vanilla icecream, Please choose again!");
                    chooseTopping = Int32.Parse(Console.ReadLine());
                }
                    break;
                    
                case 16:
                    Business_Logic.Business_Logic.FillCustomerResevationTable(16);
                    break;
                case 17:
                    break;    
                default:
                    break;
            }
            SqlServer.SqlServer.updateSaleSum();
             // dont think it needed, maybe to add for loop according to the number of balls 
            // and due to it update the flavours, plus we need to save specific number 
            // because the topping.
            //  Console.WriteLine("Do you want extra balls? (1-yes, 0-no)");
            //  extraBalls = Int32.Parse(Console.ReadLine());
             }
            break;
        default:
            break;

    }
    Console.WriteLine("Have you finished your order? (1-yes, 0-no)");
    newReser = Int32.Parse(Console.ReadLine());
    switch(newReser){
        case 1:
            Console.WriteLine("Thank you for your order!");
            break;
        // if he doesnt want to pay, we update the prive in the sales table to 0    
        case 0:
            Console.WriteLine("Please choose again your order!");
            newReser= 1;
            break;
        default:
            break;
    }
    
} while (newReser != 1);

}
Console.WriteLine("Thank you for your time");


