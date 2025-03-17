using LR2Ispravlenie;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string separator = "__________________________________________________________";
        Random random = new Random();
        int size = 100000;
        SortableLongArray sortableArray = new SortableLongArray(size);        
        Stopwatch stopwatch = new Stopwatch();

        // Тестирование быстрой сортировки
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        int quickComparisons, quickInsertions;
        sortableArray.QuickSort(out quickComparisons, out quickInsertions);
        stopwatch.Stop();
        Console.WriteLine("Quick Sort: Сравнения = " + quickComparisons + ", Вставки = " + quickInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");
    }
}
