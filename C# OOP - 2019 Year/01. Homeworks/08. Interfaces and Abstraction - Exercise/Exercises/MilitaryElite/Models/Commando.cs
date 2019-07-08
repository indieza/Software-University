namespace MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : Private
    {
        private readonly List<Mission> missions;
        private string corps;

        public Commando(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = corps;
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions => this.missions.AsReadOnly();

        public string Corps
        {
            get => this.corps;

            private set
            {
                if (value != "Airforces" && value != "Marines")
                {
                    throw new Exception("Invalid input");
                }

                this.corps = value;
            }
        }

        public void AddMission(Mission mission)
        {
            if (missions.Any(x => x.CodeName == mission.CodeName))
            {
                int index = missions.FindIndex(x => x.CodeName == mission.CodeName);
                missions[index].CompleteMission();
            }
            else
            {
                if (mission.State != null)
                {
                    this.missions.Add(mission);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder commandoInfo = new StringBuilder();

            commandoInfo.AppendLine($"Corps: {this.corps}");
            commandoInfo.AppendLine("Missions:");

            foreach (var mission in Missions)
            {
                commandoInfo.AppendLine(" " + mission);
            }

            return base.ToString() + Environment.NewLine + commandoInfo.ToString().TrimEnd();
        }
    }
}