using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Models
{
    public class DataTripResult
    {
        public string CarType { get; set; }
        public string PickupBorough { get; set; }
        public string DropoffBorough { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DroppOffTime { get; set; }
        public decimal FareAmount { get; set; }
        public int PassengerCount { get; set; }
        public string PayType { get; set; }
        public string RateCode { get; set; }
        public decimal TripDistance { get; set; }
        public double TimeLapse { get; set; }

    }
}
