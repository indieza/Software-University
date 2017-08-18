using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniInjector.Repositories
{
    using Core.Attributes;

    public class DefaultNeshtoRepo : INeshtoSiInterface
    {
        public void Print()
        {
            Console.WriteLine("Neshto si here!");
        }
    }

}
