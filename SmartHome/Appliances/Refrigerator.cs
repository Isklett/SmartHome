

namespace SmartHome.Appliances
{
    internal class Refrigerator : Appliance
    {
        public float Temperature { get; set; }
        public Refrigerator(string brand, string room, float temperature) : base(brand, room)
        {
            Temperature = temperature;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Temperature: {Temperature} degrees.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} refrigerator has turned on.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} refrigerator has turned off.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 3.6; // kWh per day
        }
    }
}
