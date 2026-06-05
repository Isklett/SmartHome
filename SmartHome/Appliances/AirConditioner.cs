using SmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class AirConditioner : Appliance, ISchedulable
    {
        public float TargetTemperature { get; set; }
        public DateTime NextRun { get; set; }

        public AirConditioner(string brand, string room, float targetTemperature) : base(brand, room)
        {
            TargetTemperature = targetTemperature;
        }

        public override string GetInfo()
        {
            return $"{base.GetInfo()} Target temperature: {TargetTemperature} degrees.";
        }

        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} air conditioner has started cooling.");
        }

        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} air conditioner has stopped cooling.");
        }

        public override double GetDailyEnergyUsage()
        {
            return 1.6; // kWh per day
        }

        public void Schedule(DateTime time)
        {
            Console.WriteLine($"{Brand} air conditioner has been scheduled to start at {time}");
        }
    }
}
