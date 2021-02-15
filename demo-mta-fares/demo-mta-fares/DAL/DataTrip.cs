using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.DAL
{
    public class DataTrip
    {
        [Column("trip_id")]
        public Guid TripId { get; set; }
        [Column("car_type")]
        public string CarType { get; set; }
        [ForeignKey("PickupTaxiZone")]
        [Column("pickup_borough")]
        public int PickupBorough { get; set; }
        [ForeignKey("DropOffTaxiZone")]
        [Column("dropoff_borough")]
        public int DropoffBorough { get; set; }
        [Column("rate_code_id")]
        public int RateCodeId { get; set; }
        [Column("fare_amount")]
        public decimal FareAmount { get; set; }
        [Column("passenger_count")]
        public int PassengerCount { get; set; }
        [Column("sr_flag")] // share ride flag
        public int SrFLag { get; set; }
        [Column("pay_type")]
        public int PayType { get; set; }
        [Column("trip_distance")]
        public decimal TripDistance { get; set; }
        [Column("start_date")]
        public DateTime StartDate { get; set; }
        [Column("end_date")]
        public DateTime EndDate { get; set; }
        // navigation
        public  TaxiZone PickupTaxiZone { get; set; }
        public  TaxiZone DropOffTaxiZone { get; set; }
    }
}
