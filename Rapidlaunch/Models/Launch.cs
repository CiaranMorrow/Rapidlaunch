using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Launch
    {
        public int  LaunchID { get; set; } // Primary Key
        public int providerIdent { get; set; }  // access modifier PUBLIC  - integer is the data type  / get and set mutators
        public DateTime launchDate { get; set; } //   // access modifier PUBLIC  - datetime is the data type  / get and set mutators
        public string launchName { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators
        public string padStatusIdenet { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators
        public string rocketIdentID { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators

        public Provider Provider { get; set; } // this is the foreign key in the table and it originates from provider relation 
        
        public ICollection<LaunchStaffSchedule> LaunchStaffSchedules { get; set; } // this 
        public PadStatus PadStatus { get; set; }
        public Rocket rocket { get; set; }





    }
}
