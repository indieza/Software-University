namespace _03BarracksFactory.Core.Factories
{
    using _03BarracksFactory.Models.Units;
    using Contracts;
    using System;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType($"{typeof(Unit).Namespace}.{unitType}");
            Unit unit = (Unit)Activator.CreateInstance(type, new object[] { });

            return unit;
        }
    }
}