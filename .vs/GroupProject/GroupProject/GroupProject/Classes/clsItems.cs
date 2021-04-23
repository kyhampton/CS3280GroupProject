using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    /// <summary>
    /// A class to store item information
    /// </summary>
    public class clsItems
    {
        /// <summary>
        /// The items inventory code.
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// The item description.
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// The total cost of the item.
        /// </summary>
        public double ItemCost { get; set; }
    }
}
