using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class RocketType
    {
        public int rocketTypeID { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string rocketignitor { get; set; }
        public string rocketPropellant { get; set; }

        public ICollection<Rocket>Rockets{ get; set; }
        public ICollection<StaffSafetyRecord> staffSafetyRecords{ get; set; }




    }
}
