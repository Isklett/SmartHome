using SmartHome.Appliances;
using SmartHome.Interfaces;

namespace SmartHome
{
    internal class SmartHomeController
    {
        private List<Appliance> _devices = new List<Appliance>();
        public void AddDevice(Appliance device)
        {
            // Lägg till device i listan.
            _devices.Add(device);
        }
        public void TurnOnAll()
        {
            // Loopa igenom alla devices och starta dem.
            // Du får inte använda if/switch på specifika klasser.
            foreach (Appliance device in _devices)
            {
                device.TurnOn();
            }
        }
        public void TurnOffAll()
        {
            // Loopa igenom alla devices och stäng av dem.
            foreach(Appliance device in _devices)
            {
                device.TurnOff();
            }
        }
        public void PrintStatusReport()
        {
            // Loopa igenom alla devices.
            // Skriv ut GetInfo() och om apparaten är på eller av.
            foreach (Appliance device in _devices)
            {
                string status = device.IsOn ? "On" : "Off";
                Console.WriteLine($"{device.GetInfo()} Status: {status}");
            }
        }
        public double GetTotalDailyEnergyUsage()
        {
            // Räkna ihop GetDailyEnergyUsage() för alla devices.
            // Returnera totalsumman.
            double total = 0;
            foreach (Appliance device in _devices)
            {
                total += device.GetDailyEnergyUsage();
            }
            return total;
        }

        //public void ScheduleAllDevicesWrong(DateTime time)
        //{
        //    foreach (Appliance device in _devices)
        //    {
        //        device.Schedule(time);
        //    }
        //}
        public void ScheduleAllSchedulableDevices(DateTime time)
        {
            foreach (Appliance device in _devices)
            {
                // 1. Kontrollera om device implementerar ISchedulable.
                // 2. Casta device till ISchedulable.
                // 3. Anropa Schedule(time).
                if(device is ISchedulable schedulableDevice)
                {
                    schedulableDevice.Schedule(time);
                }
            }
        }

        internal List<ISchedulable> GetSchedulableDevices()
        {
            List<ISchedulable> result = new List<ISchedulable>();
            foreach (Appliance device in _devices)
            {
                // Om device implementerar ISchedulable,
                // lägg till det i result.
                if(device is ISchedulable schedulableDevice)
                {
                    result.Add(schedulableDevice);
                }
            }
            return result;
        }

        public Appliance? FindDeviceByBrand(string brand)
        {
            // Returnera första apparaten med rätt brand.
            // Om ingen finns kan du returnera null,
            // eller kasta ett eget felmeddelande.
            return _devices.FirstOrDefault(d => d.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase));
        }


    }
}
