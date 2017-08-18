namespace SoftUniInjector
{
    using System;
    using System.Reflection;
    using System.Resources;
    using Core;
    using Core.RegisteringModules;
    using Repositories;
    using Resources;
    using Services;

    internal class Program
    {
        private static void Main()
        {
            var container = new Container(
                typeof(Vars).FullName,
                Assembly.GetEntryAssembly(),
                new ManualRegisteringModule()
                    .Register<ISoftUniRepository, DefaultSoftUniRepository>()
                    .Register<IPaymentsRepository, DefaultPaymentsRepository>()
                    .Register<IUserService, UserService>(),
                new AttributeRegisteringModule(Assembly.GetEntryAssembly())
            );
            var userService = container.Get<IUserService>();

            userService.Rename();
        }
    }
}