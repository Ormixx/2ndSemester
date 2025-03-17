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

        // Алгоритм сортировки Шелла с последовательностью Седжвика
        public void SedgewickShellSort(out int comparisons, out int insertions)
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

        // Алгоритм сортировки Шелла с последовательностью Хиббарда
        public void HibbardShellSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            int h = 1;

            while (h <= nElems / 2)
            {
                h = h * 2 + 1;
            }

            while (h > 0)
            {
                for (int outer = h; outer < nElems; outer++)
                {
                    long temp = array[outer];
                    int inner = outer;
                    while (inner >= h && array[inner - h] > temp)
                    {
                        comparisons++;
                        array[inner] = array[inner - h];
                        inner -= h;
                        insertions++;
                    }
                    array[inner] = temp;
                    insertions++;
                }
                h = (h - 1) / 2;
            }
        }

        // Алгоритм сортировки Шелла с простым делением на 2
        public void SimpleDivShellSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            int h = nElems / 2;

            while (h > 0)
            {
                for (int outer = h; outer < nElems; outer++)
                {
                    long temp = array[outer];
                    int inner = outer;
                    while (inner >= h && array[inner - h] > temp)
                    {
                        comparisons++;
                        array[inner] = array[inner - h];
                        inner -= h;
                        insertions++;
                    }
                    array[inner] = temp;
                    insertions++;
                }
                h /= 2;
            }
        }

        // Алгоритм сортировки Шелла методом Кнута
        public void ShellSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            int h = 1;

            while (h <= nElems / 3)
            {
                h = h * 3 + 1;
            }

            while (h > 0)
            {
                for (int outer = h; outer < nElems; outer++)
                {
                    long temp = array[outer];
                    int inner = outer;
                    while (inner > h - 1 && array[inner - h] >= temp)
                    {
                        comparisons++;
                        array[inner] = array[inner - h];
                        inner -= h;
                        insertions++;
                    }
                    array[inner] = temp;
                    insertions++;
                }
                h = (h - 1) / 3;
            }
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

        private void Swap(int index1, int index2)
        {
            long temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
    }
}
