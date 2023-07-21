using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSite.Implementation;
using MSite.Interface;
using MSite.Model;
using System.Collections.Generic;

namespace MSite.Test
{
    [TestClass]
    public class RoutingServiceTest
    {
        private IRoutingService _routingService;

        [TestInitialize]
        public void Init()
        {
            var customers = GetMockCustomers();
            _routingService = new RoutingService(customers);
        }

        [TestCleanup] 
        public void Cleanup()
        {
            _routingService = null;
        }

        [TestMethod]
        public void FindShortestRoute_StartAtOrigin_ReturnsCorrectRouteAndTotalDistance()
        {
            // Arrange
            var expectedRoute = new List<string> { "Customer 1", "Customer 6", "Customer 3", "Customer 9", "Customer 2", "Customer 10", "Customer 5", "Customer 4", "Customer 8", "Customer 7" };
            var expectedTotalDistance = 344;

            // Act
            var (route, totalDistance) = _routingService.FindShortestRoute(0, 0);

            foreach(var i in route)
            {
                System.Diagnostics.Debug.WriteLine(i);
            }
            // Assert
            // Assert
            for (var i = 0; i < expectedRoute.Count; i++)
            {
                Assert.AreEqual(expectedRoute[i], route[i]);
            }
            Assert.AreEqual(expectedTotalDistance, totalDistance);
        }

        [TestMethod]
        public void FindShortestRoute_StartAtDifferentPoint_ReturnsCorrectRouteAndTotalDistance()
        {
            // Arrange
            var expectedRoute = new List<string> { "Customer 4", "Customer 8", "Customer 6", "Customer 3", "Customer 9", "Customer 1", "Customer 10", "Customer 5", "Customer 2", "Customer 7" };
            var expectedTotalDistance = 337;

            // Act
            var (route, totalDistance) = _routingService.FindShortestRoute(67, 1);

            foreach (var i in route)
            {
                System.Diagnostics.Debug.WriteLine(i);
            }
            // Assert
            for (var i = 0; i < expectedRoute.Count; i++)
            {
                Assert.AreEqual(expectedRoute[i], route[i]);
            }
            Assert.AreEqual(expectedTotalDistance, totalDistance);
        }


        [TestMethod]
        public void FindShortestRoute_StartAtMaxPoint_ReturnsCorrectRouteAndTotalDistance()
        {
            // Arrange
            var expectedRoute = new List<string> { "Customer 7", "Customer 8", "Customer 6", "Customer 3", "Customer 9", "Customer 1", "Customer 10", "Customer 5", "Customer 4", "Customer 2" };
            var expectedTotalDistance = 428;

            // Act
            var (route, totalDistance) = _routingService.FindShortestRoute(100, 100);

            foreach (var i in route)
            {
                System.Diagnostics.Debug.WriteLine(i);
            }
            // Assert
            for (var i = 0; i < expectedRoute.Count; i++)
            {
                Assert.AreEqual(expectedRoute[i], route[i]);
            }
            Assert.AreEqual(expectedTotalDistance, totalDistance);
        }

        private List<Customer> GetMockCustomers()
        {
            return new List<Customer>
            {
                new Customer { Name = "Customer 1", X = 10, Y = 20 },
                new Customer { Name = "Customer 2", X = 90, Y = 24 },
                new Customer { Name = "Customer 3", X = 34, Y = 63 },
                new Customer { Name = "Customer 4", X = 67, Y = 1 },
                new Customer { Name = "Customer 5", X = 24, Y = 84 },
                new Customer { Name = "Customer 6", X = 51, Y = 44 },
                new Customer { Name = "Customer 7", X = 97, Y = 92 },
                new Customer { Name = "Customer 8", X = 77, Y = 13 },
                new Customer { Name = "Customer 9", X = 35, Y = 39 },
                new Customer { Name = "Customer 10", X = 85, Y = 29 }
            };
        }
    }
}
