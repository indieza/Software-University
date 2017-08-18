using System;

namespace SoftUniInjector.Repositories
{
    using Core.Attributes;

    [InjectionCandidate]
    public class DefaultUserRepository
        : IUserRepository, INeshtoSiInterface
    {
        private readonly IPaymentsRepository
            paymentsRepo;

        private readonly ISoftUniRepository
            softUniRepo;

        private int count;

        public DefaultUserRepository(
            IPaymentsRepository paymentsRepo, 
            int count,
            ISoftUniRepository softUniRepo)
        {
            this.paymentsRepo = paymentsRepo;
            this.softUniRepo = softUniRepo;
            this.count = count;
        }

        public void Print()
        {
            Console.WriteLine($"My count is {++this.count}");
            Console.WriteLine("User repo called!");
            Console.WriteLine("User repo calling payments repo");
            this.paymentsRepo.Pay();
            Console.WriteLine("User repo calling also softuni repo");
            this.softUniRepo.Oop();
        }
    }
}
