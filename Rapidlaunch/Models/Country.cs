using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Country
    {
        public int CountryID { get; set; }// Primary Key
        public string countryName { get; set; }// access modifier PUBLIC  - String is the data type  / get and set mutators
        public ICollection<Address> Addresses{ get; set; } // used as a functional key elsewhere in Addresses 
    }
}
