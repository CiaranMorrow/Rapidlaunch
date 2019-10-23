using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Address
    {
        public int AddressID { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public int countryID { get; set; }
        public string postCode { get; set; }

        public Country country { get; set; } // many 

        public ICollection<StaffAddress> StaffAddresses { get; set; }
        public ICollection<ProviderAddress> ProviderAddresses{ get; set; }

    }
}
