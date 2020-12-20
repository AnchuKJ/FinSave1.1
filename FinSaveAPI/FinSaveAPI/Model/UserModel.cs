using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class UserModel
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        public int UId { get; set; }
        public string UserName { get; set; }
        public string  Password { get; set; }

    }
}
