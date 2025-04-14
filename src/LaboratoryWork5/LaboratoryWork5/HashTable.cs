using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork5
{
    public class HashTable
    {
        private Item[] hashArray;
        private int arraySize;
        private int currentSize;

        public HashTable(int size)
        {
            this.arraySize = size;
            this.hashArray = new Item[arraySize];
            this.currentSize = 0;
        }

        private int HashFunc(int key)
        {
            return key % arraySize;
        }

        private int QuadraticProbe(int hashVal, int attempt)
        {
            return (hashVal + attempt * attempt) % arraySize;
        }

        private void Resize()
        {
            int newSize = arraySize * 2;
            Item[] newHashArray = new Item[newSize];
            Item[] oldHashArray = hashArray;
            hashArray = newHashArray;
            arraySize = newSize;
            currentSize = 0;

            foreach (var item in oldHashArray)
            {
                if (item != null)
                {
                    Insert(item);
                }
            }
        }

        public void Insert(Item item)
        {
            if (currentSize >= arraySize * 0.75)
            {
                Resize();
            }

            int hashVal = HashFunc(item.Key);
            for (int attempt = 0; attempt < arraySize; attempt++)
            {
                int probeIndex = QuadraticProbe(hashVal, attempt);
                if (hashArray[probeIndex] == null)
                {
                    hashArray[probeIndex] = item;
                    currentSize++;
                    return;
                }
            }
        }

        public Item Find(int key)
        {
            int hashVal = HashFunc(key);
            for (int attempt = 0; attempt < arraySize; attempt++)
            {
                int probeIndex = QuadraticProbe(hashVal, attempt);
                if (hashArray[probeIndex] == null)
                {
                    break;
                }
                if (hashArray[probeIndex].Key == key)
                {
                    return hashArray[probeIndex];
                }
            }
            return null;
        }

        public Item Delete(int key)
        {
            int hashVal = HashFunc(key);
            for (int attempt = 0; attempt < arraySize; attempt++)
            {
                int probeIndex = QuadraticProbe(hashVal, attempt);
                if (hashArray[probeIndex] == null)
                {
                    break;
                }
                if (hashArray[probeIndex].Key == key)
                {
                    Item deletedItem = hashArray[probeIndex];
                    hashArray[probeIndex] = null;
                    currentSize--;
                    return deletedItem;
                }
            }
            return null;
        }

        public void DisplayHashTable()
        {
            for (int i = 0; i < arraySize; i++)
            {
                if (hashArray[i] != null)
                {
                    System.Console.Write($"Hash Index {i}: {hashArray[i].Key}");
                }
                else
                {
                    System.Console.Write($"Hash Index {i}: null");
                }
                System.Console.WriteLine();
            }
        }
    }
}
