using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    class DirectedUnweightedGraph<TNodeType> : IGraph<TNodeType>
    {
        public void AddEdge(TNodeType from, TNodeType to, int weight = 0)
        {
            throw new NotImplementedException();
        }

        public void AddNode(TNodeType node)
        {
            throw new NotImplementedException();
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
