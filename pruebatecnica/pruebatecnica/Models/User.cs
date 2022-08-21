using System;
using SQLite;
namespace pruebatecnica.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public String Username { get; set; }
        public String Pass { get; set; }
    }
}

