
namespace SmartHome.Appliances
{
    internal class RobotVacuum
    {
        public string? Brand { get; set; }
        public float BatteryLevel 
        {
            get;
            set
            {
                field = Math.Clamp(value, 0.0f, 100.0f);
            }
        }
        public RobotVacuum(string brand, float batteryLevel)
        {
            Brand = brand;
            BatteryLevel = batteryLevel;
        }

        public void StartCleaning()
        {
            Console.WriteLine($"{Brand} robot vacuum starts cleaning");
        }

        public void StopCleaning()
        {
            Console.WriteLine($"{Brand} robot vacuum stops cleaning");
        }

        public void PrintCleaningEnergy()
        {
            Console.WriteLine($"{Brand} robot vacuum uses 0.4 kWh per cleaning");
        }
    }
}
