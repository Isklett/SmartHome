using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class RobotVacuum : Appliance
    {
        public float BatteryLevel
        {
            get;
            set
            {
                field = Math.Clamp(value, 0.0f, 100.0f);
            }
        }
        public RobotVacuum(string brand, string room, float batteryLevel) : base(brand, room)
        {
            BatteryLevel = batteryLevel;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} BatteryLevel: {BatteryLevel} %.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} vacuum starts cleaning.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} vacuum stops cleaning.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 1.2; // kWh per wash
        }
    }
}
