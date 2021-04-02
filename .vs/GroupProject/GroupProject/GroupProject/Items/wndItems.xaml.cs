using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GroupProject.Items
{
    /// <summary>
    /// Interaction logic for wndItems.xaml
    /// </summary>
    public partial class wndItems : Window
    {
        #region Variables

        //Declare a clsItemsLogic object
        //Declare a clsItemsSQL object

        #endregion
        public wndItems()
        {
            InitializeComponent();

            //Initalize clsItemsLogic object.
            //Initalize clsItemsSQL object.

        }

        #region Buttons

        /// <summary>
        /// Inserts a new item into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            //Verify the user's input in the txtBoxes is complete
            //Run the SQL command to Insert a new item using clsItemsLogic object.
        }

        /// <summary>
        /// Modify an existing item in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            //Accept the currently selected item from the text boxes
            //Run SQL command to UPDATE the database using clsItemsLogic object.
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            //Take in the current selected item from the text boxes

            //Verify the item is not already in an invoice
            //If the item is an invoice show a warning with the current invoice #
            //Else delete the currently selected item from the DB using SQL command using clsItemsLogic object.
        }

        /// <summary>
        /// Closes the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Close the current window
            this.Close();
        }

        #endregion

        #region User Input

        /// <summary>
        /// Verifies User's input is within an acceptable range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            //try
            //{
            //    //Only allow letters to be entered
            //    if (!(e.Key >= Key.A && e.Key <= Key.Z))
            //    {
            //        //Allow the user to use the backspace, delete, tab and enter
            //        if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
            //        {
            //            //No other keys allowed besides numbers, backspace, delete, tab, and enter
            //            e.Handled = true;
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
            //                MethodInfo.GetCurrentMethod().Name, ex.Message);
            //}
        }

        /// <summary>
        /// Verifies user's input is within an acceptable range of #'s
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Update to only allow #'s

            //try
            //{
            //    //Only allow letters to be entered
            //    if (!(e.Key >= Key.A && e.Key <= Key.Z))
            //    {
            //        //Allow the user to use the backspace, delete, tab and enter
            //        if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
            //        {
            //            //No other keys allowed besides numbers, backspace, delete, tab, and enter
            //            e.Handled = true;
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
            //                MethodInfo.GetCurrentMethod().Name, ex.Message);
            //}
        }

        /// <summary>
        /// Updates the currently selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Update the txt boxes to show the currently selected item.
        }
        #endregion
    }
}
