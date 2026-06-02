using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class Washer
    {
        public string Brand { get; set; }
        public float CapacityKg { get; set; }

        public Washer(string brand, float capacityKg)
        {
            Brand = brand;
            CapacityKg = capacityKg;
        }

        public void StartWash()
        {
            Console.WriteLine($"{Brand} washer starts washing.");
        }

        public void StopWash()
        {
            Console.WriteLine($"{Brand} washer stops washing.");
        }

        public void PrintWashEnergy()
        {
            Console.WriteLine($"{Brand} washer uses 1.2 kWh per wash.");
        }
    }
}
