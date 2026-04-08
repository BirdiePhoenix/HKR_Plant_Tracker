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
    }
}
