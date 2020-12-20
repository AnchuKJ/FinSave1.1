using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinSaveAPI.Model
{
    public class ActiveGoalModel
    { 
        public string Goalname { get; set; }
        public string desc { get; set; }
        public double amount { get; set; }
        public double collectedamount { get; set; }
        public DateTime expires { get; set; }
        public int memberscount { get; set; }
        public DateTime createdon { get; set; }
        public double contributionamount { get; set; }
        public double contributionpercent { get; set; }
    }
}
