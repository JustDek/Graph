using System;
using Graph.Graphs;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedAdjacencyMatrixGraph gr = new DirectedAdjacencyMatrixGraph(6);
            gr.AddEdge(0, 1, 16);
            gr.AddEdge(0, 2, 13);
            gr.AddEdge(1, 2, 10);
            gr.AddEdge(1, 3, 12);
            gr.AddEdge(2, 1, 4);
            gr.AddEdge(2, 4, 14);
            gr.AddEdge(3, 2, 9);
            gr.AddEdge(3, 5, 20);
            gr.AddEdge(4, 3, 7);
            gr.AddEdge(4, 5, 4);
            Console.WriteLine(gr.MaxFlowFord());
        }
    }
}
