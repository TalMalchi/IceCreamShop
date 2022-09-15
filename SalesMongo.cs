using System;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace MongoDBS{
    public class coneTypeMongo{
        public int coneType_id {get; set;}
        public int coneType_price {get; set;}
        public string coneType_Type {get; set;}
    }
    public class toppingMongo{
        public int topping_id {get; set;}
        public int topping_price {get; set;}
        public string topping_Type {get; set;}
    }
    public class flavorMongo{
        public int flavor_id {get; set;}
        public int flavor_price {get; set;}
        public string flavor_Type {get; set;}
    }
    public class SalesMongo{
       [BsonId]
       public ObjectId Id {get; set;}
       public object Date {get; set;}
       public int Price {get; set;}
       public reservationMongo SreservationMongo {get; set;}
    }
    public class reservationMongo{
        
        public int numberOfBalls {get; set;}
        public coneTypeMongo MyCone{get; set;}
        public toppingMongo topping {get; set;}
        public flavorMongo flavor {get; set;}

    }

}