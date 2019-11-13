using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Address
    {
        public int AddressID { get; set; } // Primary Key
        public string addressLine1 { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators
        public string addressLine2 { get; set; }// access modifier PUBLIC  - String is the data type 
        public string addressLine3 { get; set; }// access modifier PUBLIC  - String is the data type 
        public int countryID { get; set; }// access modifier PUBLIC  - int is the data type 
        public string postCode { get; set; } // access modifier PUBLIC  - String is the data type 

        public Country country { get; set; } // Fucntional Key used in this table from country  

        public ICollection<StaffAddress> StaffAddresses { get; set; } // used as a functional key elsewhere in 
        public ICollection<ProviderAddress> ProviderAddresses{ get; set; }

    }
}
