using System;
using Graph.Graphs;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectedUnweightedGraph<int> graph = new DirectedUnweightedGraph<int>();

            Graph gr = new Graph();
            gr.AddEdge(0, 1);
            gr.AddEdge(0, 2);
            gr.AddEdge(1, 0);
            gr.AddEdge(1, 2);
            gr.AddEdge(2, 0);
            gr.AddEdge(2, 1);
            gr.AddEdge(2, 3);
            gr.AddEdge(2, 5);
            gr.AddEdge(3, 2);
            gr.AddEdge(3, 4);
            gr.AddEdge(5, 2);
            gr.AddEdge(5, 8);
            gr.AddEdge(5, 6);

            gr.DFS(0);
        }
    }
}
