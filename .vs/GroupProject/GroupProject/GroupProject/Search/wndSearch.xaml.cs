using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GroupProject.Search
{
    /// <summary>
    /// Interaction logic for wndSearch.xaml
    /// </summary>
    public partial class wndSearch : Window
    {
        /// <summary>
        /// The selected Invoice Number.
        /// </summary>
        public int InvoiceNum { get; set; }

        /// <summary>
        /// The variable that contains the SQL for any statements.
        /// </summary>
        clsSearchSQL searchSQL;

        /// <summary>
        /// The variable that holds the business logic for the search screen.
        /// </summary>
        clsSearchLogic searchLogic;
        public wndSearch()
        {
            try
            {
                InitializeComponent();

                searchLogic = new clsSearchLogic();
                searchSQL = new clsSearchSQL();
                ObservableCollection<clsInvoice> invoices = searchLogic.getInvoices(searchSQL.SelectAllInvoices());
                dgInvoices.ItemsSource = invoices;

                cboNum.ItemsSource = searchLogic.getInvoiceNums();
                cboDate.ItemsSource = searchLogic.getInvoiceDates();
                cboCost.ItemsSource = searchLogic.getInvoiceCosts();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        #region Buttons
        /// <summary>
        /// Saves the selected invoice number in the InvoiceNum variable for the main screen to access.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            clsInvoice invoice = (clsInvoice)dgInvoices.SelectedCells[0].Item;
            InvoiceNum = invoice.InvoiceNum;
            this.Close();
        }

        /// <summary>
        /// Cancel and go back to the main screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                InvoiceNum = -1;
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Changes the results of the results datagrid depending on what each combo box has selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ObservableCollection<clsInvoice> invoices;

                // select on invoice Num
                if (cboNum.SelectedIndex != -1 && cboDate.SelectedIndex == -1 && cboCost.SelectedIndex == -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceData(cboNum.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }

                // select on invoice num and date
                if (cboNum.SelectedIndex != -1 && cboDate.SelectedIndex != -1 && cboCost.SelectedIndex == -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceNumByDate(cboNum.SelectedItem.ToString(), cboDate.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }

                // select on invoice num and cost
                if (cboNum.SelectedIndex != -1 && cboDate.SelectedIndex == -1 && cboCost.SelectedIndex != -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceByNumAndCost(cboNum.SelectedItem.ToString(), cboCost.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }

                // select on invoice num and date and cost
                if (cboNum.SelectedIndex != -1 && cboDate.SelectedIndex != -1 && cboCost.SelectedIndex != -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceByDateAndCost(cboNum.SelectedItem.ToString(), cboDate.SelectedItem.ToString(), cboCost.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }

                // select on invoice cost
                if (cboCost.SelectedIndex != -1 && cboDate.SelectedIndex == -1 && cboNum.SelectedIndex == -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceByCost(cboCost.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }

                // select on invoice cost and date
                if (cboNum.SelectedIndex == -1 && cboDate.SelectedIndex != -1 && cboCost.SelectedIndex != -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceByCostAndDate(cboCost.SelectedItem.ToString(), cboDate.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }
                // select on invoice date
                if (cboNum.SelectedIndex == -1 && cboDate.SelectedIndex != -1 && cboCost.SelectedIndex == -1)
                {
                    invoices = searchLogic.getInvoices(searchSQL.SelectInvoiceByDate(cboDate.SelectedItem.ToString()));
                    dgInvoices.ItemsSource = invoices;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }

        /// <summary>
        /// Resets the selections on the page. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cboNum.SelectedIndex = -1;
                cboDate.SelectedIndex = -1;
                cboCost.SelectedIndex = -1;
                dgInvoices.ItemsSource = searchLogic.getInvoices(searchSQL.SelectAllInvoices());
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }



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
    }
}
