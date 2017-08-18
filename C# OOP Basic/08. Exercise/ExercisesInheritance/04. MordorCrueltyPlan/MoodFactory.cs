public class MoodFactory
{
    public static Mood ProduceMood(int happiness)
    {
        if (happiness < -5)
        {
            return new Angry();
        }

        if (happiness >= -5 && happiness < 0)
        {
            return new Sad();
        }

        if (happiness >= 0 && happiness < 15)
        {
            return new Happy();
        }

        return new JavaScript();
    }
}