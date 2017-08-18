
namespace SoftUniInjector.Core.RegisteringModules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class SingleImplementationModule
        : AbstractRegisteringModule
    {
        public SingleImplementationModule(Assembly assembly) : base(assembly)
        {
        }

        public override void Register(IDictionary<Type, Type> types, IDictionary<Type, object> objects)
        {
            Type[] allTypes = this.Assembly.GetTypes();
            Type[] abstractions
                = allTypes.Where(t => t.GetTypeInfo().IsInterface)
                    .Where(t => t.GetTypeInfo().IsAbstract)
                    .ToArray();
            Type[] concreteTypes = allTypes.Except(abstractions).ToArray();

            foreach (Type abstraction in abstractions)
            {
                Type[] implementations = concreteTypes.Where(t => t.GetInterfaces().Contains(abstraction))
                    .ToArray();
                if (implementations.Length != 1)
                {
                    continue;
                }
                Type singleImplementations = implementations[0];
                types[abstraction] = singleImplementations;
            }
        }
    }
}
