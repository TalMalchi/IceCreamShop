using MySql.Data;
using MySql.Data.MySqlClient;

using BusinessEntities;
using BusinessLogic;
using System.Collections;

namespace MySqlAccess
{
    class MySqlAccess
    {

        static string connStr = "server=localhost;user=root;port=3306;password=malchital1";

        /*
        this call will represent CRUD operation
        CRUD stands for Create,Read,Update,Delete
        */
        public static void createTables()
        {

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                string sql = "DROP DATABASE IF EXISTS Garage;";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create vehicles
                //sql = "CREATE SCHEMA `Garage`";
                sql = "CREATE DATABASE Garage;";
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create vehicles
                sql = "CREATE TABLE `Garage`.`Vehicles` (" +
                    "`idVehicle` INT NOT NULL AUTO_INCREMENT, " +
                    "`Manufacturer` VARCHAR(45) NULL," +
                    "`Color` VARCHAR(45) NULL," +
                    "`Year` INT NULL," +
                    "PRIMARY KEY (`idVehicle`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create owners
                sql = "CREATE TABLE `Garage`.`Owners` (" +
                    "`idOwner` INT NOT NULL AUTO_INCREMENT, " +
                    "`Name` VARCHAR(45) NOT NULL," +
                    "`Phone` VARCHAR(45) NOT NULL," +
                    "`Address` VARCHAR(45) NULL," +
                    "PRIMARY KEY (`idOwner`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create task
                sql = "CREATE TABLE `Garage`.`Tasks` (" +
                    "`idTask` INT NOT NULL AUTO_INCREMENT, " +
                    "`Name` VARCHAR(45) NOT NULL," +
                    "`Description` VARCHAR(245) NULL," +
                    "`Price` INT NULL," +
                    "PRIMARY KEY (`idTask`));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create connection owner - vehicle
                sql = "CREATE TABLE `Garage`.`Vowns` (" +
                    "`idVown` INT NOT NULL AUTO_INCREMENT, " +
                    "`idOwner` INT NOT NULL," +
                    "`idVehicle` INT NOT NULL," +
                    "PRIMARY KEY (`idVown`),"+
                    "FOREIGN KEY (idVehicle) REFERENCES Vehicles(idVehicle)," +
                    "FOREIGN KEY (idOwner) REFERENCES Owners(idOwner));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                // create connection task - vehicle
                sql = "CREATE TABLE `Garage`.`Orders` (" +
                    "`idOrder` INT NOT NULL AUTO_INCREMENT," +
                    "`idVehicle` INT NOT NULL," +
                    "`idTask` INT NOT NULL," +
                    "`OrderDate` DATETIME DEFAULT NOW()," +
                    "`CompleteDate` DATETIME," +
                    "`Completed` INT NOT NULL DEFAULT 0," +
                    "`Payed` INT NOT NULL DEFAULT 0," +
                    "PRIMARY KEY (`idOrder`)," +
                    "FOREIGN KEY (idVehicle) REFERENCES Vehicles(idVehicle)," +
                    "FOREIGN KEY (idTask) REFERENCES Tasks(idTask));";

                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void insertObject(Object obj)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = null;

                if (obj is Owner)
                {
                    Owner owner = (Owner)obj;
                    sql = "INSERT INTO `Garage`.`Owners` (`Name`, `Phone`, `Address`) " +
                    "VALUES ('" + owner.getName() + "', '" + owner.getPhone() + "', '" + owner.getAddress() + "');";
                }

                if (obj is Vehicle)
                {
                    Vehicle vehicle = (Vehicle)obj;
                    sql = "INSERT INTO `Garage`.`Vehicles` (`Manufacturer`, `Color`, `Year`) " +
                    "VALUES ('" + vehicle.getManufacturer() + "', '" + vehicle.getColor() + "', '" + vehicle.getYear() + "');";
                }

                if (obj is VTask)
                {
                    VTask task = (VTask)obj;
                    sql = "INSERT INTO `Garage`.`Tasks` (`Name`, `Description`, `Price`) " +
                    "VALUES ('" + task.getName() + "', '" + task.getDescription() + "', '" + task.getPrice() + "');";
                }

                if (obj is VOwn)
                {
                    VOwn vown = (VOwn)obj;
                    sql = "INSERT INTO `Garage`.`Vowns` (`idOwner`, `idVehicle`) " +
                    "VALUES ('" + vown.getIdOwner() + "', '" + vown.getIdVehicle() + "');";
                }

                if (obj is Order)
                {
                    Order order = (Order)obj;
                    sql = "INSERT INTO `Garage`.`Orders` (`idVehicle`, `idTask`, `OrderDate`, `CompleteDate`, `Completed`, `Payed`) " +
                    "VALUES ('" + order.getIdVehicle() + "', '" + order.getIdTask()+ "', '" +
                     order.getOrderDate() + "', '" + order.getCompleteDate() + "', '" + order.getCompleted()+ "', '" + order.getPayed() + "');";
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

        public static ArrayList readAll(string tableName)
        {
            ArrayList all = new ArrayList();

            try
            {
                MySqlConnection conn = new MySqlConnection(connStr);
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                string sql = "SELECT * FROM `Garage`."+tableName;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                    Object[] numb = new Object[rdr.FieldCount];
                    rdr.GetValues(numb);
                    //Array.ForEach(numb, Console.WriteLine);
                    all.Add(numb);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return all;
        }
    }

}