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
            bool[] Discovered = new bool[100];
            bool[] CompletelyExplored = new bool[100];
            int numberOFNodes = 7; // this is + 1 as being 1 based
            int S = 1, D = 6;
            //int S = 1, D = 5;
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
            Stack<int> aStack = new Stack<int>();
            Queue<int> theQueue = new Queue<int>();
            bool[] Discovered = new bool[numberOFNodes];
            int[] Parent = new int[numberOFNodes];
            int V, C;
            bool Found = false;
            theQueue.Enqueue(S);
            Discovered[S] = true;
            while (theQueue.Count != 0 && Found == false)
            {
                V = theQueue.Dequeue();
                foreach (var U in graph[V].adjList)
                {
                    if (Discovered[U] == false && Found == false)
                    {
                        theQueue.Enqueue(U);
                        Discovered[U] = true;
                        Parent[U] = V;
                        if (U == D)
                        {
                            Found = true;
                        }
                    }
                }
            }
            if (Found == true)
            {
                C = D;
                Console.WriteLine(D);
                do
                {
                    C = Parent[C];
                    Console.WriteLine(C);
                } while (C != S);

            }
            // stack version
            //if (Found == true)
            //{
            //    C = D;
            //    aStack.Push(D);
            //    do
            //    {
            //        C = Parent[C];
            //        aStack.Push(C);
            //    } while (C != S);
            //    while (aStack.Count != 0)
            //    {
            //        Console.WriteLine(aStack.Pop().ToString());
            //    }
            //}
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
            //extension ex
            //graph[1].addNeighbour(2);
            //graph[1].addNeighbour(3);
            //graph[2].addNeighbour(1);
            //graph[2].addNeighbour(3);
            //graph[2].addNeighbour(4);
            //graph[3].addNeighbour(1);
            //graph[3].addNeighbour(2);
            //graph[3].addNeighbour(5);
            //graph[4].addNeighbour(2);
            //graph[4].addNeighbour(5);
            //graph[4].addNeighbour(6);
            //graph[5].addNeighbour(4);
            //graph[5].addNeighbour(3);
            //graph[6].addNeighbour(4);


        }



    }
}
