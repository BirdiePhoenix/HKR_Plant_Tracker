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
    }
}
