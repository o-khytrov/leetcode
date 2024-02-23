# There are n cities connected by some number of flights. You are given an 
# array flights where flights[i] = [fromi, toi, pricei] indicates that there is a 
# flight from city fromi to city toi with cost pricei. 
# 
#  You are also given three integers src, dst, and k, return the cheapest price 
# from src to dst with at most k stops. If there is no such route, return -1. 
# 
#  
#  Example 1: 
#  
#  
# Input: n = 4, flights = [[0,1,100],[1,2,100],[2,0,100],[1,3,600],[2,3,200]], 
# src = 0, dst = 3, k = 1
# Output: 700
# Explanation:
# The graph is shown above.
# The optimal path with at most 1 stop from city 0 to 3 is marked in red and 
# has cost 100 + 600 = 700.
# Note that the path through cities [0,1,2,3] is cheaper but is invalid because 
# it uses 2 stops.
#  
# 
#  Example 2: 
#  
#  
# Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k =
#  1
# Output: 200
# Explanation:
# The graph is shown above.
# The optimal path with at most 1 stop from city 0 to 2 is marked in red and 
# has cost 100 + 100 = 200.
#  
# 
#  Example 3: 
#  
#  
# Input: n = 3, flights = [[0,1,100],[1,2,100],[0,2,500]], src = 0, dst = 2, k =
#  0
# Output: 500
# Explanation:
# The graph is shown above.
# The optimal path with no stops from city 0 to 2 is marked in red and has cost 
# 500.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 100 
#  0 <= flights.length <= (n * (n - 1) / 2) 
#  flights[i].length == 3 
#  0 <= fromi, toi < n 
#  fromi != toi 
#  1 <= pricei <= 10⁴ 
#  There will not be any multiple flights between two cities. 
#  0 <= src, dst, k < n 
#  src != dst 
#  
# 
#  Related Topics Dynamic Programming Depth-First Search Breadth-First Search 
# Graph Heap (Priority Queue) Shortest Path 👍 9367 👎 388

import unittest
from typing import List


class CheapestFlightsWithinKStops_Test(unittest.TestCase):

    def test_cheapestFlightsWithinKStops(self):
        test_data = [
            (4, [[0, 1, 100], [1, 2, 100], [2, 0, 100], [1, 3, 600], [2, 3, 200]], 0, 3, 1, 700),
            (5, [[4, 1, 1], [1, 2, 3], [0, 3, 2], [0, 4, 10], [3, 1, 1], [1, 4, 3]], 2, 1, 1, - 1),
            (10, [[3, 4, 4], [2, 5, 6], [4, 7, 10], [9, 6, 5], [7, 4, 4], [6, 2, 10], [6, 8, 6], [7, 9, 4], [1, 5, 4],
                  [1, 0, 4], [9, 7, 3], [7, 0, 5], [6, 5, 8], [1, 7, 6], [4, 0, 9], [5, 9, 1], [8, 7, 3], [1, 2, 6],
                  [4, 1, 5], [5, 2, 4], [1, 9, 1], [7, 8, 10], [0, 4, 2], [7, 2, 8]], 6, 0, 7, 14)

        ]
        for n, flights, src, dst, k, expected in test_data:
            with self.subTest(n=n, flights=flights, src=src, dst=dst, k=k, expected=expected):
                self.assertEqual(expected, Solution().findCheapestPrice(n, flights, src, dst, k))


if __name__ == '__main__':
    unittest.main()

from queue import Queue


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:

    def findCheapestPrice(self, n: int, flights: List[List[int]], src: int, dst: int, k: int) -> int:

        from queue import Queue
        m = {}
        for flight in flights:
            s = flight[0]
            d = flight[1]
            price = flight[2]
            m[s] = m.get(s, []) + [(d, price)]
        queue = Queue()
        dist = {i: float('inf') for i in range(n)}
        queue.put((src, 0))
        stops = 0
        while not queue.empty() and stops <= k:
            size = queue.qsize()
            for i in range(size):
                node, distance = queue.get()
                if node in m:
                    for neighbor, price in m[node]:
                        if price+distance >= dist[neighbor]:
                            continue
                        dist[neighbor] = price + distance
                        queue.put((neighbor, dist[neighbor]))
            stops += 1
        if dist[dst] == float('inf'):
            return -1
        return dist[dst]

    # leetcode submit region end(Prohibit modification and deletion)
