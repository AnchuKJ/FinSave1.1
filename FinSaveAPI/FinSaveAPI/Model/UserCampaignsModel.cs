using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class UserCampaignsModel
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        public int UCID { get; set; }
        public int UserID { get; set; }
        public int CampaignID { get; set; }
        public double UserContribution { get; set; }
        public int RoundFreq { get; set; }
        public double RoundTo { get; set; }
        public int ContPeriod { get; set; }
        public double MaxContribution { get; set; }
    }
}
