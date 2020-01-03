using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    class DirectedAdjacencyMatrixGraph
    {
        public int[,] adjacencyMatrix;
        private int nodeNum;
        public DirectedAdjacencyMatrixGraph(int nodeNum)
        {
            this.nodeNum = nodeNum;
            adjacencyMatrix = fillMatrix(nodeNum);
        }
        public void AddEdge(int from, int to, int weight)
        {
            if (check(from) && check(to))
            {
                adjacencyMatrix[from, to] = weight;
            }
            else
            {
                Console.WriteLine("The graph doesn't consist that node");
            }
        }

        public void RemoveEdge(int from, int to)
        {
            if (check(from) && check(to))
            {
                adjacencyMatrix[from, to] = 0;
            }
            else
            {
                Console.WriteLine("The graph doesn't consist that node");
            }
        }
        public void DFS(int startNode)
        {
            bool[] visited = new bool[nodeNum];
            visited[startNode] = true;

            DFSsolve(startNode, visited);
        }
        private void DFSsolve(int node, bool[] visited)
        {
            for (int nextNode = 0; nextNode < nodeNum; nextNode++)
            {
                if (adjacencyMatrix[node, nextNode] != 0 && !visited[nextNode])
                {
                    visited[nextNode] = true;
                    Console.WriteLine("{0} -> {1}", node, nextNode);
                    DFSsolve(nextNode, visited);
                }
            }

        }

        public int[,] fillMatrix(int nodeNum)
        {
            int[,] adjMatrix = new int[nodeNum, nodeNum];
            for (int i = 0; i < 0; i++)
            {
                adjMatrix[i, i] = 0;
            }

            return adjMatrix;
        }
        private bool check(int node)
        {
            if (node < nodeNum && node > -1)
            {
                return true;
            }
            return false;
        }
    }
}
