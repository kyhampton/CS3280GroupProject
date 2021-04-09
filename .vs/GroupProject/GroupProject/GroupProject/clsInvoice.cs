using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    /// <summary>
    /// A class to store invoice information.
    /// </summary>
    public class clsInvoice
    {
        /// <summary>
        /// The invoice number.
        /// </summary>
        public int InvoiceNum { get; set; }

        /// <summary>
        /// The invoice date.
        /// </summary>
        public string InvoiceDate { get; set; }

        /// <summary>
        /// The total cost of the invoice.
        /// </summary>
        public int TotalCost { get; set; }


    }
}
