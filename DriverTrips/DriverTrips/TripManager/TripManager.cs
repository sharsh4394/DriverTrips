using DriverTrips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DriverTrips.TripManager
{
    public class TripManager : ITripManager
    {
        public List<string> GenerateTripReport(string[] input)
        {
            List<string> drivers = new List<string>();
            List<Trip> trips = new List<Trip>();

            //fetch data
            foreach (var item in input)
            {
                if (item.StartsWith("Driver"))
                {
                    drivers.Add(item.Split()[1]);
                }
                else if (item.StartsWith("Trip"))
                {
                    string[] data = item.Split();
                    Trip trip = new Trip();
                    trip.Driver = data[1];
                    trip.StartTime = data[2];
                    trip.EndTime = data[3];
                    trip.Distance = float.Parse(data[4]);
                    trip.Duration = DateTime.Parse(trip.EndTime).Subtract(DateTime.Parse(trip.StartTime));
                    trip.Speed = Math.Round(trip.Distance / trip.Duration.TotalHours);
                    if (trip.Speed > 5 && trip.Speed < 100)
                    {
                        trips.Add(trip);
                    }
                }
            }

            //All trips grouped by driver name and sorted by Total distance travelled
            var groupedTrips =
                               (from d in drivers
                                join t in trips
                                on d equals t.Driver into dt
                                select new { driverName = d, TotalDist = dt.Sum(x => x.Distance), TotalHours = dt.Sum(x => x.Duration.TotalHours) }).OrderByDescending(x => x.TotalHours);

            //Report Generation
            List<string> driverReports = new List<string>();
            foreach (var item in groupedTrips)
            {
                string report = string.Empty;
                if (item.TotalDist > 0)
                {
                    report = string.Format("{0}: {1} miles @ {2} mph {3}", item.driverName, Math.Round(item.TotalDist), Math.Round(item.TotalDist / item.TotalHours), Environment.NewLine);
                }
                else
                {
                    report = string.Format("{0}: 0 miles {1}", item.driverName, Environment.NewLine);
                }
                driverReports.Add(report);
            }

            return driverReports;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                //TODO : dispose the if resources used in this class in future.
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
