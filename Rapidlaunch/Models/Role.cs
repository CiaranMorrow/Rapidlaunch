using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Role
    {
       public int roleID { get; set; }
        public string roleName { get; set; }

        public ICollection<ProviderContact> providerContacts{ get; set; }
        public ICollection<Staff    > staff{ get; set; }

    }
}
