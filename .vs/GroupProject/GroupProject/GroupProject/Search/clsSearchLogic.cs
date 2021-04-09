using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Search
{
    public class clsSearchLogic
    {
        /// <summary>
        /// The variable to run SQL statements.
        /// </summary>
        clsDataAccess dt = new clsDataAccess();

        /// <summary>
        /// Holds the result of the getInvoices query.
        /// </summary>
        ObservableCollection<clsInvoice> result;

        /// <summary>
        /// Runs the provided SQL string and fills the invoice variable with the results.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public ObservableCollection<clsInvoice> getInvoices(string sSQL)
        {
            try
            {
                DataSet ds = new DataSet();

                result = new ObservableCollection<clsInvoice>();
                clsInvoice invoice;

                int numRows = 0;

                ds = dt.ExecuteSQLStatement(sSQL, ref numRows);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    invoice = new clsInvoice();
                    invoice.InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    invoice.InvoiceDate = ds.Tables[0].Rows[i][1].ToString();
                    invoice.TotalCost = Convert.ToInt32(ds.Tables[0].Rows[i][2]);

                    result.Add(invoice);


                }
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return result;
        }

        /// <summary>
        /// Gets the invoices numbers to fill the combobox
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> getInvoiceNums()
        {
            var InvoiceNums = from item in result
                              select item.InvoiceNum;

            return InvoiceNums;

        }

        /// <summary>
        /// Gets the invoice dates to fill the combo box.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> getInvoiceDates()
        {
            var InvoiceDates = (from item in result
                               select item.InvoiceDate).Distinct();

            return InvoiceDates;

        }


        /// <summary>
        /// Gets the invoice costs to fill th combo box.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> getInvoiceCosts()
        {
            var TotalCosts = (from item in result
                              orderby item.TotalCost
                              select item.TotalCost).Distinct();

            return TotalCosts;

        }

    }
}
