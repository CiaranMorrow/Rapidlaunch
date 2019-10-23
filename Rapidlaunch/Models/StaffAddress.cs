using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class StaffAddress
    {
        public int staffAdrressID { get; set; }
        public int staffIdentID { get; set; }

        public Address Address { get; set; }
        public Staff staff { get; set; }



    }
}
