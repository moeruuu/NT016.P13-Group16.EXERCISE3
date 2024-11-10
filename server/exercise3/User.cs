using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;

namespace exercise3
{
    public class User
    {
        [BsonId]
        public ObjectId UserId { get; set; }

        public string Fullname { get; set; }
       
        public string Username { get; set; }

        public string Password { get; set; }
    
        public string Email { get; set; }

        public DateTime Birthday { get; set; }
        
        public bool logging { get; set; }

        
    }
}
