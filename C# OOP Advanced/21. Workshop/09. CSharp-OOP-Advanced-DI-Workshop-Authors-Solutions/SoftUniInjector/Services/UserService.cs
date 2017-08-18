using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniInjector.Services
{
    using Repositories;

    public class UserService : IUserService
    {
        private readonly INeshtoSiInterface userRepo;
        private readonly ISoftUniRepository softuniRepo;


        public UserService(INeshtoSiInterface userRepo, 
            ISoftUniRepository softuniRepo, 
            DateTime myDateTime,
            string dbPath)
        {
            this.userRepo = userRepo;
            this.softuniRepo = softuniRepo;
            Console.WriteLine($"IN SERVICE DB PATH: {dbPath}");
            Console.WriteLine(myDateTime);
        }

        public void Rename()
        {
            Console.WriteLine("User service called");
            Console.WriteLine("service calls user repo");
            this.userRepo.Print();
            Console.WriteLine("service also calls softuni repo");
            this.softuniRepo.Oop();
        }
    }
}
