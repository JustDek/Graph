using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph
{
    class Graph
    {
        Dictionary<int, List<int>> graph;

        private List<bool> visited;
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

        public void DFS()
        {
            visited = new List<bool>();
            for (int i = 0; i < graph.Count(); i++)
            {
                visited.Add(false);
            }
            
       
        }

        private void DFSfunc(int node)
        {
            visited[node] = true;

            

        }
    }
}
