using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ProviderAddress
    {
       public int  ProviderID { get; set; }
        public int AddressID { get; set; }
       
        public Provider Provider { get; set; }
        public Address Address { get; set; }

        public ICollection<Launch  > Launches    { get; set; }

    }
}
