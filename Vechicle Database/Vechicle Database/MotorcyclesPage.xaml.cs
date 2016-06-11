using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Vechicle_Database
{
    /// <summary>
    /// Interaction logic for MotorcyclesPage.xaml
    /// </summary>
    public partial class MotorcyclesPage : Page
    {
        public ObservableCollection<Motorcycles> MotorcyclesList { get; set; }
        public MotorcyclesPage(ObservableCollection<Motorcycles> MotorcyclesList)
        {
            InitializeComponent();
            this.DataContext = this;
            this.MotorcyclesList = MotorcyclesList;
        }
        private void ListView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MainWindow.Selection = ListView1.SelectedIndex;
        }
    }
}
