using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalVehicleApp1
{
    public class RentalContract
    {
        public int RequestNumber { get; init; }

        public string VehiclePlateNumber { get; init; }

        public DateTime ContractTime { get; init; }

        private TimeSpan requestDuration;

        public DateTime ReturnTime { get; private set; }

        public bool IsCompleted = false;

        public RentalContract(DateTime cntrctTime, int rqstNo, string plateNumber)
        {
            RequestNumber = rqstNo;
            VehiclePlateNumber = plateNumber;
            ContractTime = cntrctTime;

            // Request duration may not be known in advance, but we are just making up a random duration
            requestDuration = TimeSpan.FromHours(Program.RND.Next(30, 100));
        }

        public bool CheckIfComplete(DateTime checkTime)
        {
            if (checkTime - ContractTime < requestDuration) { return false; }

            ReturnTime = ContractTime + requestDuration;
            IsCompleted = true;
            return true;
        }
    }
}
