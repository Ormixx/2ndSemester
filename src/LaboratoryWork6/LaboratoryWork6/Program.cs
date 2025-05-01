using LaboratoryWork6;

class Program
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();
        graph.AddVertex('A');
        graph.AddVertex('B');
        graph.AddVertex('C');
        graph.AddVertex('D');

        graph.AddEdge('A', 'B');
        graph.AddEdge('A', 'C');
        graph.AddEdge('B', 'D');

        graph.DisplayGraph();
    }
}