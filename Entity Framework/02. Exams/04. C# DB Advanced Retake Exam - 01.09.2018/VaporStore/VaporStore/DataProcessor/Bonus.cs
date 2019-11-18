namespace VaporStore.DataProcessor
{
    using Data;
    using System;
    using System.Linq;
    using VaporStore.Data.Models;

    public static class Bonus
    {
        public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
        {
            User user = context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                return $"User {username} not found";
            }

            var isEmailExist = context.Users.Any(u => u.Email == newEmail);

            if (isEmailExist)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.SaveChanges();

            return $"Changed {username}'s email successfully";
        }
    }
}