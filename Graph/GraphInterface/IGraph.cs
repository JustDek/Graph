using System;
using System.Collections.Generic;
using System.Text;

namespace Graph.GraphInterface
{
    interface IGraph<TNodeType>
    {
        void AddNode(TNodeType node);
        void RemoveNode(TNodeType node);
        void AddEdge(TNodeType from, TNodeType to, int weight = 0);
        void RemoveEdge(TNodeType from, TNodeType to);
        
    }
}
