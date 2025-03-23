using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork3
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
        // Быстрая сортировка
        public void QuickSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            QuickSortHelper(0, nElems - 1, ref comparisons, ref insertions);
        }

        private void QuickSortHelper(int left, int right, ref int comparisons, ref int insertions)
        {
            if (right - left + 1 <= 3)
            {
                InsertionSort(left, right, ref insertions);
            }
            else
            {
                long pivot = MedianOfThreePoints(left, right);
                int pivotIndex = Partition(left, right, pivot, ref comparisons, ref insertions);
                QuickSortHelper(left, pivotIndex - 1, ref comparisons, ref insertions);
                QuickSortHelper(pivotIndex + 1, right, ref comparisons, ref insertions);
            }
        }

        private long MedianOfThreePoints(int left, int right)
        {
            int center = (left + right) / 2;
            if (array[left] > array[center]) Swap(left, center);
            if (array[left] > array[right]) Swap(left, right);
            if (array[center] > array[right]) Swap(center, right);
            Swap(center, right - 1);
            return array[right - 1];
        }

        private int Partition(int left, int right, long pivot, ref int comparisons, ref int insertions)
        {
            int leftPtr = left;
            int rightPtr = right - 1;

            while (true)
            {
                while (leftPtr <= rightPtr && array[leftPtr] < pivot)
                {
                    leftPtr++;
                    comparisons++;
                }

                while (leftPtr <= rightPtr && array[rightPtr] > pivot)
                {
                    rightPtr--;
                    comparisons++;
                }

                if (leftPtr >= rightPtr) break;

                Swap(leftPtr, rightPtr);
            }
            Swap(leftPtr, right - 1);
            insertions++;
            return leftPtr;
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

        // Сортировка слиянием
        public void MergeSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            long[] tempArray = new long[nElems];
            MergeSort(tempArray, 0, nElems - 1, ref comparisons, ref insertions);
        }

        private void MergeSort(long[] tempArray, int left, int right, ref int comparisons, ref int insertions)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSort(tempArray, left, middle, ref comparisons, ref insertions);
                MergeSort(tempArray, middle + 1, right, ref comparisons, ref insertions);
                Merge(tempArray, left, middle, right, ref comparisons, ref insertions);
            }
        }

        private void Merge(long[] tempArray, int left, int middle, int right, ref int comparisons, ref int insertions)
        {
            int i = left;
            int j = middle + 1;
            int k = left;

            while (i <= middle && j <= right)
            {
                comparisons++;
                if (array[i] <= array[j])
                {
                    tempArray[k++] = array[i++];
                }
                else
                {
                    tempArray[k++] = array[j++];
                }
            }

            while (i <= middle)
            {
                tempArray[k++] = array[i++];
                insertions++;
            }

            while (j <= right)
            {
                tempArray[k++] = array[j++];
                insertions++;
            }

            for (i = left; i <= right; i++)
            {
                array[i] = tempArray[i];
            }
        }

        // Сортировки Шелла
        public void ShellSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;

            List<int> gaps = new List<int>();
            int k = 0;
            int h;

            do
            {
                h = 9 * (int)Math.Pow(4, k) - 9 * (int)Math.Pow(2, k) + 1;
                if (h > 0)
                    gaps.Add(h);
                k++;
            } while (h <= nElems);

            for (int gapIndex = gaps.Count - 1; gapIndex >= 0; gapIndex--)
            {
                int hValue = gaps[gapIndex];
                for (int outer = hValue; outer < nElems; outer++)
                {
                    long temp = array[outer];
                    int inner = outer;
                    while (inner >= hValue && array[inner - hValue] > temp)
                    {
                        comparisons++;
                        array[inner] = array[inner - hValue];
                        inner -= hValue;
                        insertions++;
                    }
                    array[inner] = temp;
                    insertions++;
                }
            }
        } 
    }
}
