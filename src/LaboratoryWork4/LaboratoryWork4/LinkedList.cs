using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork4
{
    public class LinkedList
    {
        private Link first;

        public void Insert(Link theLink)
        {
            int key = theLink.GetKey();
            Link previous = null;
            Link current = first;

            while (current != null && key > current.GetKey())
            {
                previous = current;
                current = current.GetNext();
            }
            if (previous == null)
            {
                first = theLink;
            }
            else
            {
                previous.SetNext(theLink);
            }
            theLink.SetNext(current);
        }

        public void Delete(int key)
        {
            Link previous = null;
            Link current = first;

            while (current != null && key != current.GetKey())
            {
                previous = current;
                current = current.GetNext();
            }

            if (previous == null)
            {
                first = first.GetNext();
            }
            else
            {
                previous.SetNext(current.GetNext());
            }
        }

        public Link Find(int key)
        {
            Link current = first;

            while (current != null)
            {
                if (current.GetKey() == key)
                {
                    return current;
                }
                current = current.GetNext();
            }
            return null;
        }

        public void DisplayList()
        {
            System.Console.Write("List (first-->last): ");
            Link current = first;
            while (current != null)
            {
                current.DisplayLink();
                current = current.GetNext();
            }
            System.Console.WriteLine();
        }
    }
}
