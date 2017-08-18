namespace _01.SingleInheritance
{
    internal class SingleInheritance
    {
        private static void Main()
        {
            Animal animal = new Animal();
            Dog dog = new Dog();

            animal.Eat();
            dog.Bark();
        }
    }
}