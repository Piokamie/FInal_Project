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

namespace Vechicle_Database
{
    /// <summary>
    /// Interaction logic for TrucksAdd.xaml
    /// </summary>
    public partial class TrucksAdd : Page
    {
        bool Lock = true;
        public TrucksAdd()
        {
            InitializeComponent();
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!Lock)
            {
                MainWindow.TrucksList.Add(new Trucks(ManufacturerTextBox.Text, ModelTextBox.Text, ColorTextBox.Text,
                       int.Parse(YearTextBox.Text), int.Parse(KilometerageTextBox.Text), int.Parse(Capacity.Text), int.Parse(Mass.Text),
                       int.Parse(FuelTextBox.Text), int.Parse(BurnRateTextBox.Text)));
                NavigationService.GoBack();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ManufacturerTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(ManufacturerTextBox, 1);
        }
        private void ModelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(ModelTextBox, 1);
        }
        private void YearTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(YearTextBox, 0);
        }
        private void KilometerageTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(KilometerageTextBox, 0);
        }
        private void Capacity_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(Capacity, 0);
        }
        private void ColorTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(ColorTextBox, 1);
        }
        private void FuelTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(FuelTextBox, 0);
        }
        private void BurnRateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(BurnRateTextBox, 0);
        }
        private void Mass_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(Mass, 0);
        }
    }
}
