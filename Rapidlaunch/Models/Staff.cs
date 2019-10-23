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
        public string staffTel { get; set; }
        public string firstNameIdent { get; set; }
        public string lastNameIdent { get; set; }
        public string staffEmail { get; set; }
        public int itAccountIdentID { get; set; }

        public Role Role { get; set; }
        public ITAccount ITAccount { get; set; }

        public ICollection<StaffAddress> StaffAddresses { get; set; }
        public ICollection<StaffSafetyRecord> StaffSafetyRecords{ get; set; }
        public ICollection<LaunchStaffSchedule> LaunchStaffSchedules{ get; set; }
       


    }
}
