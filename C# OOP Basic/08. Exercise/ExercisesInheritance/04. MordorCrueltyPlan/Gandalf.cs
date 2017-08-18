public class Gandalf
{
    private int Happiness { get; set; }

    private Mood Mood => MoodFactory.ProduceMood(this.Happiness);

    public void Eat(Food food)
    {
        this.Happiness += food.Happiness;
    }

    public override string ToString()
    {
        return $"{this.Happiness}\n{this.Mood}";
    }
}