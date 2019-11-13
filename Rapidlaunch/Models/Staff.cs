using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Staff
    {
        public int staffID { get; set; }
        public int roleIdentID { get; set; }
        public string staffTel { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators
        public string firstNameIdent { get; set; }// access modifier PUBLIC  - String is the data type  / get and set mutators
        public string lastNameIdent { get; set; }// access modifier PUBLIC  - String is the data type  / get and set mutators
        public string staffEmail { get; set; }// access modifier PUBLIC  - String is the data type  / get and set mutators
        public int itAccountIdentID { get; set; }// access modifier PUBLIC  - Int is the data type  / get and set mutators

        public Role Role { get; set; } // Fucntional Key used in this table from Role  
        public ITAccount ITAccount { get; set; } // Fucntional Key used in this table from IT Account  

        public ICollection<StaffAddress> StaffAddresses { get; set; } // used as a functional key elsewhere in StaffAddresses
        public ICollection<StaffSafetyRecord> StaffSafetyRecords{ get; set; } // used as a functional key elsewhere in StaffSafetyRecords
        public ICollection<LaunchStaffSchedule> LaunchStaffSchedules{ get; set; } // used as a functional key elsewhere in LaunchStaffSchedules



    }
}
