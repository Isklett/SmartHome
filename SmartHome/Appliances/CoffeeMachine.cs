

using SmartHome.Interfaces;

namespace SmartHome.Appliances
{
    internal class CoffeeMachine : Appliance, ISchedulable
    {
        public float CupsPerBrew { get; set; }
        public DateTime NextRun { get; set; }

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
            return 0.3; // kWh per day
        }

        public void Schedule(DateTime time)
        {
            Console.WriteLine($"{Brand} coffee machine has been scheduled to start at {time}");
        }
    }
}
