namespace VaporStore.DataProcessor
{
    using Data;
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
            else if (context.Users.FirstOrDefault(u => u.Email == newEmail) != null)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.Users.Update(user);
            context.SaveChanges();

            return $"Changed {username}'s email successfully";
        }
    }
}