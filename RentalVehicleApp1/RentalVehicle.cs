using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalVehicleApp1
{
    /// <summary>
    /// This abstract class represents a vehicle to be rented.
    /// It serves as the base class for all classes
    /// which will reprtesent actual vehicle types
    /// that can be rented out.
    /// </summary>
    public class RentalVehicle
    {
        /// <summary>
        /// PlateNumber is a property which can only be set in the constructor,
        /// i.e. when an object of this type is being created.
        /// That's how we will ensure that the license plate number
        /// of a rental vehicle will only be set when the vehicle is acquired.
        /// </summary>
        public string PlateNumber { get; init; }

        public VehicleType Type { get; init; }

        /// <summary>
        /// This property is for storing the daily rental rate.
        /// </summary>
        public double DailyRate { get; set; }

        /// <summary>
        /// This property is for storing the renbtal rate per kilometer.
        /// Note that a conversion will be required for renting vehicles
        /// in countries which do not use kilometers for driving distances.
        /// </summary>
        public double KilometerRate { get; set; }

        public bool IsRented {  get; set; }

        /// <summary>
        /// This only constructor requires the new vehicle's license plate number
        /// so that it can properly be initialized.
        /// </summary>
        /// <param name="plateNo">New vehicle's plate number</param>
        public RentalVehicle(string plateNo, VehicleType typ)
        {
            PlateNumber = plateNo;
            Type = typ;
            IsRented = false;
        }
    }
}
