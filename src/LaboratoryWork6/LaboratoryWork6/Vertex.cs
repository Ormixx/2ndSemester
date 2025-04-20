using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork6
{
    public class Vertex
    {
        public char Label { get; private set; }
        public List<Vertex> AdjacentVertices { get; private set; }

        public Vertex(char label)
        {
            Label = label;
            AdjacentVertices = new List<Vertex>();
        }

        public void AddAdjacent(Vertex vertex)
        {
            AdjacentVertices.Add(vertex);
        }
    }
}
