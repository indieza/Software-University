using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TrojanInvasion
{
    public class TrojanInvasion
    {
        private static void Main()
        {
            int waves = int.Parse(Console.ReadLine());
            List<int> platesSpartanDefense = Console.ReadLine().Split().Select(int.Parse).ToList();
        }
    }
}