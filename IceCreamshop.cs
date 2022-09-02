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
            //TODO function that updates the table - customer didnt pay ////////////
            // BusinessLogic.Logic.fillTables(100);
            break;
        case 3:
            //-----Start new Reservation----
            //ingredients = {"Chocolate", "Vanilla", "Strawberry", "Mint", "Mocha", "Rum Raisin", "Mint Chocolate Chip", "Peach", "Cocunut", "Gluten Free","Maple", "Chocolate" , "Peanuts","Regular", "Special", "Box"};

            Console.WriteLine("0 - Chocolate");
            Console.WriteLine("1 - Vanilla");
            Console.WriteLine("2 - Strawberry");
            Console.WriteLine("3 - Mint");
            Console.WriteLine("4 - Mocha");
            Console.WriteLine("5 - Rum Raisin");
            Console.WriteLine("6 - Mint Chocolate Chip");
            Console.WriteLine("7 - Peach");
            Console.WriteLine("8 - Cocunut");
            Console.WriteLine("9 - Gluten Free");
            string tableName = Console.ReadLine();
            // ArrayList results = BusinessLogic.Logic.getTableData(tableName);
            // foreach (Object obj in results)
            //     Console.WriteLine("   {0}", obj);
            Console.WriteLine();
            break;
    }
    switch (CustomerFirstChoice)
    {
        //new reservation
        case 1:
            Business_Logic.Business_Logic.FillIngreadiantsTables(16);
            Business_Logic.Business_Logic.FillSalesTable();
            //Business_Logic.Business_Logic.FillCustomerResevationTable();
            Console.WriteLine("How many balls would you like to eat? choose number greater than 1 :");
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
            throw new Exception("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(1);
            break;
        case 2: //speacial cone
            while(chooseNumberOfBalls > 3) 
            {
            throw new Exception("You can't choose more than 3 balls");
            Console.WriteLine("Please choose again number of balls: ");
            chooseNumberOfBalls = Int32.Parse(Console.ReadLine());
            }
            Business_Logic.Business_Logic.FillCustomerResevationTable(2);
            break;  
        case 3: //BOX 
             Business_Logic.Business_Logic.FillCustomerResevationTable(3);
            break;
        default:
            break;

    }


} while (ChooseDataBase != -1);

Console.WriteLine("Thank you for your time");

