namespace _04.TheCommandsStrikeBack.Core.Commands
{
    using Contracts;

    public class RetireCommand : Command
    {
        public RetireCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data, repository, unitFactory)
        {
        }

        public override string Execute()
        {
            this.Repository.RemoveUnit(this.Data[1]);
            var output = $"{this.Data[1]} retired!";

            return output;
        }
    }
}