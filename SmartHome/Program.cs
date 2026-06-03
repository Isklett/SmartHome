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

            Washer washer = new Washer("LG", 10.0f);
            Refrigerator refrigerator = new Refrigerator("Samsung", 5.5f);
            Oven oven = new Oven("Electrolux", 275.0f);
            RobotVacuum robot = new RobotVacuum("Xiaomi", 100.0f);
            CoffeeMachine coffeeMachine = new CoffeeMachine("Nespresso", 2);

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
                if (device is Washer)
                {
                    ((Washer)device).StartWash();
                    ((Washer)device).StopWash();
                }
                else if (device is Refrigerator)
                {
                    ((Refrigerator)device).StartCooling();
                    ((Refrigerator)device).StopCooling();

                }
                else if (device is Oven)
                {
                    ((Oven)device).StartHeating();
                    ((Oven)device).StopHeating();
                }
                else if (device is RobotVacuum)
                {
                    ((RobotVacuum)device).StartCleaning();
                    ((RobotVacuum)device).StopCleaning();
                }
                else if (device is CoffeeMachine)
                {
                    ((CoffeeMachine)device).StartBrewing();
                    ((CoffeeMachine)device).StopBrewing();
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
                if (device is Washer)
                {
                    ((Washer)device).PrintWashEnergy();
                }
                else if (device is Refrigerator)
                {
                    ((Refrigerator)device).PrintCoolingEnergy();

                }
                else if (device is Oven)
                {
                    ((Oven)device).PrintHeatingEnergy();
                }
                else if (device is RobotVacuum)
                {
                    ((RobotVacuum)device).PrintCleaningEnergy();
                }
                else if (device is CoffeeMachine)
                {
                    ((CoffeeMachine)device).PrintBrewingEnergy();
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
