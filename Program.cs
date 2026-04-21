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
            bool needsWatering = false;           

            Console.WriteLine("PLANT TRACKER \n **********\n");           
            Console.WriteLine("These plants needs to be watered today: ");

            foreach(Plant _plant in plantList)
            {
                needsWatering = _plant.WaterToday(needsWatering);
            }

            if (!needsWatering)
            {
                Console.WriteLine("No plants needs watering today");
            }

            do
            {
                Console.WriteLine("\n1.Plant Menu\n2.Log Menu\n9. Exit\n");

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
                        WateringLog log = new WateringLog(plantID, DateTime.Now, "NEW PLANT");
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
                            foreach (Plant _plant in plantList)
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
                            Console.WriteLine("A plant with that ID doesn't exists\n");
                        }
                        break;
                    case "4": //SEARCH FOR PLANT
                        Console.WriteLine("Search plant\n");
                        Console.WriteLine("Insert plant name: ");
                        plantName = errorHandling.ProcessString();
                        plantExist = errorHandling.CheckIfNameExists(plantList, plantName);

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
                        logNotes = errorHandling.ProcessString();
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