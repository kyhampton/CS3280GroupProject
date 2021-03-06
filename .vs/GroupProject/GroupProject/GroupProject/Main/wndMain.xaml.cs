﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupProject.Items;
using GroupProject.Main;
using GroupProject.Search;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        /// <summary>
        /// Item window object to create the window
        /// </summary>
        wndItems itemsWindow;
        /// <summary>
        /// Search window object to create the window.
        /// </summary>
        wndSearch searchWindow;

        /// <summary>
        /// Main Logic object
        /// </summary>
        clsMainLogic ml;

        /// <summary>
        /// Main SQL object
        /// </summary>
        clsMainSQL sql;

        /// <summary>
        /// InvoiceNum from main window.
        /// </summary>
        public string InvoiceNum;

        /// <summary>
        /// Generate an ID for new Invoices
        /// </summary>
        private string newID;

        /// <summary>
        /// Create a date for a new Invoice
        /// </summary>
        private string invoiceDate;

        /// <summary>
        /// Current Selected Item
        /// </summary>
        public string curItem;
        /// <summary>
        /// Current Selected Added Item
        /// </summary>
        public string addedItem;
        /// <summary>
        /// List of Added items
        /// </summary>
        public List<String> addeditems = new List<String>();
        /// <summary>
        /// Running Total of Added Items
        /// </summary>
        double total = 0;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for Main Window
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                ml = new clsMainLogic();
                //Populate Items ComboBox
                cmbInvoiceItem.ItemsSource = ml.getItems().Select(a => a.ItemDesc);

                //Populate DataGrid with Invoices
                List<clsInvoice> invoice = ml.GetAllInvoices();
                dgInvoices.ItemsSource = invoice;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Control Menu
        /// <summary>
        /// Click on Search Button and it will navigate you to the 
        /// Search Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                searchWindow = new wndSearch();

                this.Hide();

                searchWindow.ShowDialog();
                int num;
                num = searchWindow.InvoiceNum;

                //find the invoice in the datagrid
                int i = 0;
                if (num != -1)
                {
                    foreach (var item in dgInvoices.Items)
                    {
                        clsInvoice invoice = (clsInvoice)item;
                        if (invoice.InvoiceNum == num)
                        {
                            break;
                        }
                        i++;
                    }

                    dgInvoices.SelectedIndex = i;
                }
                this.Show();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// Click on this button and it will navigate you to the Edit Items Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                itemsWindow = new wndItems();

                this.Hide();

                itemsWindow.ShowDialog();

                //Update all dropdowns to reflect any changes (dropdown.itemsSource =)

                this.Show();

                cmbInvoiceItem.ClearValue(ItemsControl.ItemsSourceProperty);
                cmbInvoiceItem.ItemsSource = ml.getItems().Select(a => a.ItemDesc);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        /// <summary>
        /// On Click Main Window Closes and Program Ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        #endregion

        #region Buttons
        /// <summary>
        /// Insert data into Invoice DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enable textboxes
                tbInvoiceNumber.IsEnabled = true;
                dpInvoiceDate.IsEnabled = true;
                txtbxTotalCost.IsEnabled = true;
                cmbInvoiceItem.IsEnabled = true;
                cmbxItemsAdded.IsEnabled = true;

                //Enable Save button
                btnSaveInvoice.IsEnabled = true;

                //Insert Current Date
                dpInvoiceDate.SelectedDate = DateTime.Today;
                ml.SaveInvoice(dpInvoiceDate.SelectedDate.Value.Date.ToShortDateString(), "0");

                //Generate a new Invoice ID
                newID = ml.GenerateInvoiceID();

                //Insert Invoice ID onto Page
                tbInvoiceNumber.Text = newID;

                //Set variable to Current InvoiceNum
                InvoiceNum = newID;

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// Edit an existing Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Enable Buttons
                tbInvoiceNumber.IsEnabled = true;
                dpInvoiceDate.IsEnabled = true;
                txtbxTotalCost.IsEnabled = true;
                cmbInvoiceItem.IsEnabled = true;
                cmbxItemsAdded.IsEnabled = true;

                //Enable Save button
                btnSaveInvoice.IsEnabled = true;

                //disable edit and delete buttons
                btnEditInvoice.IsEnabled = false;
                btnDeleteInvoice.IsEnabled = false;

                //get items from line item 
                List<clsLineItems> i = ml.getInvoiceItems(InvoiceNum);
                List<String> code = i.Select(a => a.ItemCode).ToList();

                List<clsItems> temp = new List<clsItems>();

                foreach (var item in code)
                {
                    temp = ml.GetItemsByCode(item);

                }
                List<String> desc = new List<String>();
                desc = temp.Select(a => a.ItemDesc).ToList();
                addeditems.AddRange(desc);

                cmbxItemsAdded.ItemsSource = addeditems;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        /// <summary>
        /// This will delete an existing Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                clsInvoice invoice = (clsInvoice)dgInvoices.SelectedItem;
                string invoiceNum = invoice.InvoiceNum.ToString();

                ml.DeleteLineItems(invoiceNum);
                ml.DeleteInvoice(invoiceNum);

                dgInvoices.ClearValue(ItemsControl.ItemsSourceProperty);

                //Populate DataGrid with Invoices
                List<clsInvoice> refresh = ml.GetAllInvoices();
                dgInvoices.ItemsSource = refresh;
                //disable Delete and Edit Buttons
                btnDeleteInvoice.IsEnabled = false;
                btnEditInvoice.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }

        /// <summary>
        /// On Click Save button will submit Total to Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInvoice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string t = total.ToString();
                ml.UpdateInvoiceTotal(InvoiceNum, t);

                //clear old data
                dgInvoices.ClearValue(ItemsControl.ItemsSourceProperty);

                //refresh the items in the data grid
                List<clsInvoice> invoice = ml.GetAllInvoices();
                dgInvoices.ItemsSource = invoice;

                tbInvoiceNumber.Text = "TBD";
                dpInvoiceDate.SelectedDate = null;
                txtbxTotalCost.Text = null;

                cmbxItemsAdded.ClearValue(ItemsControl.ItemsSourceProperty);

                tbInvoiceNumber.IsEnabled = false;
                dpInvoiceDate.IsEnabled = false;
                txtbxTotalCost.IsEnabled = false;
                cmbInvoiceItem.IsEnabled = false;
                cmbxItemsAdded.IsEnabled = false;
                //Enable Save button
                btnSaveInvoice.IsEnabled = false;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// Adds a new item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check to make sure item has been selected
                if (curItem.Equals(" ") || curItem.Equals(null)) return;
                //Create variable for Item Description
                string itemDesc = cmbInvoiceItem.SelectedItem.ToString();
                //Add Item to List of Invoice Added Items
                addeditems.Add(itemDesc);

                //Get Item Code from Description
                string itemCode = ml.getItemCode(itemDesc);

                //Add cost of Item to Total
                double cost;
                cost = ml.getItemCost(itemCode);
                total += cost;

                //Get Line Item Number
                string lineItemNum = ml.GenerateLineItemNum(InvoiceNum);
                //Check to make sure it is not 0
                if (lineItemNum.Equals("0") || lineItemNum.Equals(null))
                {
                    lineItemNum = "1";
                }
                //Insert Item into Line Item DB
                ml.InsertLineItem(InvoiceNum, lineItemNum, itemCode);
                //Clear Combo Box and Reload
                cmbxItemsAdded.ClearValue(ItemsControl.ItemsSourceProperty);
                cmbxItemsAdded.ItemsSource = addeditems;
                //Clear Selected Item
                cmbInvoiceItem.SelectedIndex = -1;
                //Change Add Item Button IsEnabled to false
                btnAddItem.IsEnabled = false;

                //Change Total
                txtbxTotalCost.Text = "$ " + String.Format("{0:N2}", total);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        /// <summary>
        /// Removes Items from Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Check to make sure item is selected
                if (addedItem.Equals(" ") || addedItem.Equals(null)) return;
                string itemDesc = cmbxItemsAdded.SelectedItem.ToString();
                //Remove item
                addeditems.Remove(itemDesc);

                string itemCode = ml.getItemCode(itemDesc);
                //Subtract removed item from total
                double cost;
                cost = ml.getItemCost(itemCode);
                total -= cost;
                //Remove Item from Invoice
                ml.DeleteItemFromInvoice(InvoiceNum, itemCode);
                //Clear ComboBox Added Items
                cmbxItemsAdded.ClearValue(ItemsControl.ItemsSourceProperty);
                //Reload Added Items to ComboBox
                cmbxItemsAdded.ItemsSource = addeditems;
                //Clear Selected
                cmbxItemsAdded.SelectedIndex = -1;
                //Disable Remove Button
                btnRemoveItem.IsEnabled = false;

                //Change Total
                txtbxTotalCost.Text = "$ " + String.Format("{0:N2}", total);
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        #endregion

        #region Combo Box
        /// <summary>
        /// Invoice Item on Selection loads curItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbInvoiceItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Take Selected Item and instantiate it into Current Item variable
                ComboBox item = (ComboBox)sender;
                curItem = item.ToString();
                //Enable Add Item to Invoice Button
                btnAddItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Combo Box Items in Invoice loads addedItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbxItemsAdded_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //Take Selected Item and instantiate it into Added Item variable
                ComboBox item = (ComboBox)sender;
                addedItem = item.ToString();
                //Enable Remove Item from Invoice Button
                btnRemoveItem.IsEnabled = true;
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        
        #endregion

        #region Data Grid
        /// <summary>
        /// Data Grid on Selected Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                clsInvoice invoice = (clsInvoice)dgInvoices.SelectedItem;
                //clsItems items = mainLogic.
                if (invoice != null)
                {
                    btnEditInvoice.IsEnabled = true;
                    btnDeleteInvoice.IsEnabled = true;

                    tbInvoiceNumber.Text = invoice.InvoiceNum.ToString();
                    InvoiceNum = invoice.InvoiceNum.ToString();
                    dpInvoiceDate.Text = invoice.InvoiceDate;
                    txtbxTotalCost.Text = "$ " + String.Format("{0:N2}", invoice.TotalCost.ToString());
                    total = invoice.TotalCost;
                }

            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
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