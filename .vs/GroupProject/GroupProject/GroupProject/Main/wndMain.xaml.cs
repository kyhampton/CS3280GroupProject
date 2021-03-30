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

        private void itemSearch_Click(object sender, RoutedEventArgs e)
        {
            searchWindow = new wndSearch();

            this.Hide();

            searchWindow.ShowDialog();
            
            this.Show();
        }

        private void itemItems_Click(object sender, RoutedEventArgs e)
        {
            itemsWindow = new wndItems();

            this.Hide();

            itemsWindow.ShowDialog();

            this.Show();
        }
    }
}
