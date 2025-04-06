using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork4
{
    public class HashTable
    {
        private LinkedList[] hashArray;
        private int arraySize;
        private int currentSize;
        private const int LOAD_FACTOR = 2;

        public HashTable(int size)
        {
            this.arraySize = size;
            this.hashArray = new LinkedList[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                hashArray[i] = new LinkedList();
            }
            this.currentSize = 0;
        }

        private int HashFunc(int key)
        {
            return key % arraySize;
        }

        public void Insert(Item item)
        {
            int hashVal = HashFunc(item.Key);
            hashArray[hashVal].Insert(new Link(item.Key));
            currentSize++;
        }

        public Item Find(int key)
        {
            int hashVal = HashFunc(key);
            Link foundLink = hashArray[hashVal].Find(key);
            return foundLink != null ? new Item(foundLink.GetKey()) : null;
        }

        public Item Delete(int key)
        {
            int hashVal = HashFunc(key);
            Link foundLink = hashArray[hashVal].Find(key);
            if (foundLink != null)
            {
                hashArray[hashVal].Delete(key);
                currentSize--;
                return new Item(foundLink.GetKey());
            }
            return null;
        }

        public void DisplayHashTable()
        {
            for (int i = 0; i < arraySize; i++)
            {
                System.Console.Write($"Hash Index {i}: ");
                hashArray[i].DisplayList();
            }
        }
    }
}
