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

                
                sql = "CREATE TABLE `IceCreamShop`.`Ingredient` (" +
                    "`id_Ingredient` INT NOT NULL AUTO_INCREMENT, " +
                    "`Product_name` VARCHAR(45) NULL," +
                    "`Product_price` INT NULL," +
                    "PRIMARY KEY (`id_Ingredient`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



                
                sql = "CREATE TABLE `IceCreamShop`.`Sales` (" +
                    "`id_Sales` INT NOT NULL AUTO_INCREMENT, " +
                    "`OrderDate` VARCHAR(45) NOT NULL," +
                    "`Price` INT NULL," +
                    "`Paid/Unpaid` INT NULL," +
                    "PRIMARY KEY (`id_Sales`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                
                sql = "CREATE TABLE `IceCreamShop`.`CostumerReservation` (" +
                // "`id_CostumerReservation` INT NOT NULL AUTO_INCREMENT, " +
                    "`id_Ingredient` INT NOT NULL, " +
                    "`id_Sales` INT NOT NULL, " +
                    "`ingredient_price` INT NULL);";
                 

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        // function to find the max id from the sales table
        public static int getMaxIdSales()
        {
            int maxId = 0;
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT MAX(id_Sales) FROM iceCreamshop.Sales;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    maxId = rdr.GetInt32(0);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return maxId;
        }
        public static void insertIntoTable(Object obj){
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Ingredients)
                {
                    Ingredients newIngredients = (Ingredients)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Ingredient` (`Product_name`, `Product_price`)" + 
                    "VALUES ('" + newIngredients.getProduct_name() + "', '" + newIngredients.getProduct_price() + "');";
                    
                }
                if (obj is Sales)
                {
                    Sales newSales = (Sales)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Sales` (`OrderDate`, `Price`,`Paid/Unpaid`)" +
                    "VALUES ('" + newSales.getOrderDate() + "', '" + newSales.getPrice() + "', '" + 0 + "');";
                }
                if (obj is CostumerReservation)
                {
                    Console.WriteLine("inserting into CostumerReservation");
                    CostumerReservation newCostumerReservation = (CostumerReservation)obj;
                    //print id_Ingredient and id_Sales
                    Console.WriteLine(newCostumerReservation.getid_Ingredient()+ "ID INGREDIENTS");
                    Console.WriteLine(newCostumerReservation.getid_Sales()+ "ID SALE ");
                    Console.WriteLine(newCostumerReservation.getIngredient_price()+ "INGREDIENT PRICE");
                    sql = "INSERT INTO `IceCreamShop`.`CostumerReservation` (`id_Ingredient`, `id_Sales`, `ingredient_price`)" +
                    "VALUES ('" + newCostumerReservation.getid_Ingredient() + "', '" + newCostumerReservation.getid_Sales() + "', '"+ newCostumerReservation.getIngredient_price() + "');";
                }
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                //conn.Close();

        }
         catch (Exception ex)
            {
                Console.WriteLine("bkla blabxlablaxba");
                Console.WriteLine(ex.ToString());
            }
        }

        public static void updateSaleSum(int id){
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE `IceCreamShop`.`Sales` SET `Price` = (SELECT SUM(ingredient_price) FROM `IceCreamShop`.`CostumerReservation` WHERE id_Sales = Sales.id_Sales) WHERE id_Sales = @id;";
                
                //this one change all of the to 1- not good!
                string sql2 = "UPDATE `IceCreamShop`.`Sales` SET `Paid/Unpaid` = 1 WHERE id_Sales = @id AND (`Paid/Unpaid` IS NULL OR `Paid/Unpaid` = 0 );";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();

                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


         public static void updateSaleSumToZero(int id){
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE `IceCreamShop`.`Sales` SET `Paid/Unpaid` = 0 WHERE @id = id_Sales;";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void CostumerReservation(int id){
            // this function print the costumer reservation, in it there is only th price and the date
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT Sales.OrderDate, Sales.Price FROM `IceCreamShop`.`Sales` WHERE id_Sales = @id;";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Your order Date:" + rdr.GetDateTime(0));
                    Console.WriteLine("Your order price:" + rdr.GetInt32(1));
                    Console.WriteLine("-----------------------");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
        public static void DayBills(){
            // this function prints all the sales of the day, number of sales and the sum of the sales
            // and average of the sales
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT COUNT(id_Sales), SUM(Price) FROM `IceCreamShop`.`Sales` WHERE OrderDate = CURDATE();";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Number of sales:" + rdr.GetInt32(0));
                    Console.WriteLine("Sum of sales:" + rdr.GetInt32(1));
                    Console.WriteLine("Average of sales:" + rdr.GetInt32(1)/rdr.GetInt32(0));
                    Console.WriteLine("-----------------------");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void UncompleteSales(){
            // this function prints all the sales that are not paid
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "SELECT id_Sales, OrderDate, Price FROM `IceCreamShop`.`Sales` WHERE `Paid/Unpaid` = 0;";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("id_Sales:" + rdr.GetInt32(0));
                    Console.WriteLine("OrderDate:" + rdr.GetDateTime(1));
                    Console.WriteLine("Price:" + rdr.GetInt32(2));
                    Console.WriteLine("-----------------------");
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void MostCommomIngreadiantAndTopping(){
            // this function prints the most common ingreadient and topping
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                
                string sql = "SELECT Product_name FROM IceCreamShop.Ingredient INNER JOIN (SELECT id_ingredient, COUNT(id_ingredient) FROM `IceCreamShop`.`CostumerReservation` WHERE id_ingredient BETWEEN 4 AND 13 GROUP BY id_ingredient ORDER BY COUNT(id_ingredient) DESC LIMIT 1) AS T1 ON Ingredient.id_ingredient = T1.id_ingredient;";
                
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Most common ingreadient:" + rdr.GetString(0));
                    //Console.WriteLine("Number of times:" + rdr.GetInt32(1));
                    Console.WriteLine("-----------------------");
                }
                rdr.Close();
                sql = "SELECT Product_name FROM IceCreamShop.Ingredient INNER JOIN (SELECT id_ingredient, COUNT(id_ingredient) FROM `IceCreamShop`.`CostumerReservation` WHERE id_ingredient BETWEEN 14 AND 16 GROUP BY id_ingredient ORDER BY COUNT(id_ingredient) DESC LIMIT 1) AS T1 ON Ingredient.id_ingredient = T1.id_ingredient;";
                
                cmd = new MySqlCommand(sql, conn);
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine("-----------------------");
                    Console.WriteLine("Most common Topping:" + rdr.GetString(0));
                   // Console.WriteLine("Number of times:" + rdr.GetInt32(1));
                    Console.WriteLine("-----------------------");
                }



                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }   
    }

}