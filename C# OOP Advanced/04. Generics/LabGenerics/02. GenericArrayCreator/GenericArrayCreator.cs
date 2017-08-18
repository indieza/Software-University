namespace _02.GenericArrayCreator
{
    internal class GenericArrayCreator
    {
        private static void Main()
        {
            string[] strings = ArrayCreator.Create(5, "Pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}