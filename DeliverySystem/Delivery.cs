using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
    public class Delivery : IDelivery
    {
        //Constructors
        public Delivery()
        {
            GenerateTrackingNumber();
        }

        //Public Methods
        public void CreateDepartureTime(DateTime departureTime)
        {
            DepartureTime = departureTime;
        }

        public void CreateArrivalTime(DateTime arrivalTime)
        {
            ArrivalTime = arrivalTime;
        }

        public Guid GetTrackingNumber()
        {
            return TrackingNumber;
        }

        public double CalculateDeliveryTime()
        {
            TimeSpan timeSpan = ArrivalTime.Subtract(DepartureTime);
            double hours = timeSpan.TotalHours;
            Math.Round(hours, 2);
            return hours;
        }

        //Private Methods
        private void GenerateTrackingNumber()
        {
            TrackingNumber = Guid.NewGuid();
        }

        //Properties
        public Guid TrackingNumber { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
