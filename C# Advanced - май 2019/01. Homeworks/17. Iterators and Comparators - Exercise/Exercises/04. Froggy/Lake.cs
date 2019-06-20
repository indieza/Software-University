namespace _04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake: IEnumerable<int>
    {
        public Lake(params int[] numbers)
        {
            Numbers = numbers;
        }

        public int[] Numbers { get;}
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Numbers.Length; i+=2)
            {
                yield return Numbers[i];
            }

            var lastNumber = this.Numbers.Length % 2 == 0
                ? this.Numbers.Length - 1
                : this.Numbers.Length - 2;
            for (int i = lastNumber; i >= 0; i-=2)
            {
                yield return this.Numbers[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
