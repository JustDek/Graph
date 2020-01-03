using System;
using Graph.Graphs;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedAdjacencyMatrixGraph gr = new DirectedAdjacencyMatrixGraph(4);
            gr.AddEdge(0, 1, 1);
            gr.AddEdge(0, 2, 3);

            gr.AddEdge(2, 3, 1);
            gr.AddEdge(3, 2, 2);
            gr.DFS(0);
        }
    }
}
