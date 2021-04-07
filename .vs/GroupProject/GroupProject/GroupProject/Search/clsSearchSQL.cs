using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsSearchSQL
    {

        /// <summary>
        /// The SQL gets all of the invoices.
        /// </summary>
        /// <returns>All data from Invoice tabel</returns>
        public string SelectAllInvoices()
        {
            string sSQL = "SELECT * FROM Invoices";

            return sSQL;
        }

        /// <summary>
        /// The SQL to select all the inoices with a specific invoice number.
        /// </summary>
        /// <param name="InvoiceNum">The InvoiceNum to retrieve the invoice data</param>
        /// <returns>A specific Invoice</returns>
        public string SelectInvoiceData(string InvoiceNum)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum;

            return sSQL;
        }

        /// <summary>
        /// The SQL returns the specific invoices with the provided invoice number and date.
        /// </summary>
        /// <param name="InvoiceNum">The invoice number</param>
        /// <param name="InvoiceDate">The invoice date</param>
        /// <returns>A specific invoice</returns>
        public string SelectInvoiceByDate(string InvoiceNum, string InvoiceDate)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum + "AND InvoiceDate = #" + InvoiceDate + "#";

            return sSQL;
        }

        /// <summary>
        /// The SQL returns the specific invoices with the provided invoice number,date and total cost.
        /// </summary>
        /// <param name="InvoiceNum">The invoice number</param>
        /// <param name="InvoiceDate">The invoice date</param>
        /// <param name="TotalCost">The total cost of the invoice</param>
        /// <returns>A specific invoice</returns>
        public string SelectInvoiceByDateAndCost(string InvoiceNum, string InvoiceDate, string TotalCost)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceNum = " + InvoiceNum + " AND InvoiceDate = #" + InvoiceDate + "# AND TotalCost = " + TotalCost;

            return sSQL;
        }

        /// <summary>
        /// The SQL to select the invoices by total cost.
        /// </summary>
        /// <param name="TotalCost">The total cost of the invoice</param>
        /// <returns></returns>
        public string SelectInvoiceByCost(string TotalCost)
        {
            string sSQL = "SELECT * FROM Invoices WHERE TotalCost =" + TotalCost;

            return sSQL;
        }

        /// <summary>
        /// The SQL to select the invoice by cost and date.
        /// </summary>
        /// <param name="TotalCost">The total cost of the invoice</param>
        /// <param name="InvoiceDate">The invoice date</param>
        /// <returns>A controlled range of invoices</returns>
        public string SelectInvoiceByCostAndDate(string TotalCost, string InvoiceDate)
        {
            string sSQL = "SELECT * FROM Invoices WHERE TotalCost =" + TotalCost + "AND InvoiceDate = #" + InvoiceDate +"#";

            return sSQL;
        }

        /// <summary>
        /// The SQL to select the invoices by the date.
        /// </summary>
        /// <param name="InvoiceDate">The invoice date</param>
        /// <returns>Date specific invoices</returns>
        public string SelectInvoiceByDate(string InvoiceDate)
        {
            string sSQL = "SELECT * FROM Invoices WHERE InvoiceDate = " + "#"+InvoiceDate+"#";

            return sSQL;

        }






    }
}
