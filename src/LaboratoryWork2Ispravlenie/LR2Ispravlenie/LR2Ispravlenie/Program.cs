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
        CommonArray commonArray = new CommonArray(size);
        OrderedArray orderedArray = new OrderedArray(size);


        for (int i = 0; i < 50000; i++)
        {
            commonArray.Insert(random.Next(50000));
            orderedArray.Insert(random.Next(50000));
        }

        long searchValue = random.Next(50000);

        if (commonArray.Contains(searchValue))
        {
            Console.WriteLine("Значение было найдено. " + searchValue);
        }
        else
        {
            Console.WriteLine("Не удалось найти значение. " + searchValue);
        }

        Console.WriteLine(separator);

        if (orderedArray.Contains(searchValue))
        {
            Console.WriteLine("Значение было найдено. " + searchValue);
        }
        else
        {
            Console.WriteLine("Не удалось найти значение. " + searchValue);
        }

        Console.WriteLine("Максимальное значение массива: " + orderedArray.GetMax());
        Console.WriteLine("Минимальное значение массива: " + orderedArray.GetMin());

        // Тестирование сортировки Шелла с последовательностью Хиббарда
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        int hibbardComparisons, hibbardInsertions;
        sortableArray.HibbardShellSort(out hibbardComparisons, out hibbardInsertions);
        stopwatch.Stop();
        Console.WriteLine("Hibbard Shell Sort: Сравнения = " + hibbardComparisons + ", Вставки = " + hibbardInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");

        // Тестирование сортировки Шелла с последовательностью Седжвика
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        int sedgewickComparisons, sedgewickInsertions;
        sortableArray.SedgewickShellSort(out sedgewickComparisons, out sedgewickInsertions);
        stopwatch.Stop();
        Console.WriteLine("Sedgewick Shell Sort: Сравнения = " + sedgewickComparisons + ", Вставки = " + sedgewickInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");

        // Тестирование сортировки Шелла с простым делением на 2
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        int simpleDivComparisons, simpleDivInsertions;
        sortableArray.SimpleDivShellSort(out simpleDivComparisons, out simpleDivInsertions);
        stopwatch.Stop();
        Console.WriteLine("Simple Div Shell Sort: Сравнения = " + simpleDivComparisons + ", Вставки = " + simpleDivInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");

        // Тестирование сортировки Шелла
        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < 50000; i++)
        {
            sortableArray.Insert(random.Next(50000));
        }

        stopwatch.Restart();
        int shellComparisons, shellInsertions;
        sortableArray.ShellSort(out shellComparisons, out shellInsertions);
        stopwatch.Stop();
        Console.WriteLine("Shell Sort: Сравнения = " + shellComparisons + ", Вставки = " + shellInsertions + ", Время = " + stopwatch.ElapsedMilliseconds + " ms");

        // Вывод результатов сортировки
        Console.WriteLine(separator);
        Console.WriteLine("Сортировка завершена.");
        Console.WriteLine("Общее количество вставок в массив: 50000");
        Console.WriteLine("Результаты сортировок:");

        Console.WriteLine($"Hibbard Shell Sort: {hibbardComparisons} сравнений, {hibbardInsertions} вставок.");
        Console.WriteLine($"Sedgewick Shell Sort: {sedgewickComparisons} сравнений, {sedgewickInsertions} вставок.");
        Console.WriteLine($"Simple Div Shell Sort: {simpleDivComparisons} сравнений, {simpleDivInsertions} вставок.");
        Console.WriteLine($"Shell Sort: {shellComparisons} сравнений, {shellInsertions} вставок.");
    }
}
