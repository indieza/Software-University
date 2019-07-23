namespace ValidationAttributes.Entities
{
    using ValidationAttributes.Attributes;

    public class Person
    {
        private const int MinValue = 12;
        private const int MaxValue = 90;

        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRequiredAttribute]
        public string FullName { get; private set; }

        [MyRangeAttribute(MinValue, MaxValue)]
        public int Age { get; private set; }
    }
}