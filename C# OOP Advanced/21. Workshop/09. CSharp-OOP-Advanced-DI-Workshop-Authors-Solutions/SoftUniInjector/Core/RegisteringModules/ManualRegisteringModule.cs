namespace SoftUniInjector.Core.RegisteringModules
{
    using System;
    using System.Collections.Generic;

    public class ManualRegisteringModule : IRegisteringModule
    {
        private readonly Dictionary<Type, Type>
            dependencies;

        private readonly Dictionary<Type, object> cache;

        public ManualRegisteringModule()
        {
            this.dependencies = new Dictionary<Type, Type>();
            this.cache = new Dictionary<Type, object>();
        }

        public ManualRegisteringModule Register<TAbstr, TImpl>()
            where TImpl : TAbstr
        {
            this.dependencies[typeof(TAbstr)] = typeof(TImpl);

            return this;
        }

        public void Register(IDictionary<Type, Type> types, 
            IDictionary<Type, object> objects)
        {
            foreach (KeyValuePair<Type, Type> dependency in this.dependencies)
            {
                types[dependency.Key] = dependency.Value;
            }

            foreach (KeyValuePair<Type, object> cachedObj in this.cache)
            {
                objects[cachedObj.Key] = cachedObj.Value;
            }
        }
    }
}
