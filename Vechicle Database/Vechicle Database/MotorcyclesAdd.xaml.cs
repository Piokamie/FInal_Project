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
    /// Interaction logic for MotorcyclesAdd.xaml
    /// </summary>
    public partial class MotorcyclesAdd : Page
    {
        bool Lock = true;
        public MotorcyclesAdd()
        {
            InitializeComponent();
            MotorcycleType.ItemsSource = Enum.GetValues(typeof(Enums.MotorcycleType));
            MotorcycleType.SelectedIndex = 0;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!Lock)
            {
                Enums.MotorcycleType Type = (Enums.MotorcycleType)Enum.Parse(typeof(Enums.MotorcycleType), this.MotorcycleType.Text);
                MainWindow.MotorcyclesList.Add(new Motorcycles(ManufacturerTextBox.Text, ModelTextBox.Text, ColorTextBox.Text,
                       int.Parse(YearTextBox.Text), int.Parse(KilometerageTextBox.Text), int.Parse(Engine.Text),
                       int.Parse(FuelTextBox.Text), int.Parse(BurnRateTextBox.Text), Type));
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
        private void Engine_LostFocus(object sender, RoutedEventArgs e)
        {
            Lock = DataOperations.ValidateInput(Engine, 0);
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
    }
}
