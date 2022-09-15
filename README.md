# My IceCreamShop
* Written by Guy Azoulay and Tal Malchi.

## Main Goal of our Project:
In this assigment we built our own IceCream Shop using 2 main Data bases: SQL and MongoDB.
Thanks to this assigment we improved our coding skills and started to really understand what is to "think outside of a box",
and understand how the SQL and MongoDB work behind the scene, Most of the code was written in C#, and the data bases
we use in are in MYSql framwork and MongoDB compass fram work.


## The SQL implementation
In this part of the assigment we used MYSql frame work and created 3 main tables:
* Ingredients- static table which we insert in to it all the needed data and we only take from it 
information about specific ingredients.
* Costumer Reservation - This table contain all the information the the costumer wants in his
icecream, the main connection between this table to othe tables is that this table contain
the ingredient id and the sale id.
* Sales- every new sale is getting update in this table, in it there is the date and time of the
reservation, total price the id of the sale and if this sale was complete or not.

In addition there is a summary of all the reservations, you can see a costumer bill,
averge daily price, most common ingredient etc.

## The MongoDb implementation
In this section we do the same idea as in the SQL part but in MongoDB.
In here we use only 2 documents, and not 3 like in the SQL part, 
the ingredients document is also static in here and we take from it all the information we need.
The Sales document has all the data that the costumer did in his reservation.

### How to connect to MongoDB?
- Install MongoDB compass to your computre
- Create new local connection
- Run on the terminal `dotnet add package MongoDB.Driver`
- Then run: `dotnet run IceCreamShop.cs`
