namespace SoftUniInjector.Core.RegisteringModules
{
    using System;
    using System.Collections.Generic;

    public interface IRegisteringModule
    {
        void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects);
    }
}
