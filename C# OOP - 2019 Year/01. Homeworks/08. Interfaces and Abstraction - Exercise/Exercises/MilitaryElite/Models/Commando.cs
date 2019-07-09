namespace MilitaryElite
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> missions;

        public Commando(int id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            this.missions = new List<IMission>();
        }

        public IReadOnlyCollection<IMission> Missions => this.missions.AsReadOnly();

        public void AddMission(IMission mission)
        {
            if (this.missions.Any(m => m.CodeName == mission.CodeName))
            {
                int index = this.missions.FindIndex(m => m.CodeName == mission.CodeName);
                this.missions[index].CompleteMission();
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine("Missions:");

            foreach (Mission mission in this.missions)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}