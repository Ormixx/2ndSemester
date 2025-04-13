using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork5
{
    public class HashTable
    {
        private LinkedList[] hashArray;
        private int arraySize;
        private int currentSize;

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

        private int QuadraticProbe(int hashVal, int attempt)
        {
            return (hashVal + attempt * attempt) % arraySize;
        }

        private void Resize()
        {
            int newSize = arraySize * 2;
            LinkedList[] newHashArray = new LinkedList[newSize];
            for (int i = 0; i < newSize; i++)
            {
                newHashArray[i] = new LinkedList();
            }

            for (int i = 0; i < arraySize; i++)
            {
                Link current = hashArray[i].GetFirstLink();
                while (current != null)
                {
                    int newHashVal = current.GetKey() % newSize;
                    newHashArray[newHashVal].Insert(new Link(current.GetKey()));
                    current = current.GetNext();
                }
            }
            hashArray = newHashArray;
            arraySize = newSize;
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
                if (hashArray[probeIndex].GetFirstLink() == null)
                {
                    hashArray[probeIndex].Insert(new Link(item.Key));
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
                Link foundLink = hashArray[probeIndex].Find(key);
                if (foundLink != null)
                {
                    return new Item(foundLink.GetKey());
                }
                if (hashArray[probeIndex].GetFirstLink() == null)
                {
                    break;
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
                Link foundLink = hashArray[probeIndex].Find(key);
                if (foundLink != null)
                {
                    hashArray[probeIndex].Delete(key);
                    currentSize--;
                    return new Item(foundLink.GetKey());
                }
                if (hashArray[probeIndex].GetFirstLink() == null)
                {
                    break;
                }
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
