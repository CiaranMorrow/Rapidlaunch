using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class LaunchStaffSchedule
    {
        public int LaunchStaffScheduleID { get; set; }
        public int launchID { get; set; }
        public int staffID { get; set; }
        


        public Staff staff { get; set; }

        public Launch Launch { get; set; }
    }
}
