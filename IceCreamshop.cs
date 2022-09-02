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
            SqlServer.SqlServer.createTables(); //create new connection to SQL, an create empty tables
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
            Console.WriteLine("Choose ypur Flavour :");
            Console.WriteLine("3 - Chocolate");
            Console.WriteLine("4 - Vanilla");
            Console.WriteLine("5 - Strawberry");
            Console.WriteLine("6 - Mint");
            Console.WriteLine("7 - Mocha");
            Console.WriteLine("8 - Rum Raisin");
            Console.WriteLine("9 - Mint Chocolate Chip");
            Console.WriteLine("10 - Peach");
            Console.WriteLine("11 - Cocunut");
            Console.WriteLine("12 - Gluten Free");
            chooseFlavor= Int32.Parse(Console.ReadLine());
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            SqlServer.SqlServer.updateSaleSum();
            Console.WriteLine("Do you want extra balls? (1-yes, 2-no)");
            extraBalls = Int32.Parse(Console.ReadLine());




            break;
        case 2: //speacial cone
            while(chooseNumberOfBalls > 3) 
            {
            Console.WriteLine("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(2);
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            SqlServer.SqlServer.updateSaleSum();
            Console.WriteLine("Do you want extra balls? (1-yes, 0-no)");
            extraBalls = Int32.Parse(Console.ReadLine());
            break;  
        case 3: //BOX 
             Business_Logic.Business_Logic.FillCustomerResevationTable(3);
             Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
             SqlServer.SqlServer.updateSaleSum();
             Console.WriteLine("Do you want extra balls? (1-yes, 0-no)");
             extraBalls = Int32.Parse(Console.ReadLine());
            break;
        default:
            break;

    }
    switch (extraBalls){

        case 0:
            Console.WriteLine("Update Your Reservation");

            SqlServer.SqlServer.updateSaleSum();
            break;
        case 1:
        Console.WriteLine("Choose ypur Flavour :");
            Console.WriteLine("3 - Chocolate");
            Console.WriteLine("4 - Vanilla");
            Console.WriteLine("5 - Strawberry");
            Console.WriteLine("6 - Mint");
            Console.WriteLine("7 - Mocha");
            Console.WriteLine("8 - Rum Raisin");
            Console.WriteLine("9 - Mint Chocolate Chip");
            Console.WriteLine("10 - Peach");
            Console.WriteLine("11 - Cocunut");
            Console.WriteLine("12 - Gluten Free");
            chooseFlavor= Int32.Parse(Console.ReadLine());
            Business_Logic.Business_Logic.FillCustomerResevationTable(chooseFlavor);
            SqlServer.SqlServer.updateSaleSum();
            break;
        default:
            break;


    }


} while (ChooseDataBase != -1);

Console.WriteLine("Thank you for your time");


