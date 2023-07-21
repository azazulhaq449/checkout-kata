using MSite.Interface;
using MSite.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MSite.Implementation
{
    public class RoutingService : IRoutingService
    {
        private List<Customer> _customers;

        public RoutingService(List<Customer> customerList)
        {
            _customers = customerList;
        }

        public (List<string> Route, int TotalDistance) FindShortestRoute(int startX, int startY)
        {
            var remainingCustomers = new List<Customer>(_customers);
            var currentX = startX;
            var currentY = startY;
            var route = new List<string>();
            int totalDistance = 0;

            while (remainingCustomers.Count > 0)
            {
                var nearestCustomer = GetNearestCustomer(currentX, currentY, remainingCustomers);
                route.Add(nearestCustomer.Name);
                totalDistance += CalculateDistance(currentX, currentY, nearestCustomer.X, nearestCustomer.Y);
                currentX = nearestCustomer.X;
                currentY = nearestCustomer.Y;

                remainingCustomers.Remove(nearestCustomer);
            }

            return (route, totalDistance);
        }

        private Customer GetNearestCustomer(int x, int y, List<Customer> customers)
        {
            var nearestCustomer = customers
               .OrderBy(c => CalculateDistance(x, y, c.X, c.Y))
               .First();

            return nearestCustomer;
        }

        private int CalculateDistance(int x1, int y1, int x2, int y2)
        {
            var distanceX = Math.Abs(x2 - x1);
            var distanceY = Math.Abs(y2 - y1);

            return distanceX + distanceY;
        }
    }
}
