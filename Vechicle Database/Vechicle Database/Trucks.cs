using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vechicle_Database
{
    public class Trucks : Vehicle
    {
        public int Capacity { get; set; }
        public int Mass { get; set; }

        public Trucks(string Manufacturer, string Model, string Color,
            int Year, int Kilometerage, int Capacity, int Mass, double FuelCapacity, double BurnRate)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.Color = Color;
            this.Year = Year;
            this.Kilometerage = Kilometerage;
            this.Capacity = Capacity;
            this.Mass = Mass;
            this.FuelCapacity = FuelCapacity;
            this.BurnRate = BurnRate;
            this.Range = CalculateRange();
        }

        public override int CalculateRange()
        {
            return (int)((FuelCapacity / BurnRate) * 100)/ Capacity;
        }
    }
}
