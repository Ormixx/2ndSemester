using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork2
{
    public class OrderedArray : ParentLongArray
    {
        public OrderedArray(int size) : base(size)
        {

        }

        public override bool Contains(long searchValue)
        {
            int operationsNumber = 0;
            int lowerBound = 0;
            int upperBound = nElems - 1;
            int currentIndex;

            while (true)
            {
                Console.WriteLine("Количество операций в упорядоченном массиве: " + ++operationsNumber);
                currentIndex = (lowerBound + upperBound) / 2;
                long currentElement = array[currentIndex];
                if (currentElement == searchValue)
                {
                    return true;
                }
                else if (lowerBound > upperBound)
                {
                    return false;
                }
                else
                {
                    if (currentElement < searchValue)
                    {
                        lowerBound = currentIndex + 1;
                    }
                    else
                    {
                        upperBound = currentIndex - 1;
                    }
                }
            }
        }

        public override bool Insert(long value)
        {
            if (this.Contains(value))
            {
                return false;
            }

            int i;
            for (i = 0; i < nElems; i++)
            {
                if (array[i] > value)
                {
                    break;
                }
            }

            for (int j = nElems; j > i; j--)
            {
                array[j] = array[j - 1];
            }

            array[i] = value;
            nElems++;
            return true;
        }

        public bool Delete(long searchValue)
        {
            int a = 0;
            int b = nElems - 1;
            int c = -1;

            while (a <= b)
            {
                int mid = (a + b) / 2;
                if (array[mid] == searchValue)
                {
                    c = mid;
                    break;
                }
                else if (array[mid] < searchValue)
                {
                    a = mid + 1;
                }
                else
                {
                    b = mid - 1;
                }
            }

            if (c == -1)
            {
                return false;
            }


            for (int i = c; i < nElems - 1; i++)
            {
                array[i] = array[i + 1];
            }

            nElems--;
            return true;
        }

        public long GetMax()
        {
            if (nElems == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }

            return array[nElems - 1];
        }

        public long GetMin()
        {
            if (nElems == 0)
            {
                throw new InvalidOperationException("Array is empty.");
            }

            return array[0];
        }
    }
}
