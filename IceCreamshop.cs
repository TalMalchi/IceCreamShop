using System;
using System.Data;
using System.Diagnostics;//used for Stopwatch class
using System.Collections;

using MySql.Data;
using MySql.Data.MySqlClient;

using SqlServer;
using Icecreamshop;

Console.WriteLine("Hello, World!");
Console.WriteLine("The current time is " + DateTime.Now);
Stopwatch stopwatch = new Stopwatch();
int userInput = 0;
do
{
    Console.WriteLine("_____________________");
    Console.WriteLine("Please chose a task:");
    Console.WriteLine("1 - create empty tables");
    Console.WriteLine("2 - fill tables with data");
    Console.WriteLine("3 - print values of a table");
    Console.WriteLine("");
    Console.WriteLine("(-1) - for exit");

    userInput = Int32.Parse(Console.ReadLine());

    switch (userInput)
    {
        case 1:
            SqlServer.SqlServer.createTables();
            break;
        case 2:
            Console.WriteLine("fill should be called");
            BusinessLogic.Logic.fillTables(10);
            break;
        case 3:
            Console.WriteLine("Enter table name (Owners/Tasks/Vehicles)");
            string tableName = Console.ReadLine();
            ArrayList results = BusinessLogic.Logic.getTableData(tableName);
            foreach (Object obj in results)
                Console.WriteLine("   {0}", obj);
            Console.WriteLine();
            break;
    }

} while (userInput != -1);

Console.WriteLine("Thank you for your time");

