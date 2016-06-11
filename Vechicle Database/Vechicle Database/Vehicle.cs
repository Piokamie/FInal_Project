using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vechicle_Database
{
    public abstract class Vehicle
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public int Kilometerage { get; set; }              
        public double FuelCapacity { get; set; }
        public double BurnRate { get; set; }
        public double Range { get; set; }
        


        public abstract int CalculateRange();
    }
}
