using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class Oven
    {
        public string? Brand { get; set; }
        public float MaxTemperature { get; set; }

        public Oven(string brand, float maxTemperature)
        {
            Brand = brand;
            MaxTemperature = maxTemperature;
        }

        public void StartHeating()
        {
            Console.WriteLine($"{Brand} oven starts heating.");
        }

        public void StopHeating()
        {
            Console.WriteLine($"{Brand} oven stops heating.");
        }

        public void PrintHeatingEnergy()
        {
            Console.WriteLine($"{Brand} oven uses 2.5 kWh per hour of heating.");
        }
    }
}
