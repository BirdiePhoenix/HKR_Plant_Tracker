using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKR_Plant_Tracker
{
    internal class WateringLog
    {
        private string plantID;
        private DateTime logDate;
        private string logNotes;
        public WateringLog(string PlantID, DateTime LogDate, string LogNotes) {
            this.plantID = PlantID;
            this.logDate = LogDate;
            this.logNotes = LogNotes;
        }

        public void PrintLog()
        {
            Console.WriteLine($"Plant ID: {plantID}");
            Console.WriteLine("Last watered: " + logDate + " ago."); //Calculate days
            Console.WriteLine("Notes: " + logNotes);
        }

        public string GetPlantID() { return plantID; }
        public DateTime GetLogDate() { return logDate; }
        public string GetLogNotes() { return logNotes; }
    }
}
