namespace MXGP.Models.Motorcycles.Contracts
{
    public interface IMotorcycle
    {
        string Model { get; }

        int HorsePower { get; }

        double CubicCentimeters { get; }

        double CalculateRacePoints(int laps);
    }
}
