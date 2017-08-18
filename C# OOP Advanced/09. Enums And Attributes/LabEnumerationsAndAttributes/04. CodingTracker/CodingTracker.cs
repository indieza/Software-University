namespace _04.CodingTracker
{
    [SoftUni("Ventsi")]
    internal class CodingTracker
    {
        [SoftUni("Gosho")]
        private static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}