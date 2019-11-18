using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Graph
    {
        Dictionary<int, List<int>> graph;

        private Dictionary<int, bool> visited;
        public Graph()
        {
            graph = new Dictionary<int, List<int>>();
        }

        public void AddEdge(int node, int edge)
        {
            if (!graph.ContainsKey(node))
            {
                graph.Add(node, new List<int>(){ edge });
            } 
            else
            {
                graph[node].Add(edge);
            }
        }

        public void DFS(int startNode)
        {
            visited = new Dictionary<int, bool>();
            foreach (int key in graph.Keys)
            {
                AddToVisitedPoint(key);
            }
            foreach (List<int> values in graph.Values)
            {
                AddToVisitedPoint(values);
            }

            DFSfunc(startNode);
        }

        private void AddToVisitedPoint(int node)
        {
            visited.Add(node, false);
        }

        private void AddToVisitedPoint(List<int> nodes)
        {
            foreach (int value in nodes)
            {
                if (!visited.ContainsKey(value))
                {
                    visited.Add(value, false);
                }
            }
        }

        private void DFSfunc(int node)
        {
            visited[node] = true;

            if (graph.ContainsKey(node))
            {
                foreach (int nextNode in graph[node])
                {
                    if (visited[nextNode] == false)
                    {
                        Console.WriteLine("{0} -> {1}", node, nextNode);
                        DFSfunc(nextNode);
                    }
                }
            }

        }
    }
}
