namespace SoftJail.DataProcessor
{
    using Data;
    using System;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            var prisoner = context.Prisoners.Find(prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.CellId = null;
            prisoner.ReleaseDate = DateTime.Now;

            context.Prisoners.Update(prisoner);
            context.SaveChanges();

            return $"Prisoner {prisoner.FullName} released";
        }
    }
}