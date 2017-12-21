using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
    public interface IDelivery
    {
        void CreateDepartureTime(DateTime departureTime);
        Guid GetTrackingNumber();
        
        Guid TrackingNumber{ get; set; }
        DateTime DepartureTime { get; set; }
        DateTime ArrivalTime { get; set; }
    }
}
