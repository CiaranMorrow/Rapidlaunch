using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ProviderAddress
    {
       public int  ProviderID { get; set; } // access modifier PUBLIC  - int is the data type  / get and set mutators
        public int AddressID { get; set; }// access modifier PUBLIC  - int is the data type  / get and set mutators

        public Provider Provider { get; set; } // uses as the candidtate keys 
        public Address Address { get; set; } // uses as the candidtate keys 

        public ICollection<Launch  > Launches    { get; set; } // // used as a functional key elsewhere in

    }
}
