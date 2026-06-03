
namespace SmartHome.Appliances
{
    internal class CoffeeMachine
    {
        public string Brand { get; set; }
        public int CupsPerBrew { get; set; }

        public CoffeeMachine(string brand, int cupsPerBrew)
        {
            Brand = brand;
            CupsPerBrew = cupsPerBrew;
        }

        public void StartBrewing()
        {
            Console.WriteLine($"The {Brand} coffee machine is brewing {CupsPerBrew} cups of coffee.");
        }

        public void StopBrewing()
        {
            Console.WriteLine($"The {Brand} coffee machine has stopped brewing.");
        }

        public void PrintBrewingEnergy()
        {
            Console.WriteLine($"The {Brand} coffee machine used {CupsPerBrew * 0.1} kWh of energy to brew.");
        }
    }
}
