using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratoryWork6
{
    public class Graph
    {
        private List<Vertex> vertices;

        public Graph()
        {
            vertices = new List<Vertex>();
        }

        public void AddVertex(char label)
        {
            vertices.Add(new Vertex(label));
        }

        public void AddEdge(char startLabel, char endLabel)
        {
            Vertex startVertex = FindVertex(startLabel);
            Vertex endVertex = FindVertex(endLabel);

            if (startVertex != null && endVertex != null)
            {
                startVertex.AddAdjacent(endVertex);
                endVertex.AddAdjacent(startVertex);
            }
        }

        private Vertex FindVertex(char label)
        {
            foreach (var vertex in vertices)
            {
                if (vertex.Label == label)
                {
                    return vertex;
                }
            }
            return null;
        }

        public void DisplayGraph()
        {
            foreach (var vertex in vertices)
            {
                Console.Write(vertex.Label + ": ");
                foreach (var adjacent in vertex.AdjacentVertices)
                {
                    Console.Write(adjacent.Label + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
