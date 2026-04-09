using System;

namespace HKR_Plant_Tracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string menuChoice;
            Console.WriteLine("PLANT TRACKER \n **********\n");

            do
            {
                Console.WriteLine("1.Plant Menu\n2.Log Menu\n9. Exit\n");

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
            string menuChoice;
            Console.WriteLine("PLANT MENU\n");

            do
            {
                Console.WriteLine("1.Add new plant\n2.View all plants\n3.Delete plant\n4.Search plant\n9.Back to main menu\n");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Add plant\n");
                        break;
                    case "2":
                        Console.WriteLine("View plants\n");
                        break;
                    case "3":
                        Console.WriteLine("Delete plant\n");
                        break;
                    case "4":
                        Console.WriteLine("Search plant\n");
                        break;
                    case "9":
                        break;
                }
            } while (menuChoice != "9");
        }

        static void LogMenu()
        {
            string menuChoice;
            Console.WriteLine("LOG MENU\n");

            do
            {
                Console.WriteLine("1.Log watering\n2.View all logs\n3.View log for plant\n9.Back to main menu\n");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Watering\n");
                        break;
                    case "2":
                        Console.WriteLine("Viewing all logs\n");
                        break;
                    case "3":
                        Console.WriteLine("Viewing plant log\n");
                        break;
                    case "9":
                        break;
                }
            } while (menuChoice != "9");
        }
    }
}