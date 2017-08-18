using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniInjector.Core.RegisteringModules
{
    using System.Reflection;

    public abstract class AbstractRegisteringModule
        : IRegisteringModule
    {
        protected Assembly Assembly { get; }

        protected AbstractRegisteringModule(Assembly assembly)
        {
            this.Assembly = assembly;
        }

        public abstract void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects);
    }
}
