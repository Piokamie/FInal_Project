using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vechicle_Database
{
    public class Cars : Vehicle
    {

        public int Passengers { get; set; }
        public int DoorsNumber { get; set; }


        public Cars(string Manufacturer, string Model,string Color,
            int Year, int Kilometerage,int Passengers,int DoorsNumber,double FuelCapacity,double BurnRate)
        {
            this.Manufacturer = Manufacturer;
            this.Model = Model;
            this.Color = Color;
            this.Year = Year;
            this.Kilometerage = Kilometerage;
            this.Passengers = Passengers;
            this.DoorsNumber = DoorsNumber;
            this.FuelCapacity = FuelCapacity;
            this.BurnRate = BurnRate;
            this.Range = CalculateRange();
        }
        public override int CalculateRange()
        {
            return (int)(FuelCapacity / BurnRate) * 100;
        }
    }
}
