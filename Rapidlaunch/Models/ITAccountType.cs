using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ITAccountType
    {
        public int itAccountTypeID { get; set; }
        public int authorisationLevel { get; set; }

        public ICollection<ITAccount> ITAccounts{ get; set; }


    }
}
