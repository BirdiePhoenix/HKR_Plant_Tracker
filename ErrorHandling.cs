using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKR_Plant_Tracker
{
    internal class ErrorHandling
    {
        public ErrorHandling() { }
        public string IntChecker()
        {
            string checkThisInt;
            do
            {
                checkThisInt = Console.ReadLine();
                if (int.TryParse(checkThisInt, out int choice))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Use numbers!");
                }
            } while (true);

            return checkThisInt;
        }

        public string ProcessString()
        {
            string checkThisString;
            do
            {
                checkThisString = Console.ReadLine();
                if (String.IsNullOrEmpty(checkThisString))
                {
                    Console.WriteLine("The string can't be empty!");
                }
                else
                {
                    break;
                }
            } while (true);

            return checkThisString;
        }
        public bool CheckIfIDExists(List<Plant> plantList, string plantID)
        {
            bool plantExists = false;

            foreach (Plant _plant in plantList)
            {
                if (_plant.GetPlantID() == plantID)
                {
                    plantExists = true;
                    break;
                }
            }

            return plantExists;
        }

        public bool CheckIfNameExists(List<Plant> plantList, string plantName)
        {
            bool plantExists = false;

            foreach (Plant _plant in plantList)
            {
                if (_plant.GetPlantName() == plantName)
                {
                    plantExists = true;
                    break;
                }
            }
            return plantExists;
        }
    }    
}
