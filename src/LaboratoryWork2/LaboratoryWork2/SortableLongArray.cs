using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork2
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

        public void QuickSort()
        {
            Stack<(int left, int right)> stack = new Stack<(int, int)>();
            stack.Push((0, nElems - 1));

            while (stack.Count > 0)
            {
                var (left, right) = stack.Pop();
                if (right - left + 1 <= 3)
                {
                    ManualSort(left, right);
                }
                else
                {
                    long pivot = MedianOfThreePoints(left, right);
                    int partitionIndex = Partition(left, right, pivot);

                    stack.Push((left, partitionIndex - 1));
                    stack.Push((partitionIndex + 1, right));
                }
            }
        }

        private long MedianOfThreePoints(int leftIndex, int rightIndex)
        {
            int center = (leftIndex + rightIndex) / 2;

            if (array[leftIndex] > array[center])
                Swap(leftIndex, center);
            if (array[leftIndex] > array[rightIndex])
                Swap(leftIndex, rightIndex);
            if (array[center] > array[rightIndex])
                Swap(center, rightIndex);

            Swap(center, rightIndex - 1);
            return array[rightIndex - 1];
        }

        private void ManualSort(int leftIndex, int rightIndex)
        {
            int size = rightIndex - leftIndex + 1;
            if (size <= 1) return;

            if (size == 2)
            {
                if (array[leftIndex] > array[rightIndex])
                    Swap(leftIndex, rightIndex);
            }
            else
            {
                if (array[leftIndex] > array[rightIndex - 1])
                    Swap(leftIndex, rightIndex - 1);
                if (array[leftIndex] > array[rightIndex])
                    Swap(leftIndex, rightIndex);
                if (array[rightIndex - 1] > array[rightIndex])
                    Swap(rightIndex - 1, rightIndex);
            }
        }

        private int Partition(int leftIndex, int rightIndex, long pivot)
        {
            int leftPtr = leftIndex;
            int rightPtr = rightIndex - 1;

            while (true)
            {
                do { leftPtr++; } while (array[leftPtr] < pivot);
                do { rightPtr--; } while (array[rightPtr] > pivot);

                if (leftPtr >= rightPtr)
                    break;

                Swap(leftPtr, rightPtr);
            }
            Swap(leftPtr, rightIndex - 1);
            return leftPtr;
        }

        private void Swap(int index1, int index2)
        {
            long temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
