using System;
using System.Collections.Generic;
using System.Text;
using Graph.GraphInterface;

namespace Graph.Graphs
{
    class DirectedUnweightedGraph<TNodeType> : IGraph<TNodeType>
    {
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
            if (adjacencyList.ContainsKey(from) && adjacencyList[from].Contains(to))
            {
                adjacencyList[from].Remove(to);
            } 
            else
            {
                throw new Exception("There is not such edge");
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
            Dictionary<TNodeType, bool> visited = new Dictionary<TNodeType, bool>() ;
            foreach (TNodeType item in adjacencyList.Keys)
            {
                visited.Add(item, false);
            }

            DFSUtil(sPoint, visited);
        }

        private void DFSUtil(TNodeType currentPoint, Dictionary<TNodeType, bool> visited)
        {
            visited[currentPoint] = true;

            foreach (TNodeType nextPoint in adjacencyList[currentPoint])
            {
                if (visited[nextPoint] == false)
                {
                    Console.WriteLine("{0} -> {1}", currentPoint, nextPoint);
                    DFSUtil(nextPoint, visited);
                }
            }
        }

        public void BFSSortestPath(TNodeType sPoint, TNodeType ePoint)
        {
            Dictionary<TNodeType, TNodeType> path = BFSsolve(sPoint);

            RestorePath(path, sPoint, ePoint);
        }

        private Dictionary<TNodeType, TNodeType> BFSsolve(TNodeType currentPoint)
        {
            Queue<TNodeType> queue = new Queue<TNodeType>();
            queue.Enqueue(currentPoint);
            Dictionary<TNodeType, TNodeType> path = new Dictionary<TNodeType, TNodeType>();

            Dictionary<TNodeType, bool> visited = new Dictionary<TNodeType, bool>();
            foreach (TNodeType node in adjacencyList.Keys)
            {
                visited.Add(node, false);
            }
            visited[currentPoint] = true;

            while (queue.Count > 0)
            {
                TNodeType node = queue.Dequeue();
                List<TNodeType> neighbours = adjacencyList[node];
                
                foreach(TNodeType next in neighbours)
                {
                    if (visited[next] == false)
                    {
                        Console.WriteLine("{0} -> {1}", node, next);
                        path[next] = node;
                        queue.Enqueue(next);
                        visited[next] = true;
                    }
                }
            }

            return path;
        }

        private Stack<TNodeType> RestorePath(Dictionary<TNodeType, TNodeType> path, TNodeType sPoint, TNodeType ePoint)
        {
            TNodeType current = ePoint;
            Stack<TNodeType> shortestPath = new Stack<TNodeType>();
            while (!current.Equals(sPoint))
            {
                shortestPath.Push(current);
                current = path[current];
            }

            shortestPath.Push(sPoint);

            foreach (TNodeType node in shortestPath)
            {
                Console.WriteLine(node);
            }

            return shortestPath;
        }
    }
}
