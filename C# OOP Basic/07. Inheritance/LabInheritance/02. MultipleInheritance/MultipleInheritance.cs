namespace _02.MultipleInheritance
{
    internal class MultipleInheritance
    {
        private static void Main()
        {
            Animal animal = new Animal();
            Dog dog = new Dog();
            Puppy puppy = new Puppy();

            animal.Eat();
            dog.Bark();
            puppy.Weep();
        }
    }
}