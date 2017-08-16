public class StreetExtraordinaire : Cat
{
    private decimal decibelsOfMeows;

    public decimal DecibelsOfMeows
    {
        get { return this.decibelsOfMeows; }
        set { this.decibelsOfMeows = value; }
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.decibelsOfMeows}";
    }
}