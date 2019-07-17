namespace P04.Recharge
{
    public abstract class Worker : ISleeper, IRechargeable
    {
        private string id;
        private int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public void Work(int hours)
        {
            this.workingHours += hours;
        }

        public abstract void Sleep();

        public abstract void Recharge();
    }
}