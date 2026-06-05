using SmartHome.Appliances;
using SmartHome.Interfaces;
using System.Reflection;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            //List<object> devices = new List<object>();

            List<Appliance> devices = new List<Appliance>();


            // Skapa minst fyra objekt:
            // Washer, Refrigerator, Oven och RobotVacuum.
            // Lägg till dem i listan devices.

            //Washer_old washer = new Washer_old("LG", 10.0f);
            //Refrigerator_old refrigerator = new Refrigerator_old("Samsung", 5.5f);
            //Oven_old oven = new Oven_old("Electrolux", 275.0f);
            //RobotVacuum_old robot = new RobotVacuum_old("Xiaomi", 100.0f);
            //CoffeeMachine_old coffeeMachine = new CoffeeMachine_old("Nespresso", 2);

            Washer washer = new Washer("LG", "Laundry Room", 10.0f);
            Refrigerator refrigerator = new Refrigerator("Samsung", "Kitchen", 5.5f);
            Oven oven = new Oven("Electrolux", "Kitchen", 275.0f);
            RobotVacuum robotVacuum = new RobotVacuum("Xiaomi", "Living Room", 100.0f);
            CoffeeMachine coffeeMachine = new CoffeeMachine("Nespresso", "Kitchen", 2);
            Speaker speaker = new Speaker("Sonos", "Living Room", 100.0f, 10);
            AirConditioner airConditioner = new AirConditioner("Electrolux", "Bedroom", 3.5f);

            devices.Add(washer);
            devices.Add(refrigerator);
            devices.Add(oven);
            devices.Add(robotVacuum);
            devices.Add(coffeeMachine);

            //RunMorningRoutine(devices);
            RunAppliances(devices);
            Console.WriteLine();
            //ReportAllEnergy(devices);

            SmartHomeController controller = new SmartHomeController();
            // Lägg till minst fem olika apparater.

            controller.AddDevice(washer);
            controller.AddDevice(refrigerator);
            controller.AddDevice(oven);
            controller.AddDevice(robotVacuum);
            controller.AddDevice(coffeeMachine);
            controller.AddDevice(speaker);
            controller.AddDevice(airConditioner);

            controller.PrintStatusReport();
            Console.WriteLine();
            controller.TurnOnAll();
            Console.WriteLine();
            double totalEnergy = controller.GetTotalDailyEnergyUsage();
            Console.WriteLine($"Total daily energy usage: {totalEnergy} kWh");
            Console.WriteLine();
            controller.TurnOffAll();
            Console.WriteLine();
            controller.ScheduleAllSchedulableDevices(DateTime.Now.AddHours(2));

            Console.WriteLine();
            SmartLamp lamp1 = new SmartLamp("IKEA", "Hallway", 80);
            Appliance lamp2 = lamp1;
            lamp1.TurnOn();
            lamp2.TurnOn();

            Console.WriteLine();
            List<ISchedulable> schedulableDevices = controller.GetSchedulableDevices();
            foreach (ISchedulable schedulable in schedulableDevices)
            {
                // Skriv ut NextRun eller schemalägg apparaten.
                schedulable.Schedule(DateTime.Now.AddHours(1));
            }

            Console.WriteLine();
            Appliance? foundDevice = controller.FindDeviceByBrand("Electrolux");
            if (foundDevice != null)
            {
                if(foundDevice is ISchedulable iSchedulableDevice)
                {
                    iSchedulableDevice.Schedule(DateTime.Now.AddHours(3));
                }
                else
                {
                    foundDevice.TurnOn();
                }
            }
        }
        static void RunMorningRoutine(List<object> devices)
        {
            foreach (object device in devices)
            {
                // 1. Kontrollera vilken typ device är.
                // 2. Casta till rätt typ.
                // 3. Anropa rätt startmetod.
                // 4. Anropa rätt stoppmetod.
                if (device is Washer_old)
                {
                    ((Washer_old)device).StartWash();
                    ((Washer_old)device).StopWash();
                }
                else if (device is Refrigerator_old)
                {
                    ((Refrigerator_old)device).StartCooling();
                    ((Refrigerator_old)device).StopCooling();

                }
                else if (device is Oven_old)
                {
                    ((Oven_old)device).StartHeating();
                    ((Oven_old)device).StopHeating();
                }
                else if (device is RobotVacuum_old)
                {
                    ((RobotVacuum_old)device).StartCleaning();
                    ((RobotVacuum_old)device).StopCleaning();
                }
                else if (device is CoffeeMachine_old)
                {
                    ((CoffeeMachine_old)device).StartBrewing();
                    ((CoffeeMachine_old)device).StopBrewing();
                }
            }
        }
        static void ReportAllEnergy(List<object> devices)
        {
            foreach (object device in devices)
            {
                // 1. Kontrollera vilken typ device är.
                // 2. Casta till rätt typ.
                // 3. Anropa rätt energimetod.
                if (device is Washer_old)
                {
                    ((Washer_old)device).PrintWashEnergy();
                }
                else if (device is Refrigerator_old)
                {
                    ((Refrigerator_old)device).PrintCoolingEnergy();

                }
                else if (device is Oven_old)
                {
                    ((Oven_old)device).PrintHeatingEnergy();
                }
                else if (device is RobotVacuum_old)
                {
                    ((RobotVacuum_old)device).PrintCleaningEnergy();
                }
                else if (device is CoffeeMachine_old)
                {
                    ((CoffeeMachine_old)device).PrintBrewingEnergy();
                }
            }
        }

        static void RunAppliances(List<Appliance> devices)
        {
            foreach (Appliance device in devices)
            {
                Console.WriteLine(device.GetInfo());
                device.TurnOn();
                Console.WriteLine($"Daily energy usage: {device.GetDailyEnergyUsage()}");
                device.TurnOff();
                Console.WriteLine();
            }
        }

        static void Answers()
        {
            //1.Varför behövde du kontrollera vilken typ varje objekt hade?
            Console.WriteLine("Svar 1: devices är en lista av generiska objekt, så vi kan inte kalla några klasspecifika funktioner utan att kontrollera och casta till den klassen.");
            //2.Vad händer om du lägger till en ny klass CoffeeMachine?
            Console.WriteLine("Svar 2: Om jag lägger till CoffeeMachine så behöver jag lägga till en if-sats vid varje check.");
            //3.Vilka metoder måste du ändra om du lägger till CoffeeMachine ?
            Console.WriteLine("Svar 3: RunMorningRoutine samt ReportAllEnergy.");
            //4.Vad är problemet med att listan är List<object>?
            Console.WriteLine("Svar 4: Listan kan innehålla i princip vad som helst. Så vid användning måste vi alltid kolla vad det är vi hämtar ut, och vi behöver alltid casta.");
            //5.Vad händer om du råkar glömma en apparattyp i ReportAllEnergy()?
            Console.WriteLine("Svar 5: Den skrivs inte ut.");
            //6.Hur många ställen i koden behövde du ändra för att systemet skulle fungera med CoffeeMachine?
            Console.WriteLine("Svar 6:När jag lade till CoffeeMachine behövde jag ändra på 3 ställen. Main, RunMorningRoutine och ReportAllEnergy.");

            //7.Varför fungerar device.TurnOn() trots att device har typen Appliance?
            Console.WriteLine("Svar 7: device.TurnOn() fungerar då metoden finns i basklassen Appliance.");
            //8.Vilken metod körs om objektet egentligen är en RobotVacuum?
            Console.WriteLine("Svar 8: Om objektet är en RobotVacuum körs RobotVacuums version av metoden, vilket är en override av basklassens.");
            //9.Vad blev bättre jämfört med List<object>?
            Console.WriteLine("Svar 9: Genom att använda en List<Appliance> får vi tillgång till att kalla Appliance metoder som vi enkelt kan köra en override på i våra subklasser för att specialisera beroende på typ av appliance.");

            //10.Varför kompilerar inte ScheduleAllDevicesWrong?
            Console.WriteLine("Svar 10: Med tanke på att vi går igenom alla av typen Appliance och anropar metoden Schedule direkt kommer vi inte åt då den finns i interfacet ISchedulable, vilket basklassen Appliance inte implementerar.");

            //11.Varför kan vi inte anropa Schedule() direkt på en variabel av typen Appliance ?
            Console.WriteLine("Svar 11: Appliance implementerar inte interfacet ISchedulable.");
            //12.Varför fungerar det efter att vi castar till ISchedulable ?
            Console.WriteLine("Svar 12: När vi castar till ISchedulable garanterar vi att den typen av Appliance vi kör metoden på implementerar ISchedulable. Om den inte gör det så körs inte metoden.");
            //13.Vad betyder det att RobotVacuum både är en Appliance och en ISchedulable?
            Console.WriteLine("Svar 13: RobotVacuum är en klass som ärver från en basklass (Appliance) samt implementerar interfacet ISchedulable.");
            //14.Varför ska inte Schedule() ligga direkt i Appliance?
            Console.WriteLine("Svar 14: Om Schedule() hade funnits direkt i Appliance hade alla klasser som ärver av Appliance haft tillgång till den, och vi vill inte att t.ex Oven och Refrigerator ska kunna schemaläggas.");
            //15.Vad är skillnaden mellan arv och interface i det här exemplet?
            Console.WriteLine("Svar 15: Att en klass ärver från en annan betyder att det är en specialisering av den ärvda basklassen. Klassen har tillgång till den ärvda basklassen, samt att den kan overridea och specialisera dens metoder. Ett interface säger till klassen vad den behöver implementera, men klassen måste alltid implementera funktionaliteten själv. Så i detta fall säger arvet till vad för typ av klass det är och vad för grundfunktionalitet den ska ha, medans interface säger till vad för metoder och variabler som måste implementeras, men inte hur.");

            //16.Vad händer om man tar bort virtual från en metod i basklassen?
            Console.WriteLine("Svar 16: 'Subklass.TurnOn()': cannot override inherited member 'Appliance.TurnOn()' because it is not marked virtual, abstract, or override");
            //17.Vad händer om man tar bort override från en metod i subklassen?
            Console.WriteLine("Svar 17:  Varning. C# föreslår att jag ska lägga till override keyword för att få subklassen att overridea.");

            //18.Blir utskriften samma eller olika när vi anropar TurnOn() på lamp1 och lamp2?
            Console.WriteLine("Svar 18: Nej, lamp1 skriver ut brand medans lamp2 skriver ut generiska metoden.");
            //19.Vilken metod körs när variabeln har typen SmartLamp?
            Console.WriteLine("Svar 19: Metoden som ligger i SmartLamp-klassen.");
            //20.Vilken metod körs när variabeln har typen Appliance?
            Console.WriteLine("Svar 20: Den generiska metoden i basklassen.");
            //21.Varför är detta farligt eller förvirrande?
            Console.WriteLine("Svar 21: Det ger inget felmeddelande då SmartLamp är en appliance, så vi kan använda en referens av typen appliance till den utan att den säger till. Om vi då anropar en appliance-metod som inte finns som override i subklassen, kommer basklassens metod köras. Om vi däremot anropar SmartLamp direkt så kommer metoden i subklassen köras då 'new' betyder att vi gömmer basklassens metod med samma signatur.");
            //22.Vad händer om du byter new till override?
            Console.WriteLine("Svar 22: Om vi byter new till override kommer subklassens metod alltid köras om Appliance-objektet är av rätt typ. Detta då override betyder att vi ersätter basklassens metod med subklassens.");

            //23.Vad säger kompilatorn?
            Console.WriteLine("Svar 23: 'PizzaOven.TurnOn()': cannot override inherited member 'Oven.TurnOn()' because it is sealed");
            //24.Varför får PizzaOven inte override:a TurnOn()?
            Console.WriteLine("Svar 24: Sealed hindrar arv. Så om en metod är sealed kan ingen ärva den metoden, och om en klass är sealed kan ingen ärva den klassen.");
            //25. När kan det vara rimligt att använda sealed override?
            Console.WriteLine("Svar 25: När du anser att en metod behövs specialiseras för en subklass men är komplett efter det och inte ska ha möjligheten att overrideas av subklasser längre ner i strukturen.");
            //26. Vad kan PizzaOven fortfarande göra i stället? Kan den override:a någon annan metod?
            Console.WriteLine("Svar 26: Ja, resterande metoder som inte är sealed går att overrideas");

            //27.Varför kan listan vara List<ISchedulable> även om objekten egentligen är olika klasser?
            Console.WriteLine("Svar 27: En lista är bara referenser, och i detta fallet är det en lista av referenser till objekt av klasser som implementerar interfacet ISchedulable.");

        }
    }
}
