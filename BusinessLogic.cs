using System.Collections;
using Icecreamshop;

namespace Business_Logic{
    public class Business_Logic{
        // 0-9 is flavors, 10-12 is toppings, 13-15 is coneType
        static string [] ingredients = {"Regular Cone", "Special Cone", "Box", "Chocolate", "Vanilla", "Mekufelet", "Mint", "Mocha", "Rum Raisin", "Mint Chocolate Chip", "Peach", "Cocunut", "Gluten Free","Maple Topping", "Chocolate Topping" , "Peanuts Topping"};
        static int [] prices = {0,2,5,7,7,7,7,7,7,7,7,7,7,2,2,2};

        public static void FillIngreadiantsTables(int num)
        {
            //print inside function
            
            for( int i = 0; i < num; i++)
            {
                Console.WriteLine("fill Ingreadiants Tables");
                string i_name= ingredients[i];
                int i_price = prices[i];
                int ball_nums = 0;
                int take_not = 0;
                //insert into ingredients table
                Ingredients newIngredient = new Ingredients(i_name, i_price, ball_nums, take_not);
                SqlServer.SqlServer.insertIntoTable(newIngredient);


            }

        }
        public static void FillSalesTable()
        {
            
                Console.WriteLine("fill Sales Table");
                string o_date= System.DateTime.Now.ToString("yyyy-MM-dd");
                int o_price = 0;
                Sales newSales = new Sales(o_date, o_price);
                SqlServer.SqlServer.insertIntoTable(newSales);
            
        }
        public static void FillCustomerResevationTable()
        {
                Random r = new Random();
                Console.WriteLine("fill Customers Table");
                int id_Sales= 0;
                int id_Ingredient= 0;
                CostumerReservation newCustomers = new CostumerReservation(id_Ingredient, id_Sales);
                SqlServer.SqlServer.insertIntoTable(newCustomers);
            
        }

    };
}
