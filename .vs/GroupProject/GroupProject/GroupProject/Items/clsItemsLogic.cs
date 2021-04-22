using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    public class clsItemsLogic
    {
        #region Variables
        /// <summary>
        /// The variable to run SQL statements.
        /// </summary>
        clsDataAccess da = new clsDataAccess();

        /// <summary>
        /// Holds the result of the getInvoices query.
        /// </summary>
        List<clsItems> items;
        #endregion
        #region Methods
        /// <summary>
        /// Runs the provided SQL string and fills the invoice variable with the results.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public List<clsItems> getItems(string sSQL)
        {
            try
            {
                DataSet ds = new DataSet();

                items = new List<clsItems>();
                clsItems item;

                int numRows = 0;

                ds = da.ExecuteSQLStatement(sSQL, ref numRows);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    item = new clsItems();
                    item.ItemCode = ds.Tables[0].Rows[i][0].ToString();
                    item.ItemDesc = ds.Tables[0].Rows[i][1].ToString();
                    item.ItemCost = Convert.ToDouble(ds.Tables[0].Rows[i][2]);

                    items.Add(item);


                }

                return items;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public List<clsLineItems>GetLineItems(string sSQL)
        {
            try
            {
                DataSet ds = new DataSet();

                List<clsLineItems> result = new List<clsLineItems>();
                clsLineItems LineItem;

                int numRows = 0;

                ds = da.ExecuteSQLStatement(sSQL, ref numRows);

                for (int i = 0; i < numRows; i++)
                {
                    LineItem = new clsLineItems();
                    LineItem.InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    LineItem.LineItemNum = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                    LineItem.ItemCode = ds.Tables[0].Rows[i][2].ToString();

                    result.Add(LineItem);


                }
                return result;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

    }

}

