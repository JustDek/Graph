using System;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph gr = new Graph();
            gr.AddEdge(1, 2);
            gr.AddEdge(1, 3);
            gr.AddEdge(2, 3);
            gr.DFS();
        }
    }
}
