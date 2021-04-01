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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupProject.Items;
using GroupProject.Search;

namespace GroupProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        wndItems itemsWindow;

        wndSearch searchWindow;

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

        }
        /// <summary>
        /// Click on Search Button and it will navigate you to the 
        /// Search Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemSearch_Click(object sender, RoutedEventArgs e)
        {
            searchWindow = new wndSearch();

            this.Hide();

            searchWindow.ShowDialog();

            this.Show();
        }
        /// <summary>
        /// Click on this button and it will navigate you to the Edit Items Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void itemItems_Click(object sender, RoutedEventArgs e)
        {
            itemsWindow = new wndItems();

            this.Hide();

            itemsWindow.ShowDialog();

            this.Show();
        }
        /// <summary>
        /// Insert data into Invoice DB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewInvoice_Click(object sender, RoutedEventArgs e)
        {
            //This will pull up the form to add new data to the invoice logic

            //InsertInvoices()
            //InsertLineItems()
        }
        /// <summary>
        /// Edit an existing Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInvoice_Click(object sender, RoutedEventArgs e)
        {
            //UpdateInvoices()
        }
        /// <summary>
        /// This will delete an existing Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteInvoice_Click(object sender, RoutedEventArgs e)
        {
            //DeleteInvoices()
            //DeleteLineItems()
        }
        /// <summary>
        /// List of Items Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectItems()
            //Pull Items from DB
        }
        //Selects Items to Insert Into DB for Invoices
        private void btnAddItem_Click(object sender, RoutedEventArgs e)
        {
            //InsertItems()

        }
        /// <summary>
        /// Displays a list of all items that have been added to Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstbxItemsAdded_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //SelectItems()
        }
        /// <summary>
        /// Removes Items from Invoice
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            //DeleteLineItems()
        }
    }
