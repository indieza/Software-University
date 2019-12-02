namespace SoftJail.DataProcessor
{
    using Data;
    using SoftJail.Data.Models;
    using System;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            Prisoner prisoner = context.Prisoners.Find(prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.ReleaseDate = DateTime.Now;
            prisoner.CellId = null;

            context.Prisoners.Update(prisoner);
            context.SaveChanges();

            return $"Prisoner {prisoner.FullName} released";
        }
    }
}