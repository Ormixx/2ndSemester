using LaboratoryWork3;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string separator = "__________________________________________________________";
        Random random = new Random();
        int size = 100000;
        SortableLongArray sortableArray = new SortableLongArray(size);
        CommonArray commonArray = new CommonArray(size);
        OrderedArray orderedArray = new OrderedArray(size);


        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        var stopwatch = Stopwatch.StartNew();
        sortableArray.MergeSort(out int mergeComparisons, out int mergeInsertions);
        stopwatch.Stop();
        Console.WriteLine($"Merge Sort: Сравнения = {mergeComparisons}, Вставки = {mergeInsertions}, Время = {stopwatch.ElapsedMilliseconds} ms");

        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        sortableArray.QuickSort(out int quickComparisons, out int quickInsertions);
        stopwatch.Stop();
        Console.WriteLine($"Quick Sort: Сравнения = {quickComparisons}, Вставки = {quickInsertions}, Время = {stopwatch.ElapsedMilliseconds} ms");

        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        sortableArray.ShellSort(out int shellComparisons, out int shellInsertions);
        stopwatch.Stop();
        Console.WriteLine($"Shell Sort: Сравнения = {shellComparisons}, Вставки = {shellInsertions}, Время = {stopwatch.ElapsedMilliseconds} ms");

        Console.WriteLine(separator);
        Console.WriteLine("Сравнение результатов сортировки:");
        Console.WriteLine($"Merge Sort: {mergeComparisons} сравнений, {mergeInsertions} вставок.");
        Console.WriteLine($"Quick Sort: {quickComparisons} сравнений, {quickInsertions} вставок.");
        Console.WriteLine($"Shell Sort: {shellComparisons} сравнений, {shellInsertions} вставок.");
    }
}
