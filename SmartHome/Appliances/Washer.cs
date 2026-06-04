

using SmartHome.Interfaces;

namespace SmartHome.Appliances
{
    internal class Washer : Appliance, ISchedulable
    {
        public float CapacityKg { get; }
        public DateTime NextRun { get; set; }

        public Washer(string brand, string room, float capacityKg) : base(brand, room)
        {
            CapacityKg = capacityKg;
        }
        public override string GetInfo()
        {
            return $"{base.GetInfo()} Capacity: {CapacityKg} kg.";
        }
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine($"{Brand} washing machine has started a program.");
        }
        public override void TurnOff()
        {
            base.TurnOff();
            Console.WriteLine($"{Brand} washing machine has stopped a program.");
        }
        public override double GetDailyEnergyUsage()
        {
            return 1.2; // kWh per wash
        }

        public void Schedule(DateTime time)
        {
            Console.WriteLine($"{Brand} washer has been scheduled to start at {time}");
        }
    }
}
