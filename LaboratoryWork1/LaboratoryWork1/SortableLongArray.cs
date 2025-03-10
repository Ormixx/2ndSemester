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

        // Алгоритм сортировки Шелла с последовательностью Седжвика
        public void SedgewickShellSort(out int comparisons, out int insertions)
        {
            comparisons = 0;
            insertions = 0;
            int[] gaps = { 1, 5, 19, 41, 109 }; // Примерные значения последовательности Седжвика
            int gapIndex = gaps.Length - 1;

            while (gapIndex >= 0)
            {
                int h = gaps[gapIndex];
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
                gapIndex--;
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
    }
}
