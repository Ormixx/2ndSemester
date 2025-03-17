using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR2Ispravlenie
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

        // Алгоритм быстрой сортировки
        public void QuickSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            QuickSortHelper(0, nElems - 1, ref comparisons, ref insertions);
        }

        private void QuickSortHelper(int left, int right, ref int comparisons, ref int insertions)
        {
            if (left < right)
            {
                int pivotIndex = Partition(left, right, ref comparisons, ref insertions);
                QuickSortHelper(left, pivotIndex - 1, ref comparisons, ref insertions);
                QuickSortHelper(pivotIndex + 1, right, ref comparisons, ref insertions);
            }
        }

        private int Partition(int left, int right, ref int comparisons, ref int insertions)
        {
            long pivot = array[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                comparisons++;
                if (array[j] <= pivot)
                {
                    i++;
                    Swap(i, j);
                    insertions++;
                }
            }
            Swap(i + 1, right);
            insertions++;
            return i + 1;
        }

        private void InsertionSort(int left, int right, ref int insertions)
        {
            for (int i = left + 1; i <= right; i++)
            {
                long key = array[i];
                int j = i - 1;

                while (j >= left && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    insertions++;
                }
                array[j + 1] = key;
                insertions++;
            }
        }


        private void Swap(int index1, int index2)
        {
            long temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
