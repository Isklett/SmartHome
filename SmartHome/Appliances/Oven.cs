using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class Oven : Appliance
    {
        public float MaxTemperature { get; set; }
        public Oven(string brand, string room, float maxTemperature) : base(brand, room)
        {
            MaxTemperature = maxTemperature;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Max temperature: {MaxTemperature} degrees.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} oven has started heating.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} oven has stopped heating and is now cooling down.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 1.2; // kWh per wash
        }
    }
}
