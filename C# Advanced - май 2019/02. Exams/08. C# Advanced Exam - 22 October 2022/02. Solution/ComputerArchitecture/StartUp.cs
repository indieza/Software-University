using System;

namespace ComputerArchitecture
{
    public class StartUp
    {
        private static void Main(string[] args)
        {
            // Initialize the repository
            Computer computer = new Computer("Gaming Serioux", 4);

            // Initialize entity
            CPU cpu = new CPU("AMD Ryzen 5", 6, 3.7);

            // Print CPU
            Console.WriteLine(cpu);
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz

            // Add CPU
            computer.Add(cpu);

            // Remove CPU
            Console.WriteLine(computer.Remove("Intel Core i5"));
            // False

            CPU secondCPU = new CPU("Intel Core i7", 8, 4);
            CPU thirdCPU = new CPU("Intel Core i5", 8, 3.9);

            // Add CPU
            computer.Add(secondCPU);
            computer.Add(thirdCPU);

            CPU mostPowerful = computer.MostPowerful();
            Console.WriteLine(mostPowerful);
            // Intel Core i7 CPU:
            // Cores: 8
            // Frequency: 4.0 GHz

            CPU receivedCPU = computer.GetCPU("Intel Core i5");
            Console.WriteLine(receivedCPU);
            // Intel Core i5 CPU:
            // Cores: 8
            // Frequency: 3.9 GHz

            Console.WriteLine(computer.Count);
            // 3
            Console.WriteLine(computer.Remove("Intel Core i5"));
            // True

            Console.WriteLine(computer.Report());
            // CPUs in the Computer Gaming Serioux:
            // AMD Ryzen 5 CPU:
            // Cores: 6
            // Frequency: 3.7 GHz
            // Intel Core i7 CPU:
            // Cores: 8
            // Frequency: 4.0 GHz
        }
    }
}