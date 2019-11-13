using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class LaunchStaffSchedule
    {
        public int LaunchStaffScheduleID { get; set; } // PK  access modifier PUBLIC  - string is the data type  / get and set mutators
        public int launchID { get; set; }// access modifier PUBLIC  - int is the data type  / get and set mutators
        public int staffID { get; set; }
        


        public Staff staff { get; set; }// used as a functional key in this table from in staff

        public Launch Launch { get; set; }// used as a functional key from this launch 
    }
}
