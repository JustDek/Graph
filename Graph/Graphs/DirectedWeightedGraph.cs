using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    struct WeightedEdge<TNodeType>
    {
        public int weight;
        public TNodeType edge;

        public WeightedEdge(TNodeType edge, int weight)
        {
            this.weight = weight;
            this.edge = edge;
        }
    }
    class DirectedWeightedGraph<TNodeType> : IGraph<TNodeType>
    {
        private List<TNodeType> nodes;
        private readonly int len;
        private Dictionary<TNodeType, List<WeightedEdge<TNodeType>>> adjacencyList;
        public DirectedWeightedGraph(int len)
        {
            this.len = len;
            adjacencyList = new Dictionary<TNodeType, List<WeightedEdge<TNodeType>>>();

        }

        public void AddEdge(TNodeType from, TNodeType to, int weight)
        {
            if (!(adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to)))
            {
                throw new Exception("There is no such node");
            }
            else
            {
                adjacencyList[from].Add(new WeightedEdge<TNodeType>(to, weight));
            }
        }

        public void AddNode(TNodeType node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList.Add(node, new List<WeightedEdge<TNodeType>>());
            }
        }

        public void RemoveEdge(TNodeType from, TNodeType to)
        {
            if (adjacencyList.ContainsKey(from))
            {
                foreach (WeightedEdge<TNodeType> edgeToRemove in adjacencyList[from])
                {
                    if (edgeToRemove.edge.Equals(to))
                    {
                        adjacencyList[from].Remove(edgeToRemove);
                        return;
                    }
                }
                throw new Exception("There is no such edge");
            }
            else
            {
                throw new Exception("There is no such edge");
            }
        }

        public void RemoveNode(TNodeType node)
        {
            if (adjacencyList.ContainsKey(node))
            {
                adjacencyList.Remove(node);
            }
            else
            {
                throw new Exception("There is not such node");
            }
        }

        public void DFS(TNodeType sPoint)
        {
            Dictionary<TNodeType, bool> visited = new Dictionary<TNodeType, bool>();
            foreach (TNodeType node in adjacencyList.Keys)
            {
                visited.Add(node, false);
            }

            DFSUtil(sPoint, visited);
        }

        private void DFSUtil(TNodeType currentPoint, Dictionary<TNodeType, bool> visited)
        {
            visited[currentPoint] = true;

            foreach (WeightedEdge<TNodeType> nextEdge in adjacencyList[currentPoint])
            {
                if (visited[nextEdge.edge] == false)
                {
                    Console.WriteLine("{0} -{1}-> {2}", currentPoint, nextEdge.weight, nextEdge.edge);
                    DFSUtil(nextEdge.edge, visited);
                }
            }

        }
    }
}
