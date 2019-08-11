using System;
using ViceCity.IO.Contracts;

namespace ViceCity.IO
{
    internal class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}