﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace RestClassLibrary.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class TripFilter
    {
        /// <summary>
        /// Initializes a new instance of the TripFilter class.
        /// </summary>
        public TripFilter() { }

        /// <summary>
        /// Initializes a new instance of the TripFilter class.
        /// </summary>
        public TripFilter(string pickup, string dropoff, int? limit = default(int?), double? distance = default(double?), int? passenger = default(int?), string carType = default(string), string startDate = default(string), string endDate = default(string))
        {
            Limit = limit;
            Pickup = pickup;
            Dropoff = dropoff;
            Distance = distance;
            Passenger = passenger;
            CarType = carType;
            StartDate = startDate;
            EndDate = endDate;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pickup")]
        public string Pickup { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dropoff")]
        public string Dropoff { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "distance")]
        public double? Distance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "passenger")]
        public int? Passenger { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "carType")]
        public string CarType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "startDate")]
        public string StartDate { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endDate")]
        public string EndDate { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Pickup == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Pickup");
            }
            if (Dropoff == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Dropoff");
            }
            if (this.Limit > 1000)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Limit", 1000);
            }
            if (this.Limit < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Limit", 1);
            }
            if (this.Pickup != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Pickup, "^[a-zA-Z0-9\\s]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Pickup", "^[a-zA-Z0-9\\s]*$");
                }
            }
            if (this.Dropoff != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Dropoff, "^[a-zA-Z0-9\\s]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Dropoff", "^[a-zA-Z0-9\\s]*$");
                }
            }
        }
    }
}
