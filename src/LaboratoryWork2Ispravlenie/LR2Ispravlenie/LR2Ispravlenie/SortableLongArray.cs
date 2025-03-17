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

        // с рекурсией
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

        // без рекурсии
        public void QuickSortNonRecursive(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            QuickSortNonRecursiveHelper(0, nElems - 1, ref comparisons, ref insertions);
        }

        private void QuickSortNonRecursiveHelper(int left, int right, ref int comparisons, ref int insertions)
        {
            Stack<(int left, int right)> stack = new Stack<(int, int)>();
            stack.Push((left, right));

            while (stack.Count > 0)
            {
                var (currentLeft, currentRight) = stack.Pop();
                if (currentRight - currentLeft + 1 <= 3)
                {
                    InsertionSort(currentLeft, currentRight, ref insertions);
                }
                else
                {
                    long pivot = MedianOfThreePoints(currentLeft, currentRight);
                    int pivotIndex = Partition(currentLeft, currentRight, pivot, ref comparisons, ref insertions);
                    if (pivotIndex - 1 > currentLeft)
                        stack.Push((currentLeft, pivotIndex - 1));
                    if (pivotIndex + 1 < currentRight)
                        stack.Push((pivotIndex + 1, currentRight));
                }
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
                do { leftPtr++; } while (array[leftPtr] < pivot);
                do { rightPtr--; } while (array[rightPtr] > pivot);

                if (leftPtr >= rightPtr) break;
                else Swap(leftPtr, rightPtr);
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
    }
}
