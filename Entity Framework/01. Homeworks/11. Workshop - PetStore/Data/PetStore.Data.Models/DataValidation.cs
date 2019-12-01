namespace PetStore.Data.Models
{
    public static class DataValidation
    {
        public const int NameMaxLength = 30;
        public const int DescriptionMaxLength = 1000;
        
        public static class User
        {
            public const int EmailMaxLength = 100;
        }
    }
}
