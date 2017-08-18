using System;
using System.Linq;

public class Sorter<T>
    where T : IComparable<T>
{
    public static CustomList<T> Sort(CustomList<T> customList)
    {
        var temp = customList.GetList().OrderBy(x => x).ToList();
        return new CustomList<T>(temp);
    }
}