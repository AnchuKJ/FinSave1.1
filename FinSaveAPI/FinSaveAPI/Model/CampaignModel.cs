using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class CampaignModel
    {
        [JsonIgnore]
        public ObjectId _id { get; set; }
        public int CampId { get; set; }
        public string CapaignName { get; set; }
        public string CampaignDesc { get; set; }
        public double TargetAmount { get; set; }
        public double AchievedAmount { get; set; }
        public DateTime ExpiryDt { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime CreatedDt { get; set; }

        public int MemCount { get; set; }
        public int Status { get; set; }
    }
}
