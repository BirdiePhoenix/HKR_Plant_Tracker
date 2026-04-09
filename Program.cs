using System;
using System.Collections.Generic;

namespace HKR_Plant_Tracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Plant> plantList = new List<Plant>();
            List<WateringLog> logList = new List<WateringLog>();
            string menuChoice;
            Console.WriteLine("PLANT TRACKER \n **********\n");

            do
            {
                Console.WriteLine("1.Plant Menu\n2.Log Menu\n9. Exit\n");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        PlantMenu(plantList);
                        break;
                    case "2":
                        LogMenu(logList);
                        break;
                    case "9":
                        break;
                }
                if(menuChoice == "9")
                {
                    break;
                }
              
            } while (menuChoice != "9");
        }

        static void PlantMenu(List<Plant> plantList)
        {
            string menuChoice;
            string plantID;
            string plantName;
            string plantLocation;
            int wateringDays;
            bool plantExist = false;
            Console.WriteLine("PLANT MENU\n");

            do
            {
                Console.WriteLine("1.Add new plant\n2.View all plants\n3.Delete plant\n4.Search plant\n9.Back to main menu\n");

                menuChoice = Console.ReadLine();

                switch (menuChoice) //TO UPPER CASE
                {
                    case "1":
                        Console.WriteLine("Add plant\n");
                        Console.WriteLine("Insert plantID: ");
                        plantID = Console.ReadLine();
                        Console.WriteLine("Insert plant name: ");
                        plantName = Console.ReadLine();
                        Console.WriteLine("Insert plants location: ");
                        plantLocation = Console.ReadLine();
                        Console.WriteLine("Insert watering interval: ");
                        wateringDays = Convert.ToInt32(Console.ReadLine());

                        Plant plant = new Plant(plantID, plantName, plantLocation, wateringDays);
                        plantList.Add(plant);
                        break;
                    case "2":
                        Console.WriteLine("View plants\n");
                        foreach(Plant _plant in plantList)
                        {
                            _plant.PrintDetails();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Delete plant\n");
                        Console.WriteLine("Insert plant ID: ");
                        plantID = Console.ReadLine();

                        foreach(Plant _plant in plantList)
                        {
                            if(plantID == _plant.GetPlantID())
                            {
                                plantList.Remove(_plant);
                                plantExist = true;
                                break;
                            }                                                     
                        }

                        if (!plantExist)
                        {
                            Console.WriteLine("That plant doesn't exist!");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Search plant\n");
                        Console.WriteLine("Insert plant name: ");
                        plantName = Console.ReadLine();

                        foreach(Plant _plant in plantList)
                        {
                            if(plantName == _plant.GetPlantName())
                            {
                                _plant.PrintDetails();
                            }
                        }
                        break;
                    case "9":
                        break;
                }
                if (menuChoice == "9")
                {
                    break;
                }
            } while (menuChoice != "9");
        }

        static void LogMenu(List<WateringLog> logList)
        {
            string menuChoice;
            string plantID;
            DateTime logDate;
            string logNotes;
            Console.WriteLine("LOG MENU\n");

            do
            {
                Console.WriteLine("1.Log watering\n2.View all logs\n3.View log for plant\n9.Back to main menu\n");

                menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Console.WriteLine("Watering\n");
                        Console.WriteLine("Insert plant id: ");
                        plantID = Console.ReadLine(); //Check if exists
                        Console.WriteLine("Insert notes: ");
                        logNotes = Console.ReadLine();
                        logDate = DateTime.Now;

                        WateringLog wateringLog = new WateringLog(plantID, logDate, logNotes);
                        logList.Add(wateringLog);
                        break;
                    case "2":
                        Console.WriteLine("Viewing all logs\n");
                        foreach(WateringLog _wateringLog in logList)
                        {
                            _wateringLog.PrintLog();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Viewing plant log\n");
                        Console.Write("Insert plant id: ");
                        plantID = Console.ReadLine();

                        foreach(WateringLog _wateringLog in logList)
                        {
                            if(plantID == _wateringLog.GetPlantID())
                            {
                                _wateringLog.PrintLog();
                            }
                        }
                        break;
                    case "9":
                        break;
                }
                if (menuChoice == "9")
                {
                    break;
                }
            } while (menuChoice != "9");
        }
    }
}