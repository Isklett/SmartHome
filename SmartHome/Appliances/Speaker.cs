
namespace SmartHome.Appliances
{
    internal class Speaker : Appliance
    {
        public float BatteryLevel
        {
            get;
            set
            {
                field = Math.Clamp(value, 0.0f, 100.0f);
            }
        }
        public int VolumeLevel
        {
            get;
            set
            {
                field = Math.Clamp(value, 0, 20);
            }
        }
        public Speaker(string brand, string room, float batteryLevel, int volumeLevel) : base(brand, room)
        {
            BatteryLevel = batteryLevel;
            VolumeLevel = volumeLevel;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} BatteryLevel: {BatteryLevel} %.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} speaker has started, you can now connect.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} speaker has turned off.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 0.1; // kWh per day
        }
    }
}
