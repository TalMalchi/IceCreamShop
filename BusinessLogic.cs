using System.Collections;
using Icecreamshop;

namespace Business_Logic{
    public class Business_Logic{
        // 0-9 is flavors, 10-12 is toppings, 13-15 is coneType
        static string [] ingredients = {"Regular Cone", "Special Cone", "Box", "Chocolate", "Vanilla", "Mekufelet", "Mint", "Mocha", "Rum Raisin", "Mint Chocolate Chip", "Mekupelet", "Cocunut", "Gluten Free","Maple Topping", "Chocolate Topping" , "Peanuts Topping"};
        static int [] prices = {0,2,5,7,7,7,7,7,7,7,7,7,7,2,2,2};

        public static void FillIngreadiantsTables(int num)
        {
            //print inside function
            
            for( int i = 0; i < num; i++)
            {
                //Console.WriteLine("fill Ingreadiants Tables");
                string i_name= ingredients[i];
                int i_price = prices[i];
                int ball_nums = 0;
                
                //insert into ingredients table
                Ingredients newIngredient = new Ingredients(i_name, i_price, ball_nums);
                SqlServer.SqlServer.insertIntoTable(newIngredient);


            }

        }
        public static int FillSalesTable()
        {
            
                //Console.WriteLine("fill Sales Table");
                string o_date= System.DateTime.Now.ToString("yyyy-MM-dd");
                int o_price = 0;
                Sales newSales = new Sales(o_date, o_price);
                SqlServer.SqlServer.insertIntoTable(newSales);
                return SqlServer.SqlServer.getMaxIdSales();
            
        }

       

        // We need to take the max id sale in our sale table / or the saven one, and according to 
        // the ingredients table, we need to insert the right ingredients to the costumers table
        public static void FillCustomerResevationTable(int id_Ingredient,int Number_of_balls, bool flag)
        {
                Console.WriteLine("fill Customers Table");
                if(Number_of_balls == 1 && flag == true){
                    int id_Sales = SqlServer.SqlServer.getMaxIdSales();
                    int ingredient_price = 7;
                    CostumerReservation newCostumerReservation = new CostumerReservation(id_Ingredient, id_Sales, ingredient_price);
                    SqlServer.SqlServer.insertIntoTable(newCostumerReservation);
                }
                else{
                int id_Sales= SqlServer.SqlServer.getMaxIdSales();
                int[] update_prices= {0,0,2,5,6,6,6,6,6,6,6,6,6,6,2,2,2};
                int price = update_prices[id_Ingredient];
                CostumerReservation newCustomers = new CostumerReservation(id_Ingredient, id_Sales, price);
                Console.WriteLine("---------------------------------------------------");
                SqlServer.SqlServer.insertIntoTable(newCustomers);
                }
        }

    };
}