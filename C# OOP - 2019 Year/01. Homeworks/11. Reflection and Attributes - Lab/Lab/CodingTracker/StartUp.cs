[Author("Ventsi")]
public class StartUp
{
    [Author("Gosho")]
    private static void Main()
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}