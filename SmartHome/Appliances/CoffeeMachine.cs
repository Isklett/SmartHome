using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class CoffeeMachine : Appliance
    {
        public float CupsPerBrew { get; set; }

        public CoffeeMachine(string brand, string room, float cupsPerBrew) : base(brand, room)
        {
            CupsPerBrew = cupsPerBrew;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Cups per brew: {CupsPerBrew} cups.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} coffee machine has started to brew.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} coffee machine has stopped brewing.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 1.2; // kWh per wash
        }
    }
}
