using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace HKR_Plant_Tracker
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ErrorHandling errorHandling = new ErrorHandling();
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
            DateTime dateTime4 = new DateTime(2026, 4, 14);

            WateringLog log1 = new WateringLog("PLT001", dateTime1, "Watered the Tulip");
            plantList[0].SetLastWatered(dateTime1);
            WateringLog log2 = new WateringLog("PLT002", dateTime2, "Watered the Orchid");
            WateringLog log3 = new WateringLog("PLT002", dateTime3, "Spiced the Orchid");
            plantList[1].SetLastWatered(dateTime3);
            WateringLog log4 = new WateringLog("PLT003", dateTime4, "Watered the Lily");
            plantList[2].SetLastWatered(dateTime4);
            logList.Add(log1); logList.Add(log2); logList.Add(log3); logList.Add(log4);

            Console.WriteLine("PLANT TRACKER \n **********\n");

            //StartUp(logList, plantList);
            Console.WriteLine("These plants needs to be watered today: ");

            foreach(Plant _plant in plantList)
            {
                _plant.CheckIfWaterToday();
            }

            do
            {
                Console.WriteLine("1.Plant Menu\n2.Log Menu\n9. Exit\n");

                menuChoice = errorHandling.IntChecker();

                switch (menuChoice)
                {
                    case "1":
                        PlantMenu(plantList, logList, errorHandling);
                        break;
                    case "2":
                        LogMenu(logList, plantList, errorHandling);
                        break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Wrong input. Input 1-2 or 9");
                        break;
                }              
            } while (menuChoice != "9");
        }

        static void PlantMenu(List<Plant> plantList, List<WateringLog> logList, ErrorHandling errorHandling)
        {
            string menuChoice;
            string plantID;
            string plantName;
            string plantLocation;
            string wateringDays;
            int wateringInterval;
            bool plantExist = false;
            Console.WriteLine("PLANT MENU\n");

            do
            {
                Console.WriteLine("1.Add new plant\n2.View all plants\n3.Delete plant\n4.Search plant\n9.Back to main menu\n");

                menuChoice = errorHandling.IntChecker(); 

                switch (menuChoice) //TO UPPER CASE
                {
                    case "1": //ADD PLANT
                        Console.WriteLine("Add new plant\n");  
                        
                        //PLANT ID
                        Console.WriteLine("Insert a unique plantID: ");
                        do
                        {
                            plantID = errorHandling.ProcessString();
                            plantExist = errorHandling.CheckIfIDExists(plantList, plantID);
                            if (plantExist)
                            {
                                Console.WriteLine("A plant with that ID does already exists. Insert a new.");
                            }
                        } while (plantExist); 
                        
                        //PLANT NAME
                        Console.WriteLine("Insert plant name: ");
                        plantName = errorHandling.ProcessString();                                            

                        //LOCATION
                        Console.WriteLine("Insert plants location: ");
                        plantLocation = errorHandling.ProcessString();

                        //WATERING INTERVAL
                        Console.WriteLine("Insert watering interval: ");
                        do
                        {
                            wateringDays = errorHandling.IntChecker();
                            wateringInterval = Convert.ToInt32(wateringDays);
                            if(wateringInterval < 1)
                            {
                                Console.WriteLine("Watering interval can't be less than 1!");
                            }
                            else
                            {
                                break;
                            }
                        } while (true);                        

                        Plant plant = new Plant(plantID, plantName, plantLocation, wateringInterval, DateTime.Now);
                        plantList.Add(plant);
                        WateringLog log = new WateringLog(plantID, DateTime.Now, "New plant");
                        logList.Add(log);
                        break;
                    case "2": //VIEW ALL PLANTS
                        Console.WriteLine("View plants\n");
                        foreach (Plant _plant in plantList)
                        {
                            _plant.PrintDetails();
                        }
                        break;
                    case "3": //DELETE PLANT
                        Console.WriteLine("Delete plant\n");
                        Console.WriteLine("Insert plant ID: ");
                        plantID = errorHandling.ProcessString();
                        plantExist = errorHandling.CheckIfIDExists(plantList, plantID);

                        if (plantExist)
                        {
                            foreach (Plant _plant in plantList) //KOLLA OM BATTRE SATT
                            {
                                if (plantID == _plant.GetPlantID())
                                {
                                    plantList.Remove(_plant);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("A plant with that ID doesn't exists");
                        }
                        break;
                    case "4": //SEARCH FOR PLANT
                        Console.WriteLine("Search plant\n");
                        Console.WriteLine("Insert plant name: ");
                        plantName = errorHandling.ProcessString();
                        plantExist = errorHandling.CheckIfPlantNameExists(plantList, plantName);

                        if (plantExist)
                        {
                            foreach (Plant _plant in plantList)
                            {
                                if (plantName == _plant.GetPlantName())
                                {
                                    _plant.PrintDetails();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("A plant with that name doesn't exist");
                        }
                            break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Wrong input. Input 1-4 or 9");
                        break;
                }
            } while (menuChoice != "9");
        }

        static void LogMenu(List<WateringLog> logList, List<Plant> plantList, ErrorHandling errorHandling)
        {
            string menuChoice;
            string plantID;
            DateTime logDate; //DESIGN CHOICE
            string logNotes;
            bool plantExist = false;
            Console.WriteLine("LOG MENU\n");

            do
            {
                Console.WriteLine("1.Log watering\n2.View all logs\n3.View log for plant\n9.Back to main menu\n");

                menuChoice = errorHandling.IntChecker();

                switch (menuChoice)
                {
                    case "1": //ADD LOG
                        Console.WriteLine("Watering\n");
                        //PLANT ID
                        Console.WriteLine("Insert plant id: ");
                        do
                        {
                            plantID = errorHandling.ProcessString();
                            plantExist = errorHandling.CheckIfIDExists(plantList, plantID);
                            if (!plantExist)
                            {
                                Console.WriteLine("A plant with that ID doesn't exist. Insert an existing one");
                            }
                        } while (!plantExist);

                        //NOTES
                        Console.WriteLine("Insert notes: ");
                        logNotes = Console.ReadLine();
                        logDate = DateTime.Now;

                        WateringLog wateringLog = new WateringLog(plantID, logDate, logNotes);
                        logList.Add(wateringLog);

                        //Updating the plants last watering
                        foreach (Plant _plant in plantList)
                        {
                            if (_plant.GetPlantID() == plantID)
                            {
                                _plant.SetLastWatered(DateTime.Now);
                            }
                        }
                        break;
                    case "2": //VIEW ALL LOGS
                        Console.WriteLine("Viewing all logs\n");
                        foreach (WateringLog _wateringLog in logList)
                        {
                            _wateringLog.PrintLog();
                        }
                        break;
                    case "3": //VIEW LOGS FOR PLANT
                        Console.WriteLine("Viewing plant log\n");
                        Console.Write("Insert plant id: ");
                        plantID = errorHandling.ProcessString();
                        plantExist = errorHandling.CheckIfIDExists(plantList, plantID);

                        if (plantExist)
                        {
                            foreach (WateringLog _wateringLog in logList)
                            {
                                if (plantID == _wateringLog.GetPlantID())
                                {
                                    _wateringLog.PrintLog();
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("A plant with that ID doesn't exist"); //LOOP? + LOOP OR NOT DESIGN
                        }
                            break;
                    case "9":
                        break;
                    default:
                        Console.WriteLine("Wrong input. Input 1-3 or 9");
                        break;
                }              
            } while (menuChoice != "9");
        }       
    }
}