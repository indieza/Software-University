namespace MXGP.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidModel = "Model {0} cannot be less than {1} symbols.";
     
        public const string InvalidName = "Name {0} cannot be less than {1} symbols.";
  
        public const string InvalidHorsePower = "Invalid horse power: {0}.";
    
        public const string InvalidNumberOfLaps = "Laps cannot be less than {0}.";

        public const string RiderExists = "Rider {0} is already created.";
        
        public const string RiderAlreadyAdded = "Rider {0} is already added in {1} race.";
               
        public const string RiderNotFound = "Rider {0} could not be found.";
               
        public const string RiderNotParticipate = "Rider {0} could not participate in race.";
            
        public const string RiderInvalid = "Racer cannot be null.";
           
        public const string MotorcycleExists = "Motorcycle {0} is already create.";
       
        public const string MotorcycleInvalid = "Motorcycle cannot be null.";
     
        public const string MotorcycleNotFound = "Motorcycle {0} could not be found.";

        public const string MotorcycleMustBeNull = "Motorcycle must to be null.";
         
        public const string RaceNotFound = "Race {0} could not be found.";
      
        public const string RaceExists = "Race {0} is already created.";
    
        public const string RaceInvalid = "Race {0} cannot start with less than {1} participants.";
    }
}
