using MySql.Data.MySqlClient;
using Icecreamshop;
namespace SqlServer
{

    class SqlServer
    {
        static string connStr = "server=localhost;user=root;port=3306;password=malchital1";
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
                    "`Take_Not` INT NULL," +
                    "PRIMARY KEY (`id_Ingredient`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



                // create task
                sql = "CREATE TABLE `IceCreamShop`.`Sales` (" +
                    "`id_Sales` INT NOT NULL AUTO_INCREMENT, " +
                    "`OrderDate` DATE NOT NULL," +
                    "`Price` INT NULL," +
                    "PRIMARY KEY (`id_Sales`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create owners
                sql = "CREATE TABLE `IceCreamShop`.`CostumerReservation` (" +
                    "`id_Ingredient` INT NOT NULL, " +
                    "`id_Sales` INT NOT NULL, " +
                    " CONSTRAINT `fk_Ingredient_id_Ingredient` FOREIGN KEY (`id_Ingredient`) REFERENCES `IceCreamShop`.`Ingredient` (`id_Ingredient`)"+
                    "CONSTRAINT `fk_Sales_id_Sales` FOREIGN KEY (`id_Sales`) REFERENCES `IceCreamShop`.`Sales` (`id_Sales`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void insertIntoIngredients(Object obj){
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Ingredients)
                {
                    Ingredients newIngredients = (Ingredients)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Ingredient` (`Product_name`, `Product_price`, `Number_of_balls`, `Take_Not`)" + 
                    "VALUES ('" + newIngredients.getProduct_name() + "', '" + newIngredients.getProduct_price() + "', '" + newIngredients.getNumber_of_balls() + "', '" + newIngredients.getTake_Not() + "');";
                    
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

        }
         catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


    }
}