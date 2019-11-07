using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class StaffSafetyRecord
    {
        public int staffID { get; set; }
        public int safetyRatingID { get; set; }

        public Staff Staff{ get; set; }
        public SafetyRating SafetyRating { get; set; }

    }
}
