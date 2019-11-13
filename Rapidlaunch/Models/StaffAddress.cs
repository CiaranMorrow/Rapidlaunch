using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class StaffAddress
    {
        public int staffID { get; set; }
        public int AddressID { get; set; }

        public Address Address { get; set; }  // uses as the candidtate keys 
        public Staff staff { get; set; }  // uses as the candidtate keys 



    }
}
