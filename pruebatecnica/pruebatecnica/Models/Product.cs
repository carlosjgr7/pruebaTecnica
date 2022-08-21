using System;
using SQLite;


namespace pruebatecnica.Models
{

    public class Root
    {
        public int id { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
        public Rating rating { get; set; }
    }

    [Table("Rating")]
    public class Rating
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double rate { get; set; }
        public int count { get; set; }
    }

    [Table("Ptoduct")]
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Indexed]
        public int RatingId { get; set; }
        public string title { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public string category { get; set; }
        public string image { get; set; }
    }

    
}

