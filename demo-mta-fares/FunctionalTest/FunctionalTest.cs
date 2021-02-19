using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Rest;
using RestClassLibrary;
using RestClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace FunctionalTest
{
    [TestClass]
    public class FunctionalTest
    {
        // DEMO: Local testing

        /// <summary>
        ///  API endpoint
        /// </summary>
        //const string EndpointUrlString = "https://localhost:5001/";
        const string EndpointUrlString = "http://mta-tlc-demo-fr.azurewebsites.net/";
        /// <summary>
        /// Cliente Service credential
        /// </summary>
        public ServiceClientCredentials serviceClientCredentials;
        /// <summary>
        /// RestClientSDKLibraryClient
        /// </summary>
        public RestClassLibraryClient client;

        public TaxiFilter taxiFilter;

        public TripFilter tripFilter;

        /// <summary>
        /// initilize the variables used on all the test cases
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            serviceClientCredentials = new TokenCredentials("FakeTokenValue");
            client = new RestClassLibraryClient(new Uri(EndpointUrlString), serviceClientCredentials);
        }

        [TestMethod]
        public async Task TestMissingTaxiFilterParams()
        {
            //Arrange   
            taxiFilter = new TaxiFilter()
            {
                Limit = 100,
                Search = ""
            };

            // Act
            var resultObject = await client.TaxiZonesByFilterWithHttpMessagesAsync(body: taxiFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestWrongLimitRange()
        {
            //Arrange   
            taxiFilter = new TaxiFilter()
            {
                Limit = -1,
                Search = ""
            };

            // Act
            var resultObject = await client.TaxiZonesByFilterWithHttpMessagesAsync(body: taxiFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestMissingDropoff()
        {
            //Arrange   
            tripFilter = new TripFilter()
            {
                Limit = 100,
                Pickup = "Astoria"
            };

            // Act
            var resultObject = await client.GetDataTripWithHttpMessagesAsync(body: tripFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestMissingPickUp()
        {
            //Arrange   
            tripFilter = new TripFilter()
            {
                Limit = 100,
                Dropoff = "Astoria"
            };

            // Act
            var resultObject = await client.GetDataTripWithHttpMessagesAsync(body: tripFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestWrongStarDate()
        {
            //Arrange   
            tripFilter = new TripFilter()
            {
                Limit = 100,
                Dropoff = "Astoria",
                Pickup = "Chinatown",
                StartDate = ""
            };

            // Act
            var resultObject = await client.GetDataTripWithHttpMessagesAsync(body: tripFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestWrongEndDate()
        {
            //Arrange   
            tripFilter = new TripFilter()
            {
                Limit = 100,
                Dropoff = "Astoria",
                Pickup = "Chinatown",
                EndDate = ""
            };

            // Act
            var resultObject = await client.GetDataTripWithHttpMessagesAsync(body: tripFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestWrongCarType()
        {
            //Arrange   
            tripFilter = new TripFilter()
            {
                Limit = 100,
                Dropoff = "Astoria",
                Pickup = "Chinatown",
                CarType = "Red"
            };

            // Act
            var resultObject = await client.GetDataTripWithHttpMessagesAsync(body: tripFilter);
            //Assert
            Assert.AreEqual(StatusCodes.Status400BadRequest, (int)resultObject.Response.StatusCode);
        }
        [TestMethod]
        public async Task TestDataTripGreenCar()
        {

            tripFilter = new TripFilter()
            {
                Limit = 100,
                Pickup = "Astoria",
                Dropoff = "Chinatown",
                CarType = "green"
            };
            // Act
            var resultObject = await client.GetTripDataResultsAsync(body: tripFilter);

            IList<DataTripResult> resultPayload = resultObject as IList<DataTripResult>;
            // Assert
            if (resultPayload != null)
            {

                Assert.IsTrue(resultPayload.Count()>0);

            }
            else
            {
                Assert.Fail("Expected a to create resultPayload  but didn't recieve one");
            }
        }
        [TestMethod]
        public async Task TestDataTripAnyCar()
        {

            tripFilter = new TripFilter()
            {
                Limit = 100,
                Pickup = "Brook",
                Dropoff = "Brook"
            };
            // Act
            var resultObject = await client.GetTripDataResultsAsync(body: tripFilter);

            IList<DataTripResult> resultPayload = resultObject as IList<DataTripResult>;
            // Assert
            if (resultPayload != null)
            {

                Assert.IsTrue(resultPayload.Count() > 0);

            }
            else
            {
                Assert.Fail("Expected a to create resultPayload  but didn't recieve one");
            }
        }
        [TestMethod]
        public async Task TestDataTripDates()
        {

            tripFilter = new TripFilter()
            {
                Limit = 100,
                Pickup = "Brook",
                Dropoff = "Brook", 
                StartDate = "2018-01-03",
                EndDate = "2018-01-03",
            };
            // Act
            var resultObject = await client.GetTripDataResultsAsync(body: tripFilter);

            IList<DataTripResult> resultPayload = resultObject as IList<DataTripResult>;
            // Assert
            if (resultPayload != null)
            {

                Assert.IsTrue(resultPayload.Count() > 0);

            }
            else
            {
                Assert.Fail("Expected a to create resultPayload  but didn't recieve one");
            }
        }
        [TestMethod]
        public async Task TestAllTaxiZones()
        {

            // Act
            var resultObject = await client.GetTaxiZonesAsync();

            IList<TaxiZone> resultPayload = resultObject as IList<TaxiZone>;

            // Assert
            if (resultPayload != null)
            {
                Assert.IsTrue(resultPayload.Count() == 265);

            }
            else
            {
                Assert.Fail("Expected a to create resultPayload  but didn't recieve one");
            }
        }
        [TestMethod]
        public async Task TestTaxiFilters()
        {
            //Arrange   
            taxiFilter = new TaxiFilter()
            {
                Limit = 100,
                Search = "Staten"
            };

            // Act
            var resultObject = await client.TaxiZonesByFilterAsync(taxiFilter);

            IList<TaxiZone> resultPayload = resultObject as IList<TaxiZone>;

            // Assert
            if (resultPayload != null)
            {
                Debug.WriteLine(resultPayload.Count());
                Assert.IsTrue(resultPayload.Count() > 0);

            }
            else
            {
                Assert.Fail("Expected a to create resultPayload but didn't recieve one");
            }
        }
    }
}
