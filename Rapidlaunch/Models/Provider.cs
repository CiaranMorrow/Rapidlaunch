using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Provider
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public int ProviderRegNo { get; set; }

        public ICollection<ProviderContact> ProviderContacts{ get; set; }
        public ICollection<ProviderAddress> ProviderAddresses{ get; set; }


    }
}
