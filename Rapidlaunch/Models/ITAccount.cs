using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ITAccount
    {
        public int ITAccountID { get; set; } // PK 
        public int itaccountTypeIdentID { get; set; } // attribute using integers with public acees modifiers

        public ITAccountType ITAccountType{ get; set; } // Fucntional Key used in this table from country  
        public ICollection<Staff> Staffs{ get; set; }// used as a functional key elsewhere in 


    }
}
