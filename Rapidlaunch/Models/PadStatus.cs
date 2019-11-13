using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class PadStatus
    {
        public int  PadStatusID { get; set; } // access modifier PUBLIC  - int is the data type  / get and set mutators
        public int padStatus { get; set; } // access modifier PUBLIC  - int is the data type  / get and set mutators


        public ICollection<Launch> Launches{ get; set; } // Fucntional Key used in this table from launch  

    }
}
