﻿using System;
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

        public bool BFS(int[,] residualGraph, int s, int t, int[] path)
        {
            bool[] visited = new bool[nodeNum];
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            visited[s] = true;

            while (queue.Count > 0)
            {
                int node = queue.Dequeue();

                for (int nextNode = 0; nextNode < nodeNum; nextNode++)
                {
                    if (visited[nextNode] == false && residualGraph[node, nextNode] > 0)
                    {
                        visited[nextNode] = true;
                        queue.Enqueue(nextNode);
                        path[nextNode] = node;
                    }
                }

            }

            return (visited[t] == true);
        }

        public int MaxFlowFord()
        {
            int s = 0, t = nodeNum - 1;
            int[,] residualGraph = new int[nodeNum, nodeNum];
            for (int i = 0; i < nodeNum; i++)
            {
                for (int j = 0; j < nodeNum; j++)
                {
                    residualGraph[i, j] = adjacencyMatrix[i, j];
                }
            }

            int[] path = new int[nodeNum];
            int maxFlow = 0;

            while (BFS(residualGraph, s, t, path))
            {
                int pathFlow = int.MaxValue;
                for (int node = t; node != s; node = path[node])
                {
                    int prevNode = path[node];
                    pathFlow = Math.Min(pathFlow, residualGraph[prevNode, node]);
                }
                
                for (int node = t; node != s; node = path[node])
                {
                    int prevNode = path[node];
                    residualGraph[prevNode, node] -= pathFlow;
                    residualGraph[node, prevNode] += pathFlow;
                }

                maxFlow += pathFlow;
            }

            return maxFlow;
        }
    }
}
