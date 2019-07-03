
namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Reptile : Animal
    {
        protected Reptile(string name) 
            : base(name)
        {
        }
    }
}