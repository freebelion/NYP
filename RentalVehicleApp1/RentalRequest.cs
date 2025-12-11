using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalVehicleApp1
{
    public class RentalRequest
    {
        private static int requestCount = 0;

        public int RequestNumber { get; init; }

        public VehicleType RequestType { get; init; }

        public DateTime RequestTime { get; init; }

        public RentalRequest(VehicleType rqstType, DateTime rqstTime)
        {
            // Assign incremental numbers to requests
            requestCount++;
            RequestNumber = requestCount;

            RequestType = rqstType;
            RequestTime = rqstTime;
        }
    }
}
