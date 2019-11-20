using System;
using Graph.Graphs;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedUnweightedGraph<int> gr = new DirectedUnweightedGraph<int>(5);

            for (int i = 0; i < 5; i++)
            {
                gr.AddNode(i);
            }

            gr.AddEdge(0, 1);
            gr.AddEdge(1, 3);
            gr.AddEdge(1, 2);

            gr.RemoveEdge(1, 2);
            gr.RemoveEdge(1, 4);
        }
    }
}
