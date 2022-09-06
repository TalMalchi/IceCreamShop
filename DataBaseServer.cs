using MySql.Data.MySqlClient;
using Icecreamshop;
namespace SqlServer
{

    class SqlServer
    {
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

                
                sql = "CREATE TABLE `IceCreamShop`.`Ingredient` (" +
                    "`id_Ingredient` INT NOT NULL AUTO_INCREMENT, " +
                    "`Product_name` VARCHAR(45) NULL," +
                    "`Product_price` INT NULL," +
                    "`Number_of_balls` INT NULL," +
                    "PRIMARY KEY (`id_Ingredient`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();



                
                sql = "CREATE TABLE `IceCreamShop`.`Sales` (" +
                    "`id_Sales` INT NOT NULL AUTO_INCREMENT, " +
                    "`OrderDate` VARCHAR(45) NOT NULL," +
                    "`Price` INT NULL," +
                    "PRIMARY KEY (`id_Sales`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                
                sql = "CREATE TABLE `IceCreamShop`.`CostumerReservation` (" +
                // "`id_CostumerReservation` INT NOT NULL AUTO_INCREMENT, " +
                    "`id_Ingredient` INT NOT NULL, " +
                    "`id_Sales` INT NOT NULL, " +
                    "`ingredient_price` INT NOT NULL);";
                    // "PRIMARY KEY (`id_CostumerReservation`)," +     
                    //  "FOREIGN KEY (id_Sales) REFERENCES Sales(id_Sales),"+
                    //  "FOREIGN KEY (id_Ingredient) REFERENCES Ingredient(id_Ingredient));";
                    // " CONSTRAINT `fk_Ingredient_id_Ingredient` FOREIGN KEY (`id_Ingredient`) REFERENCES `IceCreamShop`.`Ingredient` (`id_Ingredient`), " +
                    // " CONSTRAINT `fk_Sales_id_Sales` FOREIGN KEY (`id_Sales`) REFERENCES `IceCreamShop`.`Sales` (`id_Sales`),"+
                    //"PRIMARY KEY (`id_Ingredient`, `id_Sales`));";

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
                    sql = "INSERT INTO `IceCreamShop`.`Ingredient` (`Product_name`, `Product_price`, `Number_of_balls`)" + 
                    "VALUES ('" + newIngredients.getProduct_name() + "', '" + newIngredients.getProduct_price() + "', '" + newIngredients.getNumber_of_balls() +"');";
                    
                }
                if (obj is Sales)
                {
                    Sales newSales = (Sales)obj;
                    sql = "INSERT INTO `IceCreamShop`.`Sales` (`OrderDate`, `Price`)" +
                    "VALUES ('" + newSales.getOrderDate() + "', '" + newSales.getPrice() + "');";
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

        public static void updateSaleSum(){
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                string sql = "UPDATE `IceCreamShop`.`Sales` SET `Price` = (SELECT SUM(ingredient_price) FROM `IceCreamShop`.`CostumerReservation` WHERE id_Sales = Sales.id_Sales);";
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