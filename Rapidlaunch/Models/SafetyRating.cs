using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class SafetyRating
    {
        public int safetyRatingID { get; set; }
       public string safetyRating { get; set; }

        public ICollection<StaffSafetyRecord> StaffSafetyRecords{ get; set; }
    }
}
