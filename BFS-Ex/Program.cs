using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphsBFS
{
    class Program
    {
        class aNode
        {
            public List<int> adjList = new List<int>();
            public void addNeighbour(int neighbour)
            {
                adjList.Add(neighbour);
            }
        }



        static void Main(string[] args)
        {
            aNode[] graph = new aNode[100];
            int numberOFNodes = 7; // this is + 1 as being 1 based
            int S = 1, D = 6;
            for (int i = 0; i < numberOFNodes; i++)
            {
                graph[i] = new aNode();
            }
            makeUpGraph(ref graph);
            findShortestRoute(S, D, graph, numberOFNodes);
            Console.ReadLine();
        }

        private static void findShortestRoute(int S, int D, aNode[] graph, int numberOFNodes)
        {
            Queue<int> theQueue = new Queue<int>();
            bool[] Discovered = new bool[numberOFNodes];
            int[] Parent = new int[numberOFNodes];
            int V, C;
            theQueue.Enqueue(S);
            Discovered[S] = true;
            bool Found = false;
            while (theQueue.Count != 0 && Found == false)
            {
                //
                foreach (var U in graph[V].adjList)
                {
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                    //
                }
            }
            if (Found == true)
            {
                C = D;
                Console.WriteLine(D);
                //
                //
                // 
                // 
                //
            }
        }

        private static void makeUpGraph(ref aNode[] graph)
        {
            graph[1].addNeighbour(2);
            graph[1].addNeighbour(4);
            graph[2].addNeighbour(1);
            graph[2].addNeighbour(3);
            graph[2].addNeighbour(5);
            graph[3].addNeighbour(2);
            graph[3].addNeighbour(5);
            graph[3].addNeighbour(6);
            graph[4].addNeighbour(1);
            graph[4].addNeighbour(5);
            graph[5].addNeighbour(2);
            graph[5].addNeighbour(4);
            graph[5].addNeighbour(3);
            graph[6].addNeighbour(3);
        }



    }
}
