namespace SoftUniInjector.Repositories
{
    using System;

    public class DefaultSoftUniRepository
        : ISoftUniRepository
    {
        private readonly IPaymentsRepository
            paymentsRepo;

        public DefaultSoftUniRepository(IPaymentsRepository paymentsRepo, string dbPath)
        {
            this.paymentsRepo = paymentsRepo;
            Console.WriteLine($"DB PATH FROM REPO {dbPath}");
        }

        public void Oop()
        {
            Console.WriteLine("softuni repo called");
            Console.WriteLine("softuni repo tries " +
                              "to call payments repo");
            this.paymentsRepo.Pay();
        }
    }
}
