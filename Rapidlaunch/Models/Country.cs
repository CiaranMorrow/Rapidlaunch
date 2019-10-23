using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string countryName { get; set; }
        public ICollection<Address> Addresses{ get; set; }
    }
}
