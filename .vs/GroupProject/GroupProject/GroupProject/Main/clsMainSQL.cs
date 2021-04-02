using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Main
{
    class clsMainSQL
    {
        /// <summary>
        /// This will Update an Invoice
        /// </summary>
        /// <returns></returns>
        public string UpdateInvoices(string TotalCost, string InvoiceNum)
        {
            string sSQL = "Update Invoices SET TotalCost ="+TotalCost+" WHERE InvoiceNum = "+InvoiceNum;
            return sSQL;
        }
        /// <summary>
        /// This will Delete Selected Items
        /// </summary>
        /// <returns></returns>
        public string DeleteLineItems(string InvoiceNum)
        {
            string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = "+InvoiceNum;
            return sSQL;
        }
        /// <summary>
        /// This will Delete Selected Invoices
        /// </summary>
        /// <returns></returns>
        public string DeleteInvoices(string InvoiceNum)
        {
            string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = "+InvoiceNum;
            return sSQL;
        }
        /// <summary>
        /// This will Insert a new Set of Items and Attach it to the corresponding InvoiceNum
        /// </summary>
        /// <returns></returns>
        public string InsertLineItems(string InvoiceNum, string LineItemNum, string ItemCode)
        {
            string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) " +
                "VALUES ("+InvoiceNum+", "+LineItemNum+", "+ItemCode+")";
            return sSQL;
        }
        /// <summary>
        /// This will insert a new Invoice into the Database
        /// </summary>
        /// <returns></returns>
        public string InsertInvoices(string InvoiceDate, string TotalCost)
        {
            string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost)" +
                "VALUES (#"+InvoiceDate+"#, "+TotalCost+")";
            return sSQL;
        }
        /// <summary>
        /// This will Select and return Invoice Data from the DB
        /// </summary>
        /// <returns></returns>
        public string SelectInvoice(string InvoiceNum)
        {
            string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost " +
                "FROM Invoices WHERE InvoiceNum ="+InvoiceNum;
            return sSQL;
        }
        /// <summary>
        /// This will Select and Return Items from the DB
        /// </summary>
        /// <returns></returns>
        public string SelectItems()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost " +
                "FROM ItemDesc";
            return sSQL;
        }
        /// <summary>
        /// This will Select and Return The InvoiceNum and corresponding ItemNums
        /// </summary>
        /// <returns></returns>
        public string SelectLineItems(string InvoiceNum)
        {
            string sSQL = "SELECT LineItems.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost " +
                "FROM LineItems, ItemDesc WHERE LineItems.ItemCode = ItemDesc.ItemCode AND " +
                "LineItems.InvoiceNum = "+InvoiceNum;
            return sSQL;
        }
    }
}