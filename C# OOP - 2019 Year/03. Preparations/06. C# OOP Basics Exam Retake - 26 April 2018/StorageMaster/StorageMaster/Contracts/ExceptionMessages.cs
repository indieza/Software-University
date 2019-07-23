namespace StorageMaster.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionMessages
    {
        public const string NegativeProductPrice = "Price cannot be negative!";

        public const string FullVehicle = "Vehicle is full!";

        public const string EmptyVehicle = "No products left in vehicle!";

        public const string InvalidGarageSlot = "Invalid garage slot!";

        public const string NoVehicleInGarage = "No vehicle in this garage slot!";

        public const string NoFreeRoomInGarage = "No room in garage!";

        public const string FullStorage = "Storage is full!";
    }
}