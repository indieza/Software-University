
namespace Zoo
{
    using System;
    using System.Collections.Generic;
    using System.Text;


    public abstract class Mammal : Animal
    {
        protected Mammal(string name) 
            : base(name)
        {
        }
    }
}