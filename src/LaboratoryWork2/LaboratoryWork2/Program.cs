using LaboratoryWork2;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        string separator = "__________________________________________________________";
        Random random = new Random();
        int size = 100000;
        SortableLongArray sortableArray = new SortableLongArray(size);

        // Заполнение массива случайными числами
        for (int i = 0; i < size; i++)
        {
            sortableArray.Insert(random.Next(100000));
        }

        // Сортировка массива с помощью быстрой сортировки
        Stopwatch stopwatch = Stopwatch.StartNew();
        sortableArray.QuickSort();
        stopwatch.Stop();
        Console.WriteLine("Quick Sort: Время = " + stopwatch.ElapsedMilliseconds + " ms");

        // Проверка на корректность сортировки
        for (int i = 1; i < sortableArray.GetSize(); i++) // Используем GetSize для проверки размера
        {
            if (sortableArray.Get(i) < sortableArray.Get(i - 1))
            {
                Console.WriteLine("Ошибка: массив не отсортирован!");
                return;
            }
        }
        Console.WriteLine("Массив успешно отсортирован.");
    }
}
