
namespace SmartHome.Appliances
{
    internal class Refrigerator_old
    {
        public string Brand { get; set; }
        public float Temperature { get; set; }

        public Refrigerator_old(string brand, float temperature)
        {
            Brand = brand;
            Temperature = temperature;
        }


        public void StartCooling()
        {
            Console.WriteLine($"{Brand} refrigerator starts cooling.");
        }

        public void StopCooling() 
        {
            Console.WriteLine($"{Brand} refrigerator stops cooling.");
        }

        public void PrintCoolingEnergy()
        {
            Console.WriteLine($"{Brand} refrigerator uses 3.6 kWh per day of cooling.");
        }
    }
}
