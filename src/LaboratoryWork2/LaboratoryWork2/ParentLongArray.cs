using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork2
{
    public abstract class ParentLongArray : ArrayInterface
    {
        public abstract bool Contains(long searchValue);
        protected readonly long[] array;
        protected int nElems;

        public ParentLongArray(int size)
        {
            this.array = new long[size];
            this.nElems = 0;
        }

        public virtual bool Insert(long value)
        {
            for (int i = 0; i < nElems; i++)
            {
                if (array[i] == value)
                {
                    return false;
                }
            }

            array[nElems] = value;
            nElems++;
            return true;
        }

        public bool Delete(long value)
        {
            int i;
            for (i = 0; i < nElems; i++)
            {
                if (array[i] == value)
                {
                    break;
                }
            }

            if (i == nElems - 1)
            {
                return false;
            }
            else
            {
                for (int j = i; j < nElems - 1; j++)
                {
                    array[j] = array[j + 1];
                }
                nElems--;
                return true;
            }
        }

        public long GetMax()
        {
            long maxValue = long.MinValue;

            for (int i = 0; i < nElems; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        public long GetMin()
        {
            long minValue = long.MaxValue;

            for (int i = 0; i < nElems; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        public long Get(int index)
        {
            if (index < 0 || index >= nElems)
            {
                throw new IndexOutOfRangeException("Индекс выходит за пределы массива.");
            }
            return array[index];
        }

        public void Display()
        {
            for (int i = 0; i < nElems; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        public int GetSize()
        {
            return this.nElems;
        }
    }
}
