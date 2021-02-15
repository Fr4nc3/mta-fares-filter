using demo_mta_fares.Context;
using demo_mta_fares.DAL;
using demo_mta_fares.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Services
{
    public class TaxiZoneService : BaseService
    {
        public TaxiZoneService(TripDbContext context) : base(context)
        {

        }

        public IList<TaxiZone> GetTaxiZones()
        {
            return (this._context.TaxiZones.ToList());
        }
        public IList<TaxiZone> GetTaxiZonesByFilter(TaxiFilter filter)
        {
            return _context.TaxiZones
                .Where(x => x.BoroughName.Contains(filter.search) || x.Zone.Contains(filter.search)
                || x.ServiceZone.Contains(filter.search)).Take(filter.limit).ToList();
        }
    }
}
