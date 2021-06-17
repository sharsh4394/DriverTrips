using DriverTrips.Models;
using DriverTrips.TripManager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace DriverTrips.Controllers
{
    public class DriverReportsController : ApiController
    {
        private ITripManager _tripmanager;

        public DriverReportsController(ITripManager tripManager)
        {
            _tripmanager = tripManager;
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] FileToUpload theFile)
        {
            List<string> driverReport = new List<string>();
            if (theFile.fileSize > 0)
            {
                //boiler plate
                if (theFile.fileAsBase64.Contains(","))
                {
                    theFile.fileAsBase64 = theFile.fileAsBase64.Substring(theFile.fileAsBase64.IndexOf(",") + 1);
                }

                var FileAsByteArray = Convert.FromBase64String(theFile.fileAsBase64);
                string str = Encoding.UTF8.GetString(FileAsByteArray, 0, FileAsByteArray.Length);
                string[] alllines = str.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                driverReport = _tripmanager.GenerateTripReport(alllines);

            }
            else
            {
                driverReport.Add("Blank file");
            }

            return Ok(driverReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_tripmanager != null)
                {
                    _tripmanager.Dispose();
                    _tripmanager = null;
                }
            }
        }
    }
}
