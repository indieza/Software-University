namespace MortalEngines.Models
{
    using MortalEngines.Common;
    using MortalEngines.Entities.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseMachine : IMachine
    {
        private string name;
        private IPilot pilot;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.HealthPoints = healthPoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.EmptyMachineName);
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get => this.pilot;

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.EmptyPilot);
                }

                this.pilot = value;
            }
        }

        public double HealthPoints
        {
            get => this.healthPoints;

            set => this.healthPoints = value;
        }

        public double AttackPoints
        {
            get => this.attackPoints;

            protected set => this.attackPoints = value;
        }

        public double DefensePoints
        {
            get => this.defensePoints;

            protected set => this.defensePoints = value;
        }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.EmptyTarget);
            }

            double difference = Math.Abs(this.AttackPoints - target.DefensePoints);
            target.HealthPoints -= difference;

            if (target.HealthPoints < 0)
            {
                target.HealthPoints = 0;
            }

            this.Targets.Add(target.Name);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"- {this.Name}");
            sb.AppendLine($" *Type: {this.GetType().Name}");
            sb.AppendLine($" *Health: {this.HealthPoints:F2}");
            sb.AppendLine($" *Attack: {this.AttackPoints:F2}");
            sb.AppendLine($" *Defense: {this.DefensePoints:F2}");

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");
            }
            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", this.Targets)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}