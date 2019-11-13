using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ITAccountType
    {
        public int itAccountTypeID { get; set; } //PK
        public int authorisationLevel { get; set; } // atribute 

        public ICollection<ITAccount> ITAccounts{ get; set; }  // used as a functional key elsewhere in  IT ACCounts 


    }
}
