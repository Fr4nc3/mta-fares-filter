using demo_mta_fares.Context;
using demo_mta_fares.DAL;
using demo_mta_fares.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Services
{
    public class DataTripService : BaseService
    {
        public DataTripService(TripDbContext context) : base(context)
        {

        }
        public IList<DataTrip> GetDataTrip(TripFilter filter)
        {

            var results = _context.DataTrips
                .Include(d => d.PickupTaxiZone).AsNoTracking()
                .Include(d => d.DropOffTaxiZone).AsNoTracking()
                .Where(x => x.PickupTaxiZone.Zone.Contains(filter.Pickup) && x.DropOffTaxiZone.Zone.Contains(filter.Dropoff));
            if (filter.validateCarType && filter.CarType != "any")
            {
                 results = results.Where(x => x.CarType == filter.CarType);

            }
            if (filter.Distance > 0)
            {
                 results = results.Where(x => (decimal)x.TripDistance == filter.Distance);

            }
            if (filter.passenger > 0)
            {
                 results = results.Where(x => x.PassengerCount == filter.passenger);

            }
            if (filter.validateStartDate && filter.validateEndDate)
            {
                 results = results.Where(x => x.StartDate >= filter.StartDateValid && x.EndDate <= filter.EndDateValid);
            }

            return results.Take(filter.limit).ToList();
        }

        public IList<DataTripResult> GetTripDataResult(TripFilter filter)
        {

            var results = GetDataTrip(filter);

            return results.Select(x => new DataTripResult
            {
                CarType = x.CarType,
                PickupBorough = x.PickupTaxiZone.Zone,
                DropoffBorough = x.DropOffTaxiZone.Zone,
                PickUpTime = x.StartDate,
                DroppOffTime = x.EndDate,
                FareAmount = x.FareAmount,
                PassengerCount = x.PassengerCount,
                PayType = GetPayType(x.PayType),
                RateCode = GetRateCode(x.RateCodeId),
                TripDistance = x.TripDistance,
                TimeLapse = GetTimeLapse(x.StartDate, x.EndDate)

            }).ToList();

        }
        public string GetRateCode(int ratecodeId)
        {
            return Enum.GetName(typeof(RateCode), (RateCode)ratecodeId);
        }
        public string GetPayType(int paytypeId)
        {
            return Enum.GetName(typeof(PaymentType), (PaymentType)paytypeId);
        }
        public double GetTimeLapse(DateTime startDate, DateTime endDate)
        {
            return endDate.Subtract(startDate).TotalMinutes;
        }

    }
}
