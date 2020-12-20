using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class UserDetails
    {
        public string username { get; set; }
        //public ObjectId userId { get; set; }

        public int userId { get; set; }
        public List<AccountsModel> Accounts { get; set; }
    }
}
