using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Tire
    {
        public int Year { get; set; }

        public double Pressure { get; set; }

        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }
    }
}
