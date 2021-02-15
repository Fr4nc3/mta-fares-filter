using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.DAL
{
    public class TaxiZone
    {
        [Column("location_id")]
        public int LocationId { get; set; }
        [Column("borough_name")]
        public string BoroughName { get; set; }
        [Column("zone")]
        public string Zone { get; set; }
        [Column("service_zone")]
        public string ServiceZone { get; set; }
    }
}
