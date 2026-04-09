using System;

namespace HKR_Plant_Tracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string menuChoice;
            Console.WriteLine("Plant Tracker \n **********\n");

            do
            {
                Console.WriteLine("1.Plant Menu\n2.Log Menu\n9. Exit");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        PlantMenu();
                        break;
                    case "2":
                        LogMenu();
                        break;
                    case "9":
                        break;
                }
            } while (menuChoice != "9");
        }

        static void PlantMenu()
        {
            Console.WriteLine("Plant Menu");
        }

        static void LogMenu()
        {
            Console.WriteLine("Log Menu");
        }
    }
}