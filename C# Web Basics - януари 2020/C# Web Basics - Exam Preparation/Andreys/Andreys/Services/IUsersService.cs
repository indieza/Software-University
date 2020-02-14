namespace Andreys.Services
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Register(string username, string email, string password);

        bool UsernameExists(string username);
    }
}