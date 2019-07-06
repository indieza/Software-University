namespace FootballTeamGenerator.Models
{
    using FootballTeamGenerator.Constraints;
    using System;

    public class Stat
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get => this.endurance;

            private set
            {
                if (value < ConstantsRange.MinStatValue || value > ConstantsRange.MaxStatValue)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionsMessages.InvalidStatRangeException, nameof(Endurance)));
                }

                this.endurance = value;
            }
        }

        public int Sprint
        {
            get => this.sprint;

            private set
            {
                if (value < ConstantsRange.MinStatValue || value > ConstantsRange.MaxStatValue)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionsMessages.InvalidStatRangeException, nameof(Sprint)));
                }

                this.sprint = value;
            }
        }

        public int Dribble
        {
            get => this.dribble;

            private set
            {
                if (value < ConstantsRange.MinStatValue || value > ConstantsRange.MaxStatValue)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionsMessages.InvalidStatRangeException, nameof(Dribble)));
                }

                this.dribble = value;
            }
        }

        public int Passing
        {
            get => this.passing;

            private set
            {
                if (value < ConstantsRange.MinStatValue || value > ConstantsRange.MaxStatValue)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionsMessages.InvalidStatRangeException, nameof(Passing)));
                }

                this.passing = value;
            }
        }

        public int Shooting
        {
            get => this.shooting;

            private set
            {
                if (value < ConstantsRange.MinStatValue || value > ConstantsRange.MaxStatValue)
                {
                    throw new ArgumentException(
                        string.Format(ExceptionsMessages.InvalidStatRangeException, nameof(Shooting)));
                }

                this.shooting = value;
            }
        }

        public int SumTotalStats()
        {
            int sum = this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting;

            return sum;
        }
    }
}