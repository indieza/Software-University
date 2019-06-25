namespace CustomStack
{
    using System.Collections.Generic;

    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public Stack<string> AddRange(params string[] inputs)
        {
            foreach (var input in inputs)
            {
                this.Push(input);
            }

            return this;
        }
    }
}