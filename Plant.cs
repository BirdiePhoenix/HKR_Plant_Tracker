using System;
using System.Collections.Generic;
using System.Linq;
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
        public Plant(string PlantID, string PlantName, string PlantLocation, int WateringDays) {
            this.plantID = PlantID;
            this.plantName = PlantName;
            this.plantLocation = PlantLocation;
            this.wateringDays = WateringDays;
        }

        public void PrintDetails()
        {
            Console.WriteLine($"Plant ID: {plantID}");
            Console.WriteLine($"Plant name: {plantName}");
            Console.WriteLine($"Location: {plantLocation}");
            Console.WriteLine($"Watering interval: {wateringDays}");
        }

        public string GetPlantID() { return plantID; }
        public string GetPlantName() { return plantName; }
        public string GetPlantLocation() { return plantLocation; }
        public int GetWateringDays() { return wateringDays; }
    }
}
