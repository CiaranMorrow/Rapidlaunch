using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class ITAccount
    {
        public int ITAccountID { get; set; }
        public int itaccountTypeIdentID { get; set; }

        public ITAccountType ITAccountType{ get; set; }
        public ICollection<Staff> Staffs{ get; set; }


    }
}
