using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject.Items
{
    /// <summary>
    /// Stores SQL statements to modify a database.
    /// </summary>
    public class clsItemsSQL
    {
        /// <summary>
        /// Returns a SQL statement to selects all the availalbe items.
        /// </summary>
        /// <returns>All data from the list of items</returns>
        public string SelectAllItems()
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc";

            return sSQL;
        }

        /// <summary>
        /// Returns a SQL statement to selects a specific item from the list.
        /// </summary>
        /// <param name="InvoiceNum"></param>
        /// <param name="ItemCode"></param>
        /// <returns>A specific item from the list of items</returns>
        public string SelectSpecificItem(string InvoiceNum, string ItemCode)
        {
            string sSQL = "SELECT distinct(" + InvoiceNum + ") FROM LineItems WHERE ItemCode = " + ItemCode;

            return sSQL;
        }
        /// <summary>
        /// Returns a SQL statement that gets a specific item's details
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public string SelectItemInformation(string ItemCode)
        {
            string sSQL = "SELECT ItemCode, ItemDesc, Cost FROM ItemDesc WHERE ItemCode = '" + ItemCode + "'";

            return sSQL;
        }

        /// <summary>
        /// Returns a SQL statement to updates the description & cost of an item.
        /// </summary>
        /// <param name="Description"></param>
        /// <param name="Cost"></param>
        /// <param name="ItemCode"></param>
        /// <returns>An updated description / cost of an item</returns>
        public string UpdateItemDescription(string ItemCode, string ItemDesc, string Cost)
        {
            string sSQL = "UPDATE ItemDesc SET ItemDesc = '" + ItemDesc + "', Cost = " + Cost + " WHERE ItemCode = '" + ItemCode +"'";

            return sSQL;
        }

        /// <summary>
        /// Returns a SQL statement to add a new item to the list of items.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <param name="ItemDesc"></param>
        /// <param name="Cost"></param>
        /// <returns>A new item</returns>
        public string CreateItem(string ItemCode, string ItemDesc, string Cost)
        {
            string sSQL = "INSERT INTO ItemDesc (ItemCode, ItemDesc, Cost) VALUES ('" + ItemCode + "', '" + ItemDesc + "', " + Cost + ")";

            return sSQL;
        }

        /// <summary>
        /// Returns a SQL statement to delete an item from the list of items.
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        public string DeleteItem(string ItemCode)
        {
            string sSQL = "DELETE FROM ItemDesc WHERE ItemCode = '" + ItemCode + "'";

            return sSQL;
        }
        /// <summary>
        /// Forms a SQL statement to get all data from LineItems
        /// </summary>
        /// <returns></returns>
        public string GetLineItems()
        {
            string sSQL = "SELECT InvoiceNum, LineItemNum, ItemCode FROM LineItems";
            return sSQL;
        }
    }
}
