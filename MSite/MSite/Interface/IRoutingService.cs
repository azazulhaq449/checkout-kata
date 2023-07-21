
using System.Collections.Generic;

namespace MSite.Interface
{
    public interface IRoutingService
    {
        (List<string> Route, int TotalDistance) FindShortestRoute(int startX, int startY);
    }
}
