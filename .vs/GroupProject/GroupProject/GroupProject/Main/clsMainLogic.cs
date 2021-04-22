using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    public class clsMainLogic
    {
        #region Variables
        clsDataAccess db = new clsDataAccess();
        clsMainSQL sql = new clsMainSQL();
        List<clsInvoice> invoiceResult = new List<clsInvoice>();
        List<clsItems> itemsResult = new List<clsItems>();
        List<clsItems> itemsSearchByCode = new List<clsItems>();
        List<clsLineItems> lineItemsResult = new List<clsLineItems>();
        #endregion
        #region Get Logic
        /// <summary>
        /// Runs the provided SQL string and fills the items variable with the results;
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public List<clsItems> getItems()
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;

                var query = sql.SelectItems();

                clsItems items;

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    items = new clsItems();
                    items.ItemCode = ds.Tables[0].Rows[i][0].ToString();
                    items.ItemDesc = ds.Tables[0].Rows[i][1].ToString();
                    items.ItemCost = Convert.ToDouble(ds.Tables[0].Rows[i][2].ToString());

                    itemsResult.Add(items);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return itemsResult;
        }

        public string getItemCode(string itemDesc)
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;
                var query = sql.GetItemCode(itemDesc);

                ds = db.ExecuteSQLStatement(query, ref iRef);

                string itemCode = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                return itemCode;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public List<clsLineItems> getInvoiceItems(string invoiceNum)
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;
                var query = sql.SelectLineItems(invoiceNum);

                ds = db.ExecuteSQLStatement(query, ref iRef);

                clsLineItems li;

                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    li = new clsLineItems();
                    li.InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    li.LineItemNum = Convert.ToInt32(ds.Tables[0].Rows[i][1]);
                    li.ItemCode = ds.Tables[0].Rows[i][2].ToString();

                    lineItemsResult.Add(li);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return lineItemsResult;
        }

        public double getItemCost(string itemCode)
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;
                var query = sql.GetItemCost(itemCode);

                ds = db.ExecuteSQLStatement(query, ref iRef);

                string itemCost = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                double cost;
                Double.TryParse(itemCost, out cost);

                return cost;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public List<clsItems> GetItemsByCode(string itemCode)
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;
                var query = sql.GetItemDesc(itemCode);

                ds = db.ExecuteSQLStatement(query, ref iRef);

                clsItems items = new clsItems();

                items.ItemDesc = ds.Tables[0].Rows[0].ItemArray[0].ToString();

                itemsSearchByCode.Add(items);

                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    items = new clsItems();
                //    items.ItemDesc = ds.Tables[0].Rows[i][0].ToString();
                //    itemsResult.Add(items);
                //}
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            return itemsSearchByCode;
        }

        public List<clsInvoice> GetAllInvoices()
        {
            try
            {
                DataSet ds = new DataSet();
                int iRef = 0;
                var query = sql.SelectAllInvoices();

                clsInvoice invoice;

                ds = db.ExecuteSQLStatement(query, ref iRef);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    invoice = new clsInvoice();
                    invoice.InvoiceNum = Convert.ToInt32(ds.Tables[0].Rows[i][0]);
                    invoice.InvoiceDate = ds.Tables[0].Rows[i][1].ToString();
                    invoice.TotalCost = Convert.ToInt32(ds.Tables[0].Rows[i][2]);

                    invoiceResult.Add(invoice);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return invoiceResult;

        }
        #endregion
        #region Insert Logic
        public void InsertLineItem(string invoiceNum, string lineItemNum, string itemCode)
        {
            try
            {
                var query = sql.InsertLineItems(invoiceNum, lineItemNum, itemCode);

                db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion
        #region Update Logic
        public void UpdateInvoiceTotal(string invoiceNum, string total)
        {
            try
            {
                var query = sql.UpdateInvoices(total, invoiceNum);

                db.ExecuteNonQuery(query);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #region Delete Logic
        /// <summary>
        /// Method to Delete Line Items from DB
        /// </summary>
        /// <param name="invoiceNum"></param>
        public void DeleteLineItems(string invoiceNum)
        {
            try
            {
                db.ExecuteNonQuery(sql.DeleteLineItems(invoiceNum));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public void DeleteItemFromInvoice(string invoiceNum, string itemCode)
        {
            try
            {
                db.ExecuteNonQuery(sql.DeleteItemFromInvoice(invoiceNum, itemCode));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// Method to Delete Invoices from DB
        /// </summary>
        /// <param name="invoiceNum"></param>
        public void DeleteInvoice(string invoiceNum)
        {
            try
            {
                db.ExecuteNonQuery(sql.DeleteInvoices(invoiceNum));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #region Methods
        public void SaveInvoice(string date, string total)
        {
            try
            {
                db.ExecuteNonQuery(sql.InsertInvoices(date, total));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        public string GenerateInvoiceID()
        {
            try
            {
                int iRet = 0;
                int mID = 0;

                DataSet ds = new DataSet();

                var query = sql.GenerateInvoiceID();

                ds = db.ExecuteSQLStatement(query, ref iRet);
                Int32.TryParse(ds.Tables[0].Rows[0].ItemArray[0].ToString(), out mID);
                string newID = (mID).ToString();

                return newID;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        public string GenerateLineItemNum(string invoiceNum)
        {
            try
            {
                DataSet ds = new DataSet();
                int iRet = 0;
                int mID = 0;

                var query = sql.GenerateLineItemNum(invoiceNum);

                ds = db.ExecuteSQLStatement(query, ref iRet);
                Int32.TryParse(ds.Tables[0].Rows[0].ItemArray[0].ToString(), out mID);
                mID++;
                string newNum = (mID).ToString();
                
                return newNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }

}
