namespace _04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake<T> : IEnumerable<T>
    {
        private IList<T> steps;
        private IList<T> stones;

        public Lake(IList<T> stones)
        {
            this.steps = new List<T>();
            this.stones = stones;
        }

        public IList<T> Steps
        {
            get { return this.steps; }
            set { this.steps = value; }
        }

        public IList<T> Stones
        {
            get { return this.stones; }
            set { this.stones = value; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var step in this.steps)
            {
                yield return step;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Move()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                this.steps.Add(this.stones[i]);
            }

            int indicator = this.stones.Count % 2;
            indicator++;

            for (int i = this.stones.Count - indicator; i >= 1; i -= 2)
            {
                this.steps.Add(this.stones[i]);
            }
        }
    }
}