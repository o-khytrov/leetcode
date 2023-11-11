using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.Json;
using Xunit;

//There is a directed weighted graph that consists of n nodes numbered from 0 
//to n - 1. The edges of the graph are initially represented by the given array 
//edges where edges[i] = [fromi, toi, edgeCosti] meaning that there is an edge from 
//fromi to toi with the cost edgeCosti. 
//
// Implement the Graph class: 
//
// 
// Graph(int n, int[][] edges) initializes the object with n nodes and the 
//given edges. 
// addEdge(int[] edge) adds an edge to the list of edges where edge = [from, to,
// edgeCost]. It is guaranteed that there is no edge between the two nodes before 
//adding this one. 
// int shortestPath(int node1, int node2) returns the minimum cost of a path 
//from node1 to node2. If no path exists, return -1. The cost of a path is the sum 
//of the costs of the edges in the path. 
// 
//
// 
// Example 1: 
// 
// 
//Input
//["Graph", "shortestPath", "shortestPath", "addEdge", "shortestPath"]
//[[4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]], [3, 2], [0, 3], [[1, 3, 4]
//], [0, 3]]
//Output
//[null, 6, -1, null, 6]
// 
//
//Explanation
//Graph g = new Graph(4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]);
//g.shortestPath(3, 2); // return 6. The shortest path from 3 to 2 in the first 
//diagram above is 3 -> 0 -> 1 -> 2 with a total cost of 3 + 2 + 1 = 6.
//g.shortestPath(0, 3); // return -1. There is no path from 0 to 3.
//g.addEdge([1, 3, 4]); // We add an edge from node 1 to node 3, and we get the 
//second diagram above.
//g.shortestPath(0, 3); // return 6. The shortest path from 0 to 3 now is 0 -> 1
// -> 3 with a total cost of 2 + 4 = 6.
//
//
// 
// Constraints: 
//
// 
// 1 <= n <= 100 
// 0 <= edges.length <= n * (n - 1) 
// edges[i].length == edge.length == 3 
// 0 <= fromi, toi, from, to, node1, node2 <= n - 1 
// 1 <= edgeCosti, edgeCost <= 10⁶ 
// There are no repeated edges and no self-loops in the graph at any point. 
// At most 100 calls will be made for addEdge. 
// At most 100 calls will be made for shortestPath. 
// 
//
// Related Topics Graph Design Heap (Priority Queue) Shortest Path 👍 404 👎 29

namespace DesignGraphWithShortestPathCalculator
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"Graph\", \"shortestPath\", \"shortestPath\", \"addEdge\", \"shortestPath\"]",
            "[[4, [[0, 2, 5], [0, 1, 2], [1, 2, 1], [3, 0, 3]]], [3, 2], [0, 3], [[1, 3, 4]], [0, 3]]",
            "[null, 6, -1, null, 6]")]
        public void DesignGraphWithShortestPathCalculatorTest(string commandsJson, string argumentsJson,
            string expectedResultJson)
        {
            var commands = JsonSerializer.Deserialize<string[]>(commandsJson) ??
                           throw new ArgumentException("Invalid json");

            var arguments = JsonSerializer.Deserialize<object[]>(argumentsJson) ??
                            throw new ArgumentException("Invalid json");

            var expectedResult = JsonSerializer.Deserialize<int?[]>(expectedResultJson) ??
                                 throw new ArgumentException("Invalid json");
            Graph graph = new Graph(0, Array.Empty<int[]>());
            for (var i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                if (command == "Graph")
                {
                    var graphArgsJson = ((JsonElement) arguments[0]).GetRawText();
                    var graphArgsObj = JsonSerializer.Deserialize<object[]>(graphArgsJson)
                                       ?? throw new ArgumentException("Invalid Json");
                    var n = ((JsonElement) graphArgsObj[0]).GetInt32();
                    var edgesJson = ((JsonElement) (graphArgsObj[1])).GetRawText();
                    var edges = JsonSerializer.Deserialize<int[][]>(edgesJson)
                                ?? throw new ArgumentException("Invalid Json");
                    graph = new Graph(n, edges);
                }

                if (command == "shortestPath")
                {
                    var shortestPathArgsJson = ((JsonElement) arguments[i]).GetRawText();
                    var shortestPathArgs = JsonSerializer.Deserialize<int[]>(shortestPathArgsJson)
                                           ?? throw new ArgumentException("Invalid json");
                    var result = graph.ShortestPath(shortestPathArgs[0], shortestPathArgs[1]);
                    Assert.Equal(expectedResult[i].GetValueOrDefault(), result);
                }

                if (command == "addEdge")
                {
                    var addEdgeArgsJson = ((JsonElement) arguments[i]).GetRawText();
                    var addEdgeArgs = JsonSerializer.Deserialize<int[][]>(addEdgeArgsJson)
                                      ?? throw new ArgumentException("Invalid json");
                    graph.AddEdge(addEdgeArgs[0]);
                }
            }
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Graph
    {
        private int _v;
        private readonly List<int[]>[] _adjacencyMatrix;

        public Graph(int n, int[][] edges)
        {
            _v = n;
            _adjacencyMatrix = new List<int[]> [_v];
            for (int i = 0; i < _v; i++)
            {
                _adjacencyMatrix[i] = new List<int[]>();
            }

            foreach (var edge in edges)
            {
                AddEdge(edge);
            }
        }

        public void AddEdge(int[] edge)
        {
            var from = edge[0];
            var to = edge[1];
            var weight = edge[2];
            _adjacencyMatrix[from].Add(new[] { to, weight });
            //_adjacencyMatrix[to].Add(new[] { from, weight });
        }

        public int ShortestPath(int node1, int node2)
        {
            // Create a priority queue to store vertices that are being preprocessed
            SortedSet<int[]> pq = new SortedSet<int[]>(new DistanceComparer());
            // Create an array for distances and initialize all as infinite
            var dist = new int [_v];
            for (int i = 0; i < _v; i++)
            {
                dist[i] = int.MaxValue;
            }

            // insert source itself in priority queue and initialize its distance as 0
            pq.Add(new[] { 0, node1 });
            dist[node1] = 0;

            // Looping till priority queue becomes empty or all distances are finalized
            while (pq.Count > 0)
            {
                //The first vertex in pair is the minimum distance 
                var minDistanceVertex = pq.Min;
                pq.Remove(minDistanceVertex);
                var u = minDistanceVertex[1];
                foreach (var adjVertex in _adjacencyMatrix[u])
                {
                    var v = adjVertex[0];
                    var weight = adjVertex[1];
                    if (dist[v] > dist[u] + weight)
                    {
                        dist[v] = dist[u] + weight;
                        pq.Add(new[] { dist[v], v });
                    }
                }
            }

            var result = dist[node2];
            if (result == int.MaxValue)
            {
                return -1;
            }

            return result;
        }

        private class DistanceComparer : IComparer<int[]>
        {
            public int Compare(int[]? x, int[]? y)
            {
                if (x[0] == y[0])
                {
                    return x[1] - y[1];
                }

                return x[0] - y[0];
            }
        }
    }

    /**
     * Your Graph object will be instantiated and called as such:
     * Graph obj = new Graph(n, edges);
     * obj.AddEdge(edge);
     * int param_2 = obj.ShortestPath(node1,node2);
     */
//leetcode submit region end(Prohibit modification and deletion)
}