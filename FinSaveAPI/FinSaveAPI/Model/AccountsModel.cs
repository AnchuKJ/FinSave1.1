using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class AccountsModel
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        //public MongoDBRef UserId { get; set; }
        public int UserId { get; set; }
        public string AccNum { get; set; }
        public string AccName { get; set; }
        public double Balance { get; set; }
        public decimal Intrest { get; set; }
        public int AccId { get; set; }
    }
}
