using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork4
{
    public class Link
    {
        private readonly int key;
        private Link next;

        public Link(int key)
        {
            this.key = key;
        }

        public int GetKey()
        {
            return key;
        }

        public Link GetNext()
        {
            return next;
        }

        public void SetNext(Link next)
        {
            this.next = next;
        }

        public void DisplayLink()
        {
            System.Console.Write(key + " ");
        }
    }
}
