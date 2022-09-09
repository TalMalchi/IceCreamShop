using System.Collections;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Icecreamshop
{
class Ingredients
{
    string Product_name;
    int Product_price;
    int Number_of_balls;
    

    public Ingredients(string Product_name, int Product_price, int Number_of_balls)
    {
        this.Product_name = Product_name;
        this.Product_price = Product_price;
        this.Number_of_balls = Number_of_balls;
    
    }
    public string getProduct_name() { return Product_name; }
    public int getProduct_price() { return Product_price; }
    public int getNumber_of_balls() { return Number_of_balls; }
    public override string ToString()
    {
        return base.ToString() + ": " + Product_name + " , " + Product_price + " , " + Number_of_balls ;
    }
}

class Sales{
    string OrderDate;
    int Price;

    //int id_Sales
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
    int ingredient_price=0;
    public CostumerReservation(int id_Ingredient, int id_Sales, int ingredient_price)
    {
        this.id_Ingredient = id_Ingredient;
        this.id_Sales = id_Sales;
        this.ingredient_price = ingredient_price;
    }
    public int getid_Ingredient() { return id_Ingredient; }
    public int getid_Sales() { return id_Sales; }
    public int getIngredient_price() { return ingredient_price; }

    string toString() { return id_Ingredient + " , " + id_Sales + " , " + ingredient_price; }

}

class CustomerReservetion_MongoDB{
    Sales sale;
    Ingredients ingredient;

    public CustomerReservetion_MongoDB(Sales sale, Ingredients ingredient)
    {
        this.sale = sale;
        this.ingredient = ingredient;
    }
    public Sales getSale() { return sale; }
    public Ingredients getIngredient() { return ingredient; }

}
}