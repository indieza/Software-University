namespace SoftUniInjector.Repositories
{
    using System;

    public class DefaultPaymentsRepository
        : IPaymentsRepository
    {
        private readonly IAnotherRepository anotherRepo;

        public DefaultPaymentsRepository(IAnotherRepository anotherRepo)
        {
            Console.WriteLine("Constructor of payments called!");
            this.anotherRepo = anotherRepo;
        }

        public void Pay()
        {
            Console.WriteLine("payment repo called");
            this.anotherRepo.AndMe();
        }
    }
}
