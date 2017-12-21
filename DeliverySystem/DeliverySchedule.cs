using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem
{
    public class DeliverySchedule : ISchedule
    {
        public void Create()
        {
            Deliveries = new List<Delivery>();
        }

        public void Reset()
        {
            Deliveries.Clear();
        }

        public void DetermineInitialDeparture()
        {
            if(Deliveries.Count > 0)
                InitialDeparture = Deliveries.First().DepartureTime;
        }

        public double DetermineTotalDeliveryTime()
        {
            double totalTime = 0.00;
            foreach(var delivery in Deliveries)
            {
                totalTime += delivery.CalculateDeliveryTime();
            }

            return totalTime;
        }

        public List<Delivery> Deliveries;
        public DateTime InitialDeparture;
    }
}
