namespace RentalVehicleApp1
{
    internal class Program
    {
        public static Random RND { get; set; } = new Random();

        private static char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static char[] digits = "1234567890".ToCharArray();

        /// <summary>
        /// Since the app is not going to receive actual requests from the web,
        /// this function is making up a new request at every time, with a 25% probability.
        /// </summary>
        /// <param name="rqstTime"></param>
        /// <returns>The RentalRequest object, if one is created</returns>
        public static RentalRequest CreateRequest(DateTime rqstTime)
        {
            double rndValue = RND.NextDouble();
            VehicleType rqstType;
            if (rndValue < 0.15) rqstType = VehicleType.CompactAuto;
            else if (rndValue < 0.25) rqstType = VehicleType.SedanAuto;
            else if (rndValue < 0.4) rqstType = VehicleType.SUVAuto;
            else if (rndValue < 0.5) rqstType = VehicleType.PickupTruck;
            else if (rndValue < 0.6) rqstType = VehicleType.MediumTruck;
            else if (rndValue < 0.65) rqstType = VehicleType.SemiTruck;
            else if (rndValue < 0.8) rqstType = VehicleType.Minibus;
            else if (rndValue < 0.9) rqstType = VehicleType.SmallBus;
            else rqstType = VehicleType.CoachBus;
            return new RentalRequest(rqstType, rqstTime);
        }

        public static List<RentalVehicle> CreateVehicles(int N)
        {
            List<RentalVehicle> vehicles = [];

            // Create rental autos, buses and trucks with different probabilities
            for (int i = 0; i < N; i++)
            {
                double r = RND.NextDouble();

                if (r < 0.5) vehicles.Add(CreateAuto());
                else if (r < 0.8) vehicles.Add(CreateTruck());
                else vehicles.Add(CreateBus());
            }

            // Make up some rates
            foreach (RentalVehicle vhc in vehicles)
            {
                switch (vhc.Type)
                {
                    case VehicleType.CompactAuto:
                        vhc.DailyRate = 35;
                        vhc.KilometerRate = 1.5;
                        break;
                    case VehicleType.SedanAuto:
                        vhc.DailyRate = 55;
                        vhc.KilometerRate = 2.5;
                        break;
                    case VehicleType.SUVAuto:
                        vhc.DailyRate = 75;
                        vhc.KilometerRate = 3.5;
                        break;
                    case VehicleType.Minibus:
                        vhc.DailyRate = 60;
                        vhc.KilometerRate = 5;
                        break;
                    case VehicleType.SmallBus:
                        vhc.DailyRate = 90;
                        vhc.KilometerRate = 6;
                        break;
                    case VehicleType.CoachBus:
                        vhc.DailyRate = 150;
                        vhc.KilometerRate = 9;
                        break;
                    case VehicleType.PickupTruck:
                        vhc.DailyRate = 72;
                        vhc.KilometerRate = 2.5;
                        break;
                    case VehicleType.MediumTruck:
                        vhc.DailyRate = 96;
                        vhc.KilometerRate = 3.5;
                        break;
                    case VehicleType.SemiTruck:
                        vhc.DailyRate = 230;
                        vhc.KilometerRate = 8.5;
                        break;

                }
            }

            return vehicles;
        }

        private static string CreateLicensePlate()
        {
            // Randomly generate a license plate as an array of 9 characters
            char[] charArray = new char[9];
            int i = 0;
            // with two digits
            for (; i < 2; i++) charArray[i] = digits[RND.Next(digits.Length)];
            // and three letters
            for (; i < 5; i++) charArray[i] = letters[RND.Next(letters.Length)];
            // and four more digits
            for (; i < 9; i++) charArray[i] = digits[RND.Next(digits.Length)];
            return new string(charArray);
        }

        private static RentalVehicle CreateAuto()
        {
            string plateNo = CreateLicensePlate();

            double typeChoice = RND.NextDouble();

            VehicleType typ;

            if (typeChoice < 0.3) typ = VehicleType.CompactAuto;
            else if (typeChoice < 0.8) typ = VehicleType.SedanAuto;
            else typ = VehicleType.SUVAuto;

            return new RentalVehicle(plateNo, typ);
        }

        private static RentalVehicle CreateTruck()
        {
            string plateNo = CreateLicensePlate();

            double typeChoice = RND.NextDouble();

            VehicleType typ;

            if (typeChoice < 0.5) typ = VehicleType.PickupTruck;
            else if (typeChoice < 0.8) typ = VehicleType.MediumTruck;
            else typ = VehicleType.SemiTruck;

            return new RentalVehicle(plateNo, typ);
        }

        private static RentalVehicle CreateBus()
        {
            string plateNo = CreateLicensePlate();

            double typeChoice = RND.NextDouble();

            VehicleType typ;

            if (typeChoice < 0.4) typ = VehicleType.Minibus;
            else if (typeChoice < 0.7) typ = VehicleType.SmallBus;
            else typ = VehicleType.CoachBus;

            return new RentalVehicle(plateNo, typ);
        }

        static void Main(string[] args)
        {
            // We are starting by creating a number of test vehicles
            List<RentalVehicle> rentalVehicles = CreateVehicles(50);

            // Requests will be placed in a queue
            Queue<RentalRequest> rentalRequests = new Queue<RentalRequest>();

            // We will also keep a list of rental contracts
            List<RentalContract> rentalContracts = new List<RentalContract>();

            // Then we advance the app time randomly in a loop,
            // pretending to be getting rental requests
            // and matching them with available vehicles
            Console.WriteLine("Keep pressing ENTER to continue to receive rental resuests.");
            Console.WriteLine("You can press any other key to end the loop.");
            Console.WriteLine();
            DateTime appTime = DateTime.Now; // fake time
            do
            {
                rentalRequests.Enqueue(CreateRequest(appTime));

                // try to match the request at the top of the queue with a vehicle
                RentalRequest rqst = rentalRequests.Peek();
                // Get a sublist of not-yet-rented vehicles of matching type
                List<RentalVehicle> matchingVehicles =
                    rentalVehicles.Where(vhc => (vhc.Type == rqst.RequestType && !vhc.IsRented)).ToList();
                // If there are available vehicles, choose one randomly
                if(matchingVehicles.Count > 0)
                {
                    int index = RND.Next(matchingVehicles.Count);
                    RentalVehicle vhc = matchingVehicles[index];
                    // Create a rental contract, starting some random minutes later
                    DateTime contractTime = appTime.AddMinutes(100 * RND.NextDouble());
                    RentalContract rntcon = new RentalContract(contractTime,
                        rqst.RequestNumber, vhc.PlateNumber);
                    // Keep a record of the contract and printout the action
                    rentalContracts.Add(rntcon);
                    Console.WriteLine("{0} {1} with plate number {2} has been assigned to rental request #{3}.",
                        contractTime.ToString("dd.MM.yyyy HH:mm"), vhc.Type, vhc.PlateNumber, rqst.RequestNumber);
                    // Mark the vehicle as rented
                    vhc.IsRented = true;
                }
                else
                {// Report the lack of a match
                    Console.WriteLine("{0} No vehicle of {1} type was found to match Request #{2}",
                        rqst.RequestTime.ToString("dd.MM.yyyy HH:mm"), rqst.RequestType, rqst.RequestNumber);
                }

                // Remove the request from the queue
                // (which means requests without a mathing vehicle will be let go)
                rentalRequests.Dequeue();

                // Finally, go through the rental contracts to find those that ended
                List<RentalContract> unfinishedContracts =
                    rentalContracts.Where(rntcon => !rntcon.IsCompleted).ToList();

                foreach(RentalContract rntcon in unfinishedContracts)
                {
                    if(rntcon.CheckIfComplete(appTime))
                    {
                        // Clear the rented status of the contracted vehicle
                        RentalVehicle rvhc = rentalVehicles.First(v => v.PlateNumber == rntcon.VehiclePlateNumber);
                        rvhc.IsRented = false;
                        // and print out the outcome
                        Console.WriteLine("\t{0} {1} with plate number {2} has been returned.",
                            rntcon.ReturnTime.ToString("dd.MM.yyyy HH:mm"), rvhc.Type, rvhc.PlateNumber);
                    }
                }

                // Advance the fake time by some hours
                appTime = appTime.AddHours(24*RND.NextDouble());
            } while (string.IsNullOrEmpty(Console.ReadLine()));
        }

    }
}
