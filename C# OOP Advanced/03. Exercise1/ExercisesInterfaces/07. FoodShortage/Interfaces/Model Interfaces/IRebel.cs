public interface IRebel : IName, IAge, IBuyer
{
    string Group { get; set; }

    int Food { get; set; }
}