using System;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
         //TODO Add IEngine
         Motorcycle varche = new PowerMotorcycle("12214235", 75);
         Console.WriteLine(varche.HorsePower);
        }
    }
}
