using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    class DirectedUnweightedGraph<TNodeType> : IGraph<TNodeType>
    {
        private List<TNodeType> nodes;
        private readonly int len;
        private Dictionary<TNodeType, List<TNodeType>> adjacencyList;

        public DirectedUnweightedGraph(int len)
        {
            this.len = len;
            adjacencyList = new Dictionary<TNodeType, List<TNodeType>>();
            
        }
        
        public void AddEdge(TNodeType from, TNodeType to, int weight = 0)
        {
            if ( !(adjacencyList.ContainsKey(from) && adjacencyList.ContainsKey(to)) )
            {
                throw new Exception("There is no such node");
            }
            else
            {
                adjacencyList[from].Add(to);
            }
        }

        public void AddNode(TNodeType node)
        {
            if (!adjacencyList.ContainsKey(node))
            {
                adjacencyList.Add(node, new List<TNodeType>());
            }
        }

        public void RemoveEdge(TNodeType from, TNodeType to)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(TNodeType node)
        {
            throw new NotImplementedException();
        }
    }
}
