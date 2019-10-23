using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Rocket
    {
        public int RocketID { get; set; }

        public string rocketName { get; set; }
        public int rocketypeID { get; set; }

        public RocketType RocketType { get; set; }

        public ICollection<Launch> Launches{ get; set; }



    }
}
