namespace SoftUniInjector.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using RegisteringModules;
    using Repositories;
    using Services;

    public class Container
    {
        private readonly Dictionary<Type, Type> dependencies;

        private readonly Dictionary<Type, object> cache;

        private readonly ResourceManager resourceManager;

        public Container(string resFile, Assembly assembly, params IRegisteringModule[] modules)
        {
            this.dependencies = new Dictionary<Type, Type>();
            this.cache = new Dictionary<Type, object>();
            this.resourceManager = new ResourceManager(resFile, assembly);
            this.InvokeModules(modules);
        }

        private void InvokeModules(IRegisteringModule[] modules)
        {
            foreach (IRegisteringModule module in modules)
            {
                module.Register(this.dependencies, this.cache);
            }
        }

        public T Get<T>()
        {
            var interfaceType = typeof(T);
            if (!interfaceType.GetTypeInfo().IsInterface 
                && !interfaceType.GetTypeInfo().IsAbstract)
            {
                throw new Exception("We can only make DI with Interfaces! You should depend on abstractions, man!");
            }

            return (T) this.Get(interfaceType);
        }

        private object Get(Type interfaceType)
        {
            if (this.cache.ContainsKey(interfaceType))
            {
                return this.cache[interfaceType];
            }

            Type concreteType = this.dependencies[interfaceType];

            ConstructorInfo ctorInfo = concreteType.GetConstructors().FirstOrDefault();

            ParameterInfo[] args = ctorInfo.GetParameters();

            List<object> argsList = new List<object>();
            foreach (ParameterInfo arg in args)
            {
                if (this.dependencies.ContainsKey(arg.ParameterType))
                {
                    Type argType = arg.ParameterType;
                    object obj = this.Get(argType);
                    argsList.Add(obj);
                }
                else
                {
                    string key = concreteType.FullName + "_" + arg.Name;
                    object valueToCast = this.resourceManager.GetString(key);
                    object castedValue = Convert.ChangeType(valueToCast, arg.ParameterType);
                    argsList.Add(castedValue);
                }
            }

            object objToCache = ctorInfo.Invoke(argsList.ToArray());
            this.cache[interfaceType] = objToCache;

            return objToCache;
        }
    }
}
