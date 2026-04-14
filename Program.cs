using System;
using System.Collections.Generic;
using System.Globalization;

namespace HKR_Plant_Tracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Plant> plantList = new List<Plant>();
            List<WateringLog> logList = new List<WateringLog>();
            string menuChoice;

            DateTime dateAdded1 = new DateTime(2026, 3, 28);
            DateTime dateAdded2 = new DateTime(2026, 3, 24);
            DateTime dateAdded3 = new DateTime(2026, 4, 8);

            Plant plant = new Plant("PLT001", "Tulip", "Kitchen", 2, dateAdded1);
            Plant plant2 = new Plant("PLT002", "Orchid", "Living Room", 4, dateAdded2);
            Plant plant3 = new Plant("PLT003", "Lily", "Bed Room", 1, dateAdded3);
            plantList.Add(plant); plantList.Add(plant2); plantList.Add(plant3);
            
            DateTime dateTime1 = new DateTime(2026, 4, 8);
            DateTime dateTime2 = new DateTime(2026, 3, 28);
            DateTime dateTime3 = new DateTime(2026, 4, 2);

            WateringLog log1 = new WateringLog("PLT001", dateTime1, "Watered the Tulip");
            WateringLog log2 = new WateringLog("PLT002", dateTime2, "Watered the Orchid");
            WateringLog log3 = new WateringLog("PLT002", dateTime3, "Spiced the Orchid");
            logList.Add(log1); logList.Add(log2); logList.Add(log3);

            Console.WriteLine("PLANT TRACKER \n **********\n");

            StartUp(logList, plantList);

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
                        LogMenu(logList, plantList);
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

        static void StartUp(List<WateringLog> logList, List<Plant> plantList) //DESIGN CHOICE
        {
            
            Console.WriteLine("These plants needs to be watered today: ");
            foreach (Plant _plant in plantList)
            {
                foreach (WateringLog _log in logList)
                {
                    if(_plant.GetPlantID() == _log.GetPlantID())
                    {
                        int dayCount = DayCal(_log);
                        if (_log.GetLogDate().AddDays(dayCount).Date == DateTime.Now.Date)
                        {
                            Console.WriteLine($"{_plant.GetPlantID()} needs to be watered today.");
                        }
                    }
                }
            }         
        }

        static int DayCal(WateringLog log)
        {
            int dayCount = 0;
            DateTime logDate = log.GetLogDate();

            while (true)
            {
                if (logDate.Date == DateTime.Now.Date)
                {
                    break;
                }
                logDate = logDate.AddDays(1);
                dayCount++;
            }
            return dayCount;
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

                        Plant plant = new Plant(plantID, plantName, plantLocation, wateringDays, DateTime.Now); //ADD LOG
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

        static void LogMenu(List<WateringLog> logList, List<Plant> plantList)
        {
            string menuChoice;
            string plantID;
            DateTime logDate; //DESIGN CHOICE
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

                        foreach(Plant _plant in plantList)
                        {
                            if(_plant.GetPlantID() == plantID)
                            {
                                _plant.SetLastWatered(DateTime.Now);
                            }
                        }
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