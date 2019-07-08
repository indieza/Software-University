namespace MilitaryElite
{
    public class Mission : IMissions
    {
        private string state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; }

        public string State
        {
            get => this.state;
            set
            {
                if (value == "inProgress" || value == "Finished")
                {
                    this.state = value;
                }
                else
                {
                    this.state = null;
                }
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.state}";
        }
    }
}