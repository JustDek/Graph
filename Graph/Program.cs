using System;
using Graph.Graphs;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedUnweightedGraph<int> gr = new DirectedUnweightedGraph<int>(5);
            DirectedWeightedGraph<int> gr2 = new DirectedWeightedGraph<int>(5);

            for (int i = 0; i < 5; i++)
            {
                gr.AddNode(i);
            }

            gr.AddEdge(0, 1);
            gr.AddEdge(0, 2);
            gr.AddEdge(2, 3);
            gr.AddEdge(1, 3);
            gr.AddEdge(3, 4);

            gr.DFS(1);
            Console.WriteLine();
            gr.BFSSortestPath(0, 4);
        }
    }
}
