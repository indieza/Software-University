namespace MortalEngines.Entities.Contracts
{
    using System.Collections.Generic;

    public interface IMachine
    {
        string Name { get; }

        IPilot Pilot { get; set; }

        double HealthPoints { get; set; }

        double AttackPoints { get; }

        double DefensePoints { get; }

        IList<string> Targets { get; }

        void Attack(IMachine target);

        string ToString();
    }
}