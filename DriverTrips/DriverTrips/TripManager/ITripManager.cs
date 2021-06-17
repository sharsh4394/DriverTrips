using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverTrips.TripManager
{
    public interface ITripManager : IDisposable
    {
        List<string> GenerateTripReport(string[] input);
    }
}
