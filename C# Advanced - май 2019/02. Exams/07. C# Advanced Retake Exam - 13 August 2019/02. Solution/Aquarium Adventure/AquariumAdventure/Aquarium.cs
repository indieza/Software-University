namespace AquariumAdventure
{
    using System.Collections.Generic;
    using System.Text;

    public class Aquarium
    {
        private readonly Dictionary<string, Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new Dictionary<string, Fish>();
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int Size { get; private set; }

        public void Add(Fish fish)
        {
            if (!this.fishInPool.ContainsKey(fish.Name) && this.fishInPool.Count + 1 <= Capacity)
            {
                this.fishInPool.Add(fish.Name, fish);
            }
        }

        public bool Remove(string name)
        {
            return this.fishInPool.Remove(name);
        }

        public Fish FindFish(string name)
        {
            if (this.fishInPool.ContainsKey(name))
            {
                return this.fishInPool[name];
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (Fish fish in this.fishInPool.Values)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}