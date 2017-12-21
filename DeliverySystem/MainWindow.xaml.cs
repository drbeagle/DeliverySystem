using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeliverySystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Properties
        public ObservableCollection<Vehicle> ActiveVehicles { get; set; }
        int VehicleIDCounter { get; set; }
        
        public List<Delivery> PreDefinedDeliveries { get; set; }
        public List<Delivery> PreDefinedVanDeliveries { get; set; }
        public List<Delivery> DisplayedDeliveries { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            
            VehicleIDCounter = 1;
            ActiveVehicles = new ObservableCollection<Vehicle>();
            PreDefinedDeliveries = new List<Delivery>();
            PreDefinedVanDeliveries = new List<Delivery>();
            DisplayedDeliveries = new List<Delivery>();

            SetupVehicles();
            DataContext = this;
            CreateHardCodedData();
        }

        //Private Methods
        private void SetupVehicles()
        {
            Vehicle newTruck;
            Vehicle newVan;

            newTruck = new Truck();
            newTruck.DeliverySchedule.Create();

            newVan = new Van();
            newVan.DeliverySchedule.Create();

            newTruck.VehicleID = VehicleIDCounter;
            VehicleIDCounter++;
            newVan.VehicleID = VehicleIDCounter;
            VehicleIDCounter++;

            newTruck.DeliverySchedule.Deliveries = PreDefinedDeliveries;
            newVan.DeliverySchedule.Deliveries = PreDefinedVanDeliveries;

            ActiveVehicles.Add(newTruck);
            ActiveVehicles.Add(newVan);
        }   

        private void CreateHardCodedData()
        {
            List<DateTime> deliveryTimeDepartures;
            List<DateTime> deliveryTimeArrivals;
            List<DateTime> vanDepartures;
            List<DateTime> vanArrivals;

            //Just going to create some arrival and departure times for both a van and a truck
            deliveryTimeDepartures = new List<DateTime>();
            deliveryTimeArrivals = new List<DateTime>();
            vanDepartures = new List<DateTime>();
            vanArrivals = new List<DateTime>();

            //Truck Departures
            DateTime time1 = new DateTime(1,1,1, 2, 11, 00);
            DateTime time2 = new DateTime(1,1,1, 3, 15, 00);
            DateTime time3 = new DateTime(1,1,1, 4, 44, 00);
            DateTime time4 = new DateTime(1,1,1, 6, 21, 00);
            DateTime time5 = new DateTime(1,1,1, 9, 36, 00);

            //Truck Arrivals
            DateTime time6 = new DateTime(1, 1, 1, 2, 18, 00);
            DateTime time7 = new DateTime(1, 1, 1, 3, 33, 00);
            DateTime time8 = new DateTime(1, 1, 1, 5, 12, 00);
            DateTime time9 = new DateTime(1, 1, 1, 7, 11, 00);
            DateTime time10 = new DateTime(1, 1, 1, 9, 56, 00);

            //Van Departures
            DateTime vanTime1 = new DateTime(1, 1, 1, 6, 22, 00);
            DateTime vanTime2 = new DateTime(1, 1, 1, 7, 10, 00);
            DateTime vanTime3 = new DateTime(1, 1, 1, 9, 35, 00);

            //Van Arrivals
            DateTime vanTime4 = new DateTime(1, 1, 1, 7, 01, 00);
            DateTime vanTime5 = new DateTime(1, 1, 1, 8, 10, 00);
            DateTime vanTime6 = new DateTime(1, 1, 1, 11, 46, 00);

            deliveryTimeDepartures.Add(time1);
            deliveryTimeDepartures.Add(time2);
            deliveryTimeDepartures.Add(time3);
            deliveryTimeDepartures.Add(time4);
            deliveryTimeDepartures.Add(time5);

            deliveryTimeArrivals.Add(time6);
            deliveryTimeArrivals.Add(time7);
            deliveryTimeArrivals.Add(time8);
            deliveryTimeArrivals.Add(time9);
            deliveryTimeArrivals.Add(time10);

            vanDepartures.Add(vanTime1);
            vanDepartures.Add(vanTime2);
            vanDepartures.Add(vanTime3);

            vanArrivals.Add(vanTime4);
            vanArrivals.Add(vanTime5);
            vanArrivals.Add(vanTime6);

            for (int i = 0; i < deliveryTimeDepartures.Count; i++)
            {
                var delivery = new Delivery();
                delivery.CreateDepartureTime(deliveryTimeDepartures[i]);
                delivery.CreateArrivalTime(deliveryTimeArrivals[i]);
                PreDefinedDeliveries.Add(delivery);
            }

            for(int i = 0; i < vanDepartures.Count; i++)
            {
                var delivery = new Delivery();
                delivery.CreateDepartureTime(vanDepartures[i]);
                delivery.CreateArrivalTime(vanArrivals[i]);
                PreDefinedVanDeliveries.Add(delivery);
            }

        }

        //Event Handlers
        private void btnCreateDelivery_Click(object sender, RoutedEventArgs e)
        {
            Vehicle selectedVehicle = (Vehicle)lstBoxVehicles.SelectedItem;

            selectedVehicle.DeliverySchedule.Create();
            selectedVehicle.DeliverySchedule.Deliveries = PreDefinedDeliveries;
        }

        private void lstBoxVehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vehicle vehicle = (Vehicle)lstBoxVehicles.SelectedItem;
            DisplayedDeliveries = vehicle.DeliverySchedule.Deliveries;

            //Update the datagrid binding
            dataGridDeliveries.ItemsSource = null;
            dataGridDeliveries.ItemsSource = DisplayedDeliveries;

            //Update Travel Time
            txtBoxTravelTime.Text = vehicle.CalculateTravelTime().ToString() + " hrs";
        }
    }
}
