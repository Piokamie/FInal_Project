using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vechicle_Database
{
    public class Motorcycles : Vehicle
    {
        public int Engine { get; set; }
        public Enums.MotorcycleType MotorcycleType { get; set; }

        public Motorcycles(string Manufacturer, string Model, string Color,
            int Year, int Kilometerage, int Engine, double FuelCapacity, double BurnRate, Enums.MotorcycleType MotorcycleType)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.Color = Color;
            this.Year = Year;
            this.Kilometerage = Kilometerage;
            this.Engine = Engine;
            this.FuelCapacity = FuelCapacity;
            this.BurnRate = BurnRate;
            this.MotorcycleType = MotorcycleType;
            Range = CalculateRange();

        }


        public override int CalculateRange()
        {
            return (int)(FuelCapacity / BurnRate) * 100;
        }
    }
}
