using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Ispravlenie
{
    public class CommonArray : ParentLongArray
    {
        public CommonArray(int size) : base(size)
        {
        }

        public override bool Contains(long searchValue)
        {
            int operationsNumber = 0;

            for (int i = 0; i < nElems; i++)
            {
                Console.WriteLine("Количество операций в неупорядоченном массиве: " + ++operationsNumber);
                if (array[i] == searchValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
