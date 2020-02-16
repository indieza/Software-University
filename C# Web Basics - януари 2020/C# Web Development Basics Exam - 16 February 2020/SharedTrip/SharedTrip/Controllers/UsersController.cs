namespace SharedTrip.Controllers
{
    using SharedTrip.Services;
    using SharedTrip.ViewModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private const int MinPasswordLength = 6;
        private const int MaxPasswordLength = 20;
        private const int MinUsernameLength = 5;
        private const int MaxUsernameLength = 20;

        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId != null)
            {
                this.SignIn(userId);
                return this.Redirect("/Trips/All");
            }

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Password.Length < MinPasswordLength || input.Password.Length > MaxPasswordLength)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Username.Length < MinUsernameLength || input.Username.Length > MaxUsernameLength)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (string.IsNullOrWhiteSpace(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.EmailExists(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}