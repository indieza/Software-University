namespace SoftUniInjector.Repositories
{
    using System;
    using Core.Attributes;

    [InjectionCandidate]
    public class AnotherRepository : IAnotherRepository
    {
        public void AndMe()
        {
            Console.WriteLine("I was added later, and the app should work");
        }
    }
}
