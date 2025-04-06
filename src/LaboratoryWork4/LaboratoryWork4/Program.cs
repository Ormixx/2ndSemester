using LaboratoryWork4;

public class Program
{
    public static void Main(string[] args)
    {
        HashTable hashTable = new HashTable(10);

        hashTable.Insert(new Item(1));
        hashTable.Insert(new Item(2));
        hashTable.Insert(new Item(3));
        hashTable.Insert(new Item(12));
        hashTable.Insert(new Item(22));

        System.Console.WriteLine("Содержимое хеш-таблицы:");
        hashTable.DisplayHashTable();

        int searchKey = 12;
        Item foundItem = hashTable.Find(searchKey);
        if (foundItem != null)
        {
            System.Console.WriteLine($"Элемент с ключом {searchKey} найден.");
        }
        else
        {
            System.Console.WriteLine($"Элемент с ключом {searchKey} не найден.");
        }

        int deleteKey = 2;
        Item deletedItem = hashTable.Delete(deleteKey);
        if (deletedItem != null)
        {
            System.Console.WriteLine($"Элемент с ключом {deleteKey} удален.");
        }
        else
        {
            System.Console.WriteLine($"Элемент с ключом {deleteKey} не найден для удаления.");
        }

        System.Console.WriteLine("Содержимое хеш-таблицы после удаления:");
        hashTable.DisplayHashTable();
    }
}
