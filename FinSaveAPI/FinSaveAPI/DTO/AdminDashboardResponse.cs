using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.DTO
{
    public class AdminDashboardResponse
    {
        public int activecampaigns { get; set; }
        public int completedcampaigns { get; set; }
        public List<RecentCampaigns> recentcampaigns { get; set; }
        public List<SeriesData> piedata { get; set; }
    }

    public class RecentCampaigns
    {
        public string name { get; set; }
        public List<SeriesData> series { get; set; }
    }
    public class SeriesData
    {
        public string name { get; set; }
        public double value { get; set; }
    }

}
