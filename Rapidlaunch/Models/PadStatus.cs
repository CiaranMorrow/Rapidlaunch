using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class PadStatus
    {
        public int  PadStatusID { get; set; }
        public int padStatus { get; set; }


        public ICollection<Launch> Launches{ get; set; }

    }
}
