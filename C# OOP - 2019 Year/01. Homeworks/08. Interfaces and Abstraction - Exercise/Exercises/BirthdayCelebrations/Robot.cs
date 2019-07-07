namespace BirthdayCelebrations
{
    public class Robot : Entered
    {
        private string model;

        public Robot(string model, string id)
            : base(id)
        {
            this.Model = model;
        }

        public string Model
        {
            get => model;
            private set => this.model = value;
        }
    }
}