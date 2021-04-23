using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
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

        /// <summary>
        /// Object to access ItemsLogic class
        /// </summary>
        clsItemsLogic itemsLogic;
        /// <summary>
        /// Object to access itemsSQL class
        /// </summary>
        clsItemsSQL itemsSQL;
        /// <summary>
        /// Object to access the database
        /// </summary>
        clsDataAccess DA;
        /// <summary>
        /// Object to hold all of the items.
        /// </summary>
        List<clsItems> Items;
        /// <summary>
        /// Object to hold the list of line items
        /// </summary>
        List<clsLineItems> LineItem;
        /// <summary>
        /// Array to hold the values of the txt boxes
        /// </summary>
        private string[] TextBoxValues = new string[3];

        #endregion
        public wndItems()
        {
            InitializeComponent();
            try
            {
                //Initialize objects to access respective classes
                itemsLogic = new clsItemsLogic();
                itemsSQL = new clsItemsSQL();
                DA = new clsDataAccess();
                LineItem = itemsLogic.GetLineItems(itemsSQL.GetLineItems());

                FillBox();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #region Buttons

        /// <summary>
        /// Inserts a new item into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Verify none of the item codes are currently being used by an invoice
                foreach (var element in Items)
                {
                    if (element.ItemCode == txtItemCode.Text)
                    {
                        MessageBox.Show("You cannot add this item, it is already exists", "Cannot add item", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                if (string.IsNullOrWhiteSpace(txtItemCode.Text) || string.IsNullOrWhiteSpace(txtItemDesc.Text) || string.IsNullOrWhiteSpace(txtItemCost.Text))
                {
                    MessageBox.Show("Please enter information for the item.", "Cannot add item", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                //Make sure an item is selected
                else if (!string.IsNullOrWhiteSpace(txtItemCode.Text))
                {
                    //Creates a new item in the database.
                    DA.ExecuteNonQuery(itemsSQL.CreateItem(txtItemCode.Text, txtItemDesc.Text, txtItemCost.Text));
                    FillBox();
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Modify an existing item in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBoxValues[1] = txtItemDesc.Text;
                TextBoxValues[2] = txtItemCost.Text;
                //Enables the option to save / cancel changes
                btnSaveEdit.IsEnabled = true;
                btnCancelEdit.IsEnabled = true;
                //Disables add / delete buttons
                btnAddItems.IsEnabled = false;
                btnDeleteItem.IsEnabled = false;
                //Remove the ability to change the selected item's code
                txtItemCode.IsEnabled = false;
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Saves the changes when the edit button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Disables the option to save / cancel changes
                btnSaveEdit.IsEnabled = false;
                btnCancelEdit.IsEnabled = false;
                //Enables add / delete buttons
                btnAddItems.IsEnabled = true;
                btnDeleteItem.IsEnabled = true;
                //Add the ability to change the selected item's code
                txtItemCode.IsEnabled = true;

                //Object to hold the selected item from dgItemList
                clsItems item = (clsItems)dgItemList.SelectedItem;
                //Check if the item is not empty
                if (!(string.IsNullOrWhiteSpace(item.ItemCode)))
                {
                    //Verifies the user entered all the information
                    if (string.IsNullOrWhiteSpace(txtItemCode.Text) || string.IsNullOrWhiteSpace(txtItemCode.Text) || string.IsNullOrWhiteSpace(txtItemCode.Text))
                    {
                        MessageBox.Show("Please enter information for the item.", "Cannot add item", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        //Updates the item in the DB
                        DA.ExecuteNonQuery(itemsSQL.UpdateItemDescription(txtItemCode.Text, txtItemDesc.Text, txtItemCost.Text));
                        //Updates the list of items
                        FillBox();
                        //Resets the selected item
                        txtItemCode.Text = "";
                        txtItemDesc.Text = "";
                        txtItemCost.Text = "";
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Disregards the edit's made
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Disables the option to save / cancel changes
                btnSaveEdit.IsEnabled = false;
                btnCancelEdit.IsEnabled = false;
                //Enables add / delete buttons
                btnAddItems.IsEnabled = true;
                btnDeleteItem.IsEnabled = true;
                //Add the ability to change the selected item's code
                txtItemCode.IsEnabled = true;

                //Set the txtBox's with  the previous values before the edit
                txtItemDesc.Text = TextBoxValues[1];
                txtItemCost.Text = TextBoxValues[2];
                //Clear the text Values for future use
                TextBoxValues[1] = "";
                TextBoxValues[2] = "";
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Deletes an item from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LineItem = itemsLogic.GetLineItems(itemsSQL.GetLineItems());
                //Verify none of the item codes are currently being used by an invoice
                foreach (var element in LineItem)
                {
                    if(element.ItemCode == txtItemCode.Text)
                    {
                        MessageBox.Show("You cannot delete this item, it is invoice #" + element.InvoiceNum.ToString(), "Cannot delete item", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                //Execute the delete statement if none of the elements are in an invoice
                DA.ExecuteNonQuery(itemsSQL.DeleteItem(txtItemCode.Text));
                //Empty the current items out of the text boxes
                txtItemCode.Text = "";
                txtItemDesc.Text = "";
                txtItemCost.Text = "";
                //Updates the Data grid
                FillBox();

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Closes the current window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Close the current window
                this.Close();
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #endregion

        #region User Input

        /// <summary>
        /// Only allows the user to enter A-Z
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
                    {
                        //No other keys allowed besides numbers, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Checks the user entered 0-9 & '.'
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCost_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //Allows only #'s and '.' to be entered
                if (!(int.TryParse(e.Text, out int result) || e.Text == "."))
                {
                        e.Handled = true;
                }
                //Prevents more than one '.' from being entered.
                if (e.Text == "." && (sender as TextBox).Text.IndexOf('.') > -1)
                {
                    e.Handled = true;
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Prevents the user from entering values smaller than hundrethds
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                //Checks that a '.' has already been entered. Verifies # only goes to hundredths, wraps around to add larger values 'feature'
                if (txtItemCost.Text.Contains('.') && txtItemCost.Text.Substring(txtItemCost.Text.IndexOf('.')).Length > 3)
                {
                    txtItemCost.Text = txtItemCost.Text.Remove(txtItemCost.Text.Length - 1);
                    e.Handled = true;
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Checks user input for spaces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtItemCost_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try {
                //Disallows the user to enter spaces
                if (e.Key == Key.Space)
                {
                    e.Handled = true;
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates the currently selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgItemList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Makes sure the user cannot edit / delete items.
                btnEditItem.IsEnabled = false;
                btnSaveEdit.IsEnabled = false;
                btnCancelEdit.IsEnabled = false;
                btnDeleteItem.IsEnabled = false;
                //Reenable the Item code box if it was previously being edited.
                txtItemCode.IsEnabled = true;

                //Object to hold the selected item from dgItemList
                clsItems item = (clsItems)dgItemList.SelectedItem;

                //Makes sure the item exists
                if (item != null)
                {
                    //Enable the user to edit / delete the selected item
                    btnEditItem.IsEnabled = true;
                    btnDeleteItem.IsEnabled = true;
                    //Fills the text boxes with the appropriate info
                    txtItemCode.Text = item.ItemCode;
                    txtItemDesc.Text = item.ItemDesc;
                    txtItemCost.Text = item.ItemCost.ToString();
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Fills the dgItemList with all the items in the db
        /// </summary>
        private void FillBox()
        {
            try
            {
                //Fill the box with all the items
                Items = itemsLogic.getItems(itemsSQL.SelectAllItems());
                dgItemList.ItemsSource = Items;
                //Sorts the columns by ItemCode a-z
                dgItemList.Items.SortDescriptions.Add(new SortDescription("ItemCode", ListSortDirection.Ascending));
            }
            catch (Exception ex)
            {
                //Just throw the exception
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Error Handling
        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion

    }
}
