using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Launch
    {
        public int  LaunchID { get; set; }
        public int providerIdent { get; set; }
        public DateTime launchDate { get; set; }
        public string launchName { get; set; }
        public string padStatusIdenet { get; set; }
        public string rocketIdentID { get; set; }

        public Provider Provider { get; set; }
        
        public ICollection<LaunchStaffSchedule> LaunchStaffSchedules { get; set; }
        public PadStatus PadStatus { get; set; }
        public Rocket rocket { get; set; }





    }
}
