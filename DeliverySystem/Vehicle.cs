using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
    public abstract class Vehicle
    {
        public Vehicle()
        {
            DeliverySchedule = new DeliverySchedule();
        }

        public double CalculateTravelTime()
        {
            double totalTime = DeliverySchedule.DetermineTotalDeliveryTime();
            totalTime = Math.Round(totalTime, 2);
            return totalTime;
        }

        public DeliverySchedule DeliverySchedule { get; set; }
        public int VehicleID { get; set; }
        public string VehicleType { get; set; }
    }
}
