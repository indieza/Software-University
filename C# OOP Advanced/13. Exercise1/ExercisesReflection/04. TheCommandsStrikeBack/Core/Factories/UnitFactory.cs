namespace _04.TheCommandsStrikeBack.Core.Factories
{
    using System;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var typeInfo =
                Type.GetType("_04.TheCommandsStrikeBack.Models.Units." + unitType);

            var iunit = Activator.CreateInstance(typeInfo) as IUnit;

            return iunit;
        }
    }
}