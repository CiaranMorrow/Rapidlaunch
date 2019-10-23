using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ProviderAddress
    {
       public int  providerID { get; set; }
        public int addressIdentID { get; set; }

        public Address Address { get; set; }
        public Provider Provider { get; set; }

        public ICollection<Launch  > Launches    { get; set; }

    }
}
