using demo_mta_fares.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Services
{
    public class BaseService
    {
        public TripDbContext _context;
        public BaseService(TripDbContext context)
        {
            _context = context;
        }
    }
}
