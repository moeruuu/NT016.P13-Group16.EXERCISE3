using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace exercise3
{
    public class Token
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public ObjectId UserId { get; set; }
        public string RefreshToken { get; set; }
        public int UsedToken { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ExpiresTime { get; set; }
    }
}
