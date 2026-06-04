

namespace SmartHome.Appliances
{
    internal class Appliance
    {
        public string Brand { get; }
        public string Room { get; }
        public bool IsOn { get; protected set; }

        public Appliance(string brand, string room)
        {
            // Sätt Brand, Room och IsOn.
            Brand = brand;
            Room = room;
            IsOn = false;
        }
        public virtual string GetInfo()
        {
            // Returnera en generell text om apparaten.
            // Exempel: "LG in Laundry room"
            return $"{Brand} in {Room}.";
        }
        public virtual void TurnOn()
        {
            // Sätt IsOn till true.
            // Skriv ut ett generellt startmeddelande.
            IsOn = true;
            Console.WriteLine($"{GetType().Name} has turned on.");
        }
        public virtual void TurnOff()
        {
            // Sätt IsOn till false.
            // Skriv ut ett generellt stoppmeddelande.
            IsOn = false;
            Console.WriteLine($"{GetType().Name} has turned off.");
        }
        public virtual double GetDailyEnergyUsage()
        {
            // Returnera 0 som standardvärde.
            return 0;
        }

    }
}
