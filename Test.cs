using System;
using System.Collections.Generic;
class Program
{
    class Edge
    {
        public int To, Weight;
        public Edge(int to, эint weight)
        {
            To = to;
            Weight = weight;
        }
    }

    static int FindMaxCapacityPath(int N, int M, List<Tuple<int, int, int>> roads, int S, int T)
    {
        List<Edge>[] graph = new List<Edge>[N + 1];
        for (int i = 0; i <= N; i++)
            graph[i] = new List<Edge>();
        
        foreach (var road in roads)
        {
            int A = road.Item1;
            int B = road.Item2;
            int W = road.Item3;
            graph[A].Add(new Edge(B, W));
            graph[B].Add(new Edge(A, W));
        }
        int[] maxCapacity = new int[N + 1];
        Array.Fill(maxCapacity, 0);
        maxCapacity[S] = int.MaxValue;  

        var pq = new PriorityQueue<(int, int), int>(); 
        pq.Enqueue((S, int.MaxValue), -int.MaxValue); 

        while (pq.Count > 0)
        {
            var (current, currentCapacity) = pq.Dequeue();
            currentCapacity = -currentCapacity;  

            if (current == T)
                return currentCapacity;

            foreach (var neighbor in graph[current])
            {
                int newCapacity = Math.Min(currentCapacity, neighbor.Weight);

                if (newCapacity > maxCapacity[neighbor.To])
                {
                    maxCapacity[neighbor.To] = newCapacity;
                    pq.Enqueue((neighbor.To, -newCapacity), -newCapacity); 
                }
            }
        }

        return 0; 
    }
    static void Next_One
    static void Main()
    {
        int N = 5; 
        int M = 6;
        var roads = new List<Tuple<int, int, int>>
        {
            Tuple.Create(1, 2, 10),
            Tuple.Create(1, 3, 20),
            Tuple.Create(2, 3, 10),
            Tuple.Create(2, 4, 25),
            Tuple.Create(3, 4, 15),
            Tuple.Create(4, 5, 30)
        };
        int S = 1; 
        int T = 5; 

        int result = FindMaxCapacityPath(N, M, roads, S, T);
        Console.WriteLine(result); 
    }
}
