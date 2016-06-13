using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vechicle_Database
{
    static class DataOperations
    {
        public static bool ValidateInput(TextBox Text, int Type)
        {
            if (Type == 0)
            {
                int w;
                if (!int.TryParse(Text.Text, out w) || Text.Text == null)
                {
                    Text.Background = Brushes.Red;
                    return true;
                }
                else
                {
                    Text.Background = Brushes.White;
                    return false;
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Text.Text))
                {
                    Text.Background = Brushes.Red;
                    return true;
                }
                else
                {
                    Text.Background = Brushes.White;
                    return false;
                }

            }
        }

        public static void Save(ObservableCollection<Cars> List)
        {
            StreamWriter Writer = new StreamWriter("Cars.svdb");
            foreach (Cars item in List)
            {
                Writer.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                    item.Manufacturer,item.Model, item.Color, item.Year,item.Kilometerage,item.Passengers, item.DoorsNumber
                    , item.FuelCapacity,item.BurnRate));        
            }
            Writer.Close();
        }

        public static void Save(ObservableCollection<Motorcycles> List)
        {
            StreamWriter Writer = new StreamWriter("Motorcycles.svdb");
            foreach (Motorcycles item in List)
            {
                Writer.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                    item.Manufacturer, item.Model, item.Color, item.Year, item.Kilometerage, item.Engine,
                    item.FuelCapacity, item.BurnRate, item.MotorcycleType));
            }
            Writer.Close();
        }
        public static void Save(ObservableCollection<Trucks> List)
        {
            StreamWriter Writer = new StreamWriter("Trucks.svdb");
            foreach (Trucks item in List)
            {
                Writer.WriteLine(string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8}",
                    item.Manufacturer, item.Model, item.Color, item.Year, item.Kilometerage, item.Capacity, item.Mass
                    , item.FuelCapacity, item.BurnRate));
               
            }
            Writer.Close();
        }

        public static void Load()
        {                  
            LoadCars();
            LoadMotorcycles();
            LoadTrucks();
        }
        private static void LoadCars()
        {
            MainWindow.CarsList.Clear();
            try
            {
                StreamReader Reader = new StreamReader("Cars.svdb");
                string Buffer = "";
                while (Buffer != null)
                {
                    Buffer = Reader.ReadLine();
                    if (Buffer == null) break;
                    string[] Readout = Buffer.Split(';');
                    Cars car = new Cars(Readout[0], Readout[1], Readout[2], int.Parse(Readout[3]),
                        int.Parse(Readout[4]), int.Parse(Readout[5]), int.Parse(Readout[6]), double.Parse(Readout[7]),
                        double.Parse(Readout[8]));
                    MainWindow.CarsList.Add(car);
                }
                MainWindow.CarsList.Remove(null);
                Reader.Close();
            }
            catch (FileNotFoundException)
            {
                Cars car = new Cars("Honda", "Civic", "Red", 1993, 200000, 5, 5, 56, 14);
                MainWindow.CarsList.Add(car);
                Save(MainWindow.CarsList);
                MessageBox.Show("Cars.svdb file not found. Created file with default data", "Simple Vehicle Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Motorcycles.svdb Parsing Error.", "Simple Vehicle Database");
            }
        }
        private static void LoadMotorcycles()
        {
            MainWindow.MotorcyclesList.Clear();
            try
            {
                StreamReader Reader = new StreamReader("Motorcycles.svdb");
                string Buffer = "";
                while (Buffer != null)
                {
                    Buffer = Reader.ReadLine();
                    if (Buffer == null) break;
                    string[] Readout = Buffer.Split(';');
                    var BikeType = (Enums.MotorcycleType)Enum.Parse(typeof(Enums.MotorcycleType), Readout[8]);
                    Motorcycles bike = new Motorcycles(Readout[0], Readout[1], Readout[2], int.Parse(Readout[3]),
                        int.Parse(Readout[4]), int.Parse(Readout[5]), int.Parse(Readout[6]), double.Parse(Readout[7]),
                       BikeType);
                    MainWindow.MotorcyclesList.Add(bike);
                }
                MainWindow.MotorcyclesList.Remove(null);
                Reader.Close();
            }
            catch (FileNotFoundException)
            {
                Motorcycles bike = new Motorcycles("Harley-Davidson", "Heritage Softail", "Blue", 2002, 20000, 1440, 
                    19, 4, Enums.MotorcycleType.Cruiser);
                MainWindow.MotorcyclesList.Add(bike);
                Save(MainWindow.MotorcyclesList);
                MessageBox.Show("Motorcycles.svdb file not found. Created file with default data", "Simple Vehicle Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Motorcycles.svdb Parsing Error.", "Simple Vehicle Database");
            }
        }
        private static void LoadTrucks()
        {
            MainWindow.TrucksList.Clear();
            try
            {
                StreamReader Reader = new StreamReader("Trucks.svdb");
                string Buffer = "";
                while (Buffer != null)
                {
                    Buffer = Reader.ReadLine();
                    if (Buffer == null) break;
                    string[] Readout = Buffer.Split(';');
                   Trucks Truck = new Trucks(Readout[0], Readout[1], Readout[2], int.Parse(Readout[3]),
                        int.Parse(Readout[4]), int.Parse(Readout[5]), int.Parse(Readout[6]), double.Parse(Readout[7]),
                       double.Parse(Readout[8]));
                    MainWindow.TrucksList.Add(Truck);
                }
                MainWindow.TrucksList.Remove(null);
                Reader.Close();
            }
            catch (FileNotFoundException)
            {
                Trucks Truck = new Trucks("Volvo", "FH16", "Black", 2015, 10000, 100, 40, 100, 15);
                MainWindow.TrucksList.Add(Truck);
                Save(MainWindow.TrucksList);
                MessageBox.Show("Trucks.svdb file not found. Created file with default data", "Simple Vehicle Database");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Motorcycles.svdb Parsing Error.", "Simple Vehicle Database");
            }
        }
    }
}
