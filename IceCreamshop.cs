using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class

using MySql.Data;
using MySql.Data.MySqlClient;

using MySqlAccess;
using BusinessLogic;
using System.Collections;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.WriteLine("The current time is " + DateTime.Now);

Stopwatch stopwatch = new Stopwatch();

int userInput = 0;
do
{
    Console.WriteLine("_____________________");
    Console.WriteLine("Welcome to IceCream Shop :");
    Console.WriteLine("01 - Start new Reservation");
    Console.WriteLine("02 - Go Out From The Shop");
    Console.WriteLine("03 - Settings and Bills");
    Console.WriteLine("");
    Console.WriteLine("(-1) - for exit");

    userInput = Int32.Parse(Console.ReadLine());

    switch (userInput)
    {
        case 01:
            BusinessLogic.Logic.createTables();
            //////TODO finish the create table function//////////////
            Console.WriteLine("Choose Flavour :");
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
            userInput = Int32.Parse(Console.ReadLine());
            /////////TODO : update the table with the chosen flavour///////////////
             Console.WriteLine("Choose toppings :");
            Console.WriteLine("10 - Maple");
            Console.WriteLine("11 - Peanuts");
            Console.WriteLine("12 - Regular");
            ////TODO: add option with no toppings////////////
            userInput = Int32.Parse(Console.ReadLine());
            /////////TODO : update the table with the chosen flavour/////////////

            break;
        case 02:
            Console.WriteLine("Update your Bill");
            //TODO function that updates the table - customer didnt pay ////////////
            // BusinessLogic.Logic.fillTables(100);
            break;
        case 03:
            Console.WriteLine("Choose Settings");
            string tableName = Console.ReadLine();
            // ArrayList results = BusinessLogic.Logic.getTableData(tableName);
            // foreach (Object obj in results)
            //     Console.WriteLine("   {0}", obj);
            Console.WriteLine();
            break;
    }

} while (userInput != -1);

Console.WriteLine("Thank you for your time");

