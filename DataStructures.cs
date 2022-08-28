using System.Collections;

namespace Icecreamshop
{
class Ingredients
{
    string Product_name;
    int Product_price;
    int Number_of_balls;
    int Take_Not;

    public Ingredients(string Product_name, int Product_price, int Number_of_balls, int Take_Not)
    {
        this.Product_name = Product_name;
        this.Product_price = Product_price;
        this.Number_of_balls = Number_of_balls;
        this.Take_Not = Take_Not;
    }
    public string getProduct_name() { return Product_name; }
    public int getProduct_price() { return Product_price; }
    public int getNumber_of_balls() { return Number_of_balls; }
    public int getTake_Not() { return Take_Not; }
    public override string ToString()
    {
        return base.ToString() + ": " + Product_name + " , " + Product_price + " , " + Number_of_balls + " , " + Take_Not;
    }
}

class Sales{
    string OrderDate;
    int Price;

    public Sales(string OrderDate, int price)
    {
        this.OrderDate = OrderDate;
        this.Price = price;
    }
    public string getOrderDate() { return OrderDate; }
    public int getPrice() { return Price; }

}

class CostumerReservation{
    int id_Ingredient;
    int id_Sales;
    public CostumerReservation(int id_Ingredient, int id_Sales)
    {
        this.id_Ingredient = id_Ingredient;
        this.id_Sales = id_Sales;
    }
    public int getid_Ingredient() { return id_Ingredient; }
    public int getid_Sales() { return id_Sales; }

}
}