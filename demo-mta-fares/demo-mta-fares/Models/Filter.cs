using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace demo_mta_fares.Models
{
    public class BaseFilter
    {
        [Range(1, 1000, ErrorMessage = "Limit results should be between 1 and 1000")]
        public int limit { get; set; }
    }
    public class TripFilter : BaseFilter
    {
        [Required, RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage ="Pickup only accept alphanumeric and space characters")]
        public string Pickup { get; set; }
        [Required, RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Dropoff only accept alphanumeric and space characters")]
        public string Dropoff { get; set; }
        public decimal Distance { get; set; }
        public int passenger { get; set; }
        public string CarType { get; set; }
        public string StartDate { get; set; }

        public string EndDate { get; set; }
        [JsonIgnore]
        public DateTime StartDateValid { get; set; }
        [JsonIgnore]
        public DateTime EndDateValid { get; set; }
        [JsonIgnore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "invalid CarType any, yellow, green")]
        public bool validateCarType => CarType == null ? true : CarType != null && (CarType.ToLower() == "any" || CarType.ToLower() == "yellow" || CarType.ToLower() == "green");

        [JsonIgnore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "invalid StartDate YYYY-MM-DD")]
        public bool validateStartDate // if StartDates we validates
        {
            get
            {
                DateTime temp;
                bool converted = DateTime.TryParse(StartDate, out temp);
                if (converted)
                {
                    StartDateValid = temp;
                }
                return StartDate == null ? true : converted;
            }
        }

        [JsonIgnore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "invalid EndDate YYYY-MM-DD ")]
        public bool validateEndDate // if EndDate comes we validate 
        {
            get
            {
                DateTime temp;
                bool converted = DateTime.TryParse(EndDate, out temp);
                if (converted)
                {
                    EndDateValid = temp;
                }
                return  EndDate == null ? true : converted;
            }
        }
        [JsonIgnore]
        [Range(typeof(bool), "true", "true", ErrorMessage = "invalid Dates ")]
        public bool validateDates => validateEndDate && validateStartDate;
       

    }
    public class TaxiFilter : BaseFilter
    {
        [Required, RegularExpression(@"^[a-zA-Z0-9\s]*$", ErrorMessage = "Search only accept alphanumeric and space characters")]
        public string search { get; set; }
    }

}
