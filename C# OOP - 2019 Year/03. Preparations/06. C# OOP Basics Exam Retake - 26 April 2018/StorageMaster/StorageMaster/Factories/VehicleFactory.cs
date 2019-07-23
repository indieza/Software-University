using System;
using System.Linq;

namespace StorageMaster.Entities.Factories
{
    using StorageMaster.Entities.Models.Vehicles;
    using System.Reflection;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            var vehicleType = this.GetType()
                .Assembly
                .GetTypes()
                .FirstOrDefault(t => typeof(Vehicle).IsAssignableFrom(t) && !t.IsAbstract && t.Name == type);

            if (vehicleType == null)
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            try
            {
                var storage = (Vehicle)Activator.CreateInstance(vehicleType);
                return storage;
            }
            catch (TargetInvocationException e)
            {
                throw e.InnerException;
            }
        }
    }
}