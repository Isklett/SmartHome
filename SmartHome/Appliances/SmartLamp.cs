using System;
using System.Collections.Generic;
using System.Text;

namespace SmartHome.Appliances
{
    internal class SmartLamp : Appliance
    {
        public int Brightness { get; set; }
        public SmartLamp(string brand, string room, int brightness)
        : base(brand, room)
        {
            // Spara brightness.
            Brightness = brightness;
        }
        public new void TurnOn()
        {
            // Skriv ut att lampan tänds.
            Console.WriteLine($"{Brand} lamp turns on.");
        }
    }
}
