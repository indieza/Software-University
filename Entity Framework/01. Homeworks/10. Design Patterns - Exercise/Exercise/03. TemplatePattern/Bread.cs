namespace _03._TemplatePattern
{
    using System;

    public abstract class Bread
    {
        public abstract void MixIngredients(); public abstract void Bake(); public virtual void Slice()

        {
            Console.WriteLine("Slicing the " + GetType().Name + " bread!");
        }

        // The template method
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}