namespace BirthdayCelebrations
{
    public abstract class Entered
    {
        private string id;

        protected Entered(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get => this.id;
            private set => this.id = value;
        }
    }
}