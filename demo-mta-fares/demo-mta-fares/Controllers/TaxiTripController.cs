using demo_mta_fares.Context;
using demo_mta_fares.DAL;
using demo_mta_fares.Models;
using demo_mta_fares.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo_mta_fares.Controllers
{
    [Route("api/")]
    [Produces("application/json")]
    [ApiController]
    public class TaxiTripController : ControllerBase
    {
        /// <summary>
        /// logger for debug
        /// </summary>
        private ILogger<TaxiTripController> _logger;
        /// <summary>
        /// database context
        /// </summary>
        private TripDbContext _context;
        /// <summary>
        /// Controller constructor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="context"></param>
        public TaxiTripController(ILogger<TaxiTripController> logger, TripDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        /// <summary>
        /// taxi zones list
        /// </summary>
        /// <returns>IList of TaxiZone</returns>
        [Route("taxizone")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<TaxiZone>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)] // Tells swagger that the response format will be an int for a BadRequest (400)
        public IList<TaxiZone> GetTaxiZones()
        {
            var service = new TaxiZoneService(_context);
            return service.GetTaxiZones();
        }
        /// <summary>
        /// taxi zones list by filter
        /// </summary>
        /// <param name="filter">payload body object</param>
        /// <returns>IListTaxiZone</returns>
        [Route("taxizone")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<TaxiZone>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        public IList<TaxiZone> TaxiZonesByFilter(TaxiFilter filter)
        {
            var service = new TaxiZoneService(_context);
            return service.GetTaxiZonesByFilter(filter);
        }
        /// <summary>
        /// trips search return raw db objecs 
        /// </summary>
        /// <param name="filter">payload body object</param>
        /// <returns>list of datatrip objects</returns>
        [Route("trips")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<DataTrip>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)] 
        public IList<DataTrip> GetDataTrip(TripFilter filter)
        {
            var service = new DataTripService(_context);
            return service.GetDataTrip(filter);
        }
        /// <summary>
        /// trips search with a flat object results list
        /// </summary>
        /// <param name="filter">payload body object</param>
        /// <returns></returns>
        [Route("tripresults")]
        [HttpPost]
        [ProducesResponseType(typeof(IList<DataTripResult>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), StatusCodes.Status400BadRequest)]
        public IList<DataTripResult> GetTripDataResults(TripFilter filter)
        {
            var service = new DataTripService(_context);
            return service.GetTripDataResult(filter);
        }
    }
}
