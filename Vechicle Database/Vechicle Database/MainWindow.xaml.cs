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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Cars> CarsList;
        public static ObservableCollection<Motorcycles> MotorcyclesList;
        public static ObservableCollection<Trucks> TrucksList;
        public static int Selection;
        public static int Page;
        public MainWindow()
        {
            InitializeComponent();
            CarsList = new ObservableCollection<Cars>();
            MotorcyclesList = new ObservableCollection<Motorcycles>();
            TrucksList = new ObservableCollection<Trucks>();
            Main.Content = new CarsPage(CarsList);
            DataContext = this;
            VehicleTypeComboBox.ItemsSource = Enum.GetValues(typeof(Enums.VehicleType));
            VehicleTypeComboBox.SelectedIndex = 0;
            DataOperations.Load();
            Page = 1;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddDialogue.IsOpen = true;
        }

        private void Motorcycles_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new MotorcyclesPage(MotorcyclesList);
            Page = 2;
        }

        private void Cars_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CarsPage(CarsList);
            Page = 1;
        }

        private void PopupCancelButton_Click(object sender, RoutedEventArgs e)
        {
            AddDialogue.IsOpen = false;

        }
        private void PopUpAddButton_Click(object sender, RoutedEventArgs e)
        {
            if (VehicleTypeComboBox.SelectedIndex == 0)
            {
                Main.Content = new CarsAdd();
            }
            if (VehicleTypeComboBox.SelectedIndex == 1)
            {
                Main.Content = new MotorcyclesAdd();
            }
            if (VehicleTypeComboBox.SelectedIndex == 2)
            {
                Main.Content = new TrucksAdd();
            }
            AddDialogue.IsOpen = false;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Page == 1)
                try
                {
                    CarsList.RemoveAt(Selection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Select record to delete.", "Vechicle Deletion");
                }
            if (Page == 2)
                try
                {
                    MotorcyclesList.RemoveAt(Selection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Select record to delete.", "Vechicle Deletion");
                }
            if (Page == 3)
                try
                {
                    TrucksList.RemoveAt(Selection);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Select record to delete.", "Vechicle Deletion");
                }
        }

        private void Trucks_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TrucksPage(TrucksList);
            Page = 3;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DataOperations.Save(CarsList);
            DataOperations.Save(MotorcyclesList);
            DataOperations.Save(TrucksList);
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            DataOperations.Load();
        }
    }
}
