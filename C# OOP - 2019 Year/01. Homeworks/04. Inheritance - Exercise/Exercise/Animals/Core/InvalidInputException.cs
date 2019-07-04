namespace Animals.Core
{
    using System;

    public class InvalidInputException : Exception
    {
        public override string Message => "Invalid input!";
    }
}