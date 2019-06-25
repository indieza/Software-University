namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random random = new Random();
            int index = random.Next(0, this.Count);
            string randomString = this[index];
            this.Remove(randomString);
            return randomString;
        }
    }
}