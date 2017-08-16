using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface ICourse : IComparable<ICourse>
    {
        string Name { get; }
        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EntrollStudent(IStudent student);
    }
}