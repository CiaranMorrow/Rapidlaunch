using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Models
{
    public class Rocket
    {
        /// <summary>
        /// Gets or sets the rocket identifier
        /// </summary>
        /// <value>
        /// The rocket identifier
        /// </value>
        public int RocketID { get; set; }


        /// <summary>
        /// Gets or sets the name of the rocket 
        /// </summary>
        /// <value>
        /// The name of the rocket
        /// </value>
        public string rocketName { get; set; }

        /// <summary>
        /// Gets or sets the rocketype identifier
        /// </summary>
        /// <value>
        /// The rocketype identifier
        /// </value>
        public int rocketypeID { get; set; }

        /// <summary>
        /// Gets or sets the type of the rocket.
        /// </summary>
        /// <value>
        /// The type of the rocket
        /// </value>
        public RocketType RocketType { get; set; }
         /// <summary>
        /// Gets or sets the launches
        /// </summary>
        /// <value>
        /// The launches
        /// </value>
        public ICollection<Launch> Launches{ get; set; }



    }
}
