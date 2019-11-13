using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Provider
    {
        public int ProviderID { get; set; } // access modifier PUBLIC  PK - int  is the data type  / get and set mutators
        public string ProviderName { get; set; } // access modifier PUBLIC  - String is the data type  / get and set mutators
        public int ProviderRegNo { get; set; }// access modifier PUBLIC  - int is the data type  / get and set mutators

        public ICollection<ProviderContact> ProviderContacts{ get; set; } // used in ProviderContacts
        public ICollection<ProviderAddress> ProviderAddresses{ get; set; } // used in ProviderAddresses


    }
}
