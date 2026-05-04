using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HKR_Plant_Tracker
{
    internal class Plant
    {
        private string plantID;
        private string plantName;
        private string plantLocation;
        private int wateringDays;
        private DateTime lastWatered;

        public Plant(string PlantID, string PlantName, string PlantLocation, int WateringDays, DateTime LastWatered)
        {
            this.plantID = PlantID;
            this.plantName = PlantName;
            this.plantLocation = PlantLocation;
            this.wateringDays = WateringDays;
            this.lastWatered = LastWatered;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Plant ID: {GetPlantID()}");
            Console.WriteLine($"Plant name: {GetPlantName()}");
            Console.WriteLine($"Location: {GetPlantLocation()}");
            Console.WriteLine($"Watering interval: {GetWateringDays()}");
            Console.WriteLine($"Was last watered: {GetLastWatered().ToString("d")}\n");
        }

        public bool WaterToday(bool needsWatering)
        {
            int dayCount = 0;
            DateTime countDate = GetLastWatered();

            while (true)
            {
                if (countDate.Date == DateTime.Now.Date)
                {
                    break;
                }
                countDate = countDate.AddDays(1);
                dayCount++;
            }

            if (dayCount % GetWateringDays() == 0 && dayCount != 0)
            {

                Console.WriteLine($"{GetPlantID()}");
                needsWatering = true;
            }

            return needsWatering;
        }

        public string GetPlantID() { return plantID; }
        public string GetPlantName() { return plantName; }
        public string GetPlantLocation() { return plantLocation; }
        public int GetWateringDays() { return wateringDays; }
        public DateTime GetLastWatered() { return lastWatered; }
        public void SetLastWatered( DateTime LastWatered ) { lastWatered = LastWatered; }
    }
}
