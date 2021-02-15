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

    public partial class TaxiFilter
    {
        /// <summary>
        /// Initializes a new instance of the TaxiFilter class.
        /// </summary>
        public TaxiFilter() { }

        /// <summary>
        /// Initializes a new instance of the TaxiFilter class.
        /// </summary>
        public TaxiFilter(string search, int? limit = default(int?))
        {
            Limit = limit;
            Search = search;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "limit")]
        public int? Limit { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "search")]
        public string Search { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Search == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Search");
            }
            if (this.Limit > 1000)
            {
                throw new ValidationException(ValidationRules.InclusiveMaximum, "Limit", 1000);
            }
            if (this.Limit < 1)
            {
                throw new ValidationException(ValidationRules.InclusiveMinimum, "Limit", 1);
            }
            if (this.Search != null)
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Search, "^[a-zA-Z0-9\\s]*$"))
                {
                    throw new ValidationException(ValidationRules.Pattern, "Search", "^[a-zA-Z0-9\\s]*$");
                }
            }
        }
    }
}
