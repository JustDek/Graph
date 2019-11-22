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

            gr.AddEdge(0, 1, 10);
            gr.AddEdge(1, 3, 13);
            gr.AddEdge(1, 2, 12);
            gr.AddEdge(3, 4, 30);

            gr.DFS(1);
            Console.WriteLine();
            gr.BFS(1); 
        }
    }
}
