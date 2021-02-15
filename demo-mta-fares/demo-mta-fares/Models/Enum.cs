using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Models
{
    public enum CarType
    {
        Any,
        Fhv,
        Yellow,
        Green
    }
    public enum PaymentType
    {
        CreditCard = 1,
        Cash = 2,
        NoCharge = 3,
        Dispute = 4,
        Unknown = 5,
        VoidedTrip = 6
    }
    public enum RateCode
    {
        StandardRate = 1,
        JFK = 2,
        Newark = 3,
        NassauOrWestchester= 4,
        NegotiatedFare = 5,
        GroupRate = 6
    }
}
