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

    public partial class DataTripResult
    {
        /// <summary>
        /// Initializes a new instance of the DataTripResult class.
        /// </summary>
        public DataTripResult() { }

        /// <summary>
        /// Initializes a new instance of the DataTripResult class.
        /// </summary>
        public DataTripResult(string carType = default(string), string pickupBorough = default(string), string dropoffBorough = default(string), DateTime? pickUpTime = default(DateTime?), DateTime? droppOffTime = default(DateTime?), double? fareAmount = default(double?), int? passengerCount = default(int?), string payType = default(string), string rateCode = default(string), double? tripDistance = default(double?), double? timeLapse = default(double?))
        {
            CarType = carType;
            PickupBorough = pickupBorough;
            DropoffBorough = dropoffBorough;
            PickUpTime = pickUpTime;
            DroppOffTime = droppOffTime;
            FareAmount = fareAmount;
            PassengerCount = passengerCount;
            PayType = payType;
            RateCode = rateCode;
            TripDistance = tripDistance;
            TimeLapse = timeLapse;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "carType")]
        public string CarType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pickupBorough")]
        public string PickupBorough { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "dropoffBorough")]
        public string DropoffBorough { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "pickUpTime")]
        public DateTime? PickUpTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "droppOffTime")]
        public DateTime? DroppOffTime { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "fareAmount")]
        public double? FareAmount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "passengerCount")]
        public int? PassengerCount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "payType")]
        public string PayType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "rateCode")]
        public string RateCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "tripDistance")]
        public double? TripDistance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "timeLapse")]
        public double? TimeLapse { get; set; }

    }
}