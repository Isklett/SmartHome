using SmartHome.Appliances;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            List<object> devices = new List<object>();
            // Skapa minst fyra objekt:
            // Washer, Refrigerator, Oven och RobotVacuum.
            // Lägg till dem i listan devices.

            Washer_old washer = new Washer_old("LG", 10.0f);
            Refrigerator_old refrigerator = new Refrigerator_old("Samsung", 5.5f);
            Oven_old oven = new Oven_old("Electrolux", 275.0f);
            RobotVacuum_old robot = new RobotVacuum_old("Xiaomi", 100.0f);
            CoffeeMachine_old coffeeMachine = new CoffeeMachine_old("Nespresso", 2);

            devices.Add(washer);
            devices.Add(refrigerator);
            devices.Add(oven);
            devices.Add(robot);
            devices.Add(coffeeMachine);

            RunMorningRoutine(devices);
            Console.WriteLine();
            ReportAllEnergy(devices);
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
        }
    }
}
