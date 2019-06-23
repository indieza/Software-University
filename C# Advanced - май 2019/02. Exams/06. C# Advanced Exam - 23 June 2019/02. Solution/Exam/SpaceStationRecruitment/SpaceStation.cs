namespace SpaceStationRecruitment
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SpaceStation
    {
        private List<Astronaut> data;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Astronaut astronaut)
        {
            if (this.data.Count() < this.Capacity)
            {
                this.data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            if (this.data.FirstOrDefault(a => a.Name == name) != null)
            {
                this.data.Remove(this.data.FirstOrDefault(a => a.Name == name));
                return true;
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            int max = this.data.Max(a => a.Age);
            return this.data.FirstOrDefault(a => a.Age == max);
        }

        public Astronaut GetAstronaut(string name)
        {
            return this.data.FirstOrDefault(a => a.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}