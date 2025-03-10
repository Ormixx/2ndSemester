using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork1
{
    public class SortableLongArray : ParentLongArray
    {
        public SortableLongArray(int size) : base(size) { }

        public override bool Contains(long searchValue)
        {
            for (int i = 0; i < nElems; i++)
            {
                if (array[i] == searchValue)
                {
                    return true;
                }
            }
            return false;
        }

        public void BubbleSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            for (int i = 0; i < nElems - 1; i++)
            {
                for (int j = 0; j < nElems - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {

                        long temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        insertions++;
                    }
                }
            }
        }

        public void InsertionSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            for (int i = 1; i < nElems; i++)
            {
                long key = array[i];
                int j = i - 1;
                comparisons++;
                while (j >= 0 && array[j] > key)
                {
                    comparisons++;
                    array[j + 1] = array[j];
                    j--;
                    insertions++;
                }
                array[j + 1] = key;
                insertions++;
            }
        }

        public void SelectionSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            for (int i = 0; i < nElems - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < nElems; j++)
                {
                    comparisons++;
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    long temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                    insertions++;
                }
            }
        }
    }
}
