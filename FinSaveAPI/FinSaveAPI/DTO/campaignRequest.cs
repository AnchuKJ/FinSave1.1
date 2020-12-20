using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.DTO
{
    public class CampaignRequest
    {
        public string CampaignName { get; set; }
        public string CampaignDesc { get; set; }
        public double TargetAmount { get; set; }
        public string ExpiryDt { get; set; }
        public string StartDt { get; set; }
    }
}
