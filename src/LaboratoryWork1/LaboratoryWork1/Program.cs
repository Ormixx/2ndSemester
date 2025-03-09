using LaboratoryWork1;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string separator = "__________________________________________________________";
        Random random = new Random();
        int size = 10000;
        SortableLongArray sortableArray = new SortableLongArray(size);
        CommonArray commonArray = new CommonArray(size);
        OrderedArray orderedArray = new OrderedArray(size);

        for (int i = 0; i < size; i++) // заполнение массива
        {
            bool insertResultCommonArray = false;
            bool insertResultOrderedArray = false;

            while (!insertResultCommonArray)
            {
                insertResultCommonArray = commonArray.Insert(random.Next(100000));
            }

            while (!insertResultOrderedArray)
            {
                insertResultOrderedArray = orderedArray.Insert(random.Next(100000));
            }
        }

        long searchValue = random.Next(100000);

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

        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(10000));
        }

        Stopwatch stopwatch = Stopwatch.StartNew();
        int bubbleComparisons, bubbleInsertions;
        sortableArray.BubbleSort(out bubbleComparisons, out bubbleInsertions);
        stopwatch.Stop();
        Console.WriteLine("Bubble Sort: Сравнения = " + bubbleComparisons + ", Вставки = " + bubbleInsertions + ",Время = " + stopwatch.ElapsedMilliseconds + " ms");

        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(10000));
        }

        stopwatch.Restart();
        int insertionComparisons, insertionInsertions;
        sortableArray.InsertionSort(out insertionComparisons, out insertionInsertions);
        stopwatch.Stop();
        Console.WriteLine("Insertion Sort: Сравнения = " + insertionComparisons + ", Вставки = " + insertionInsertions + ",Время = " + stopwatch.ElapsedMilliseconds + " ms");

        sortableArray = new SortableLongArray(size);
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(10000));
        }

        stopwatch.Restart();
        int selectionComparisons, selectionInsertions;
        sortableArray.SelectionSort(out selectionComparisons, out selectionInsertions);
        stopwatch.Stop();
        Console.WriteLine("Selection Sort: Сравнения = " + selectionComparisons + ", Вставки = " + selectionInsertions + ",Время = " + stopwatch.ElapsedMilliseconds + " ms");

    }
}
