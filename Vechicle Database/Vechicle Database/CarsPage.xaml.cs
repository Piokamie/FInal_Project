using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Vechicle_Database
{
    /// <summary>
    /// Interaction logic for CarsPage.xaml
    /// </summary>
    public partial class CarsPage : Page
    {
        public ObservableCollection<Cars> CarsList { get; set; }
        public CarsPage(ObservableCollection<Cars> CarsList)
        {
            InitializeComponent();
            DataContext = this;
            this.CarsList = CarsList;

        }

        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.Selection = ListView1.SelectedIndex;
        }
    }
}
