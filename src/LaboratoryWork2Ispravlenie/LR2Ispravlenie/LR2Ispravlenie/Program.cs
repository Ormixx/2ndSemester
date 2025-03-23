using LR2Ispravlenie;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string separator = "__________________________________________________________";
        Random random = new Random();
        int size = 100000;

        // Тестирование с рекурсией
        SortableLongArray sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Restart();
        int quickComparisons, quickInsertions;
        sortableArray.QuickSort(out quickComparisons, out quickInsertions);
        stopwatch.Stop();
        Console.WriteLine("Quick Sort (с рекурсией): Сравнения = " + quickComparisons + ", Вставки = " + quickInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");

        Console.WriteLine(separator);

        // Тестирование без рекурсии
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        int quickNonRecursiveComparisons, quickNonRecursiveInsertions;
        sortableArray.QuickSortNonRecursive(out quickNonRecursiveComparisons, out quickNonRecursiveInsertions);
        stopwatch.Stop();
        Console.WriteLine("Quick Sort (без рекурсии): Сравнения = " + quickNonRecursiveComparisons + ", Вставки = " + quickNonRecursiveInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
