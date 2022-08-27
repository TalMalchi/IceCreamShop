using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using Icecreamshop;

namespace SqlServer{

class SqlServer{
    static string connStr = "server=localhost;user=root;port=3306;password=root";
    public static void createTables()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = "DROP DATABASE IF EXISTS IceCreamShop;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                
                sql = "CREATE DATABASE IceCreamShop;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create vehicles
                sql = "CREATE TABLE `IceCreamShop`.`Ingredient` (" +
                    "`id_Ingredient` INT NOT NULL AUTO_INCREMENT, " +
                    "`Product_name` VARCHAR(45) NULL," +
                    "`Product_price` INT NULL," +
                    "`Number_of_balls` INT NULL," +
                    "`Take_Not` BIT NULL," +
                    "PRIMARY KEY (`id_Ingredient`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create owners
                sql = "CREATE TABLE `IceCreamShop`.`CostumerReservation` (" +
                    "`id_Ingredient` INT NULL, " +
                    "`id_Sales` INT NULL) " ;

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create task
                sql = "CREATE TABLE `IceCreamShop`.`Sales` (" +
                    "`id_Sales` INT NOT NULL AUTO_INCREMENT, " +
                    "`OrderDate` VARCHAR(45) NOT NULL," +
                    "`Price` INT NULL," +
                    "PRIMARY KEY (`id_Sales`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
    
}


}
}