using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ProviderContact
    {
        public int ProviderContactID { get; set; }
        public int providerID { get; set; }
        public string firstName{ get; set; }
        public string lastName{ get; set; }
        public string contactEmail { get; set; }
        public int roleIdentID { get; set; }
        public int contactTelNum { get; set; }

        public Provider provider { get; set; }

        public Role role { get; set; }
    }
}
