using System;
using System.Collections.Generic;
using System.Linq;
using leetcode.CommonClasses;
using Xunit;

//You are given an array routes representing bus routes where routes[i] is a 
//bus route that the iᵗʰ bus repeats forever. 
//
// 
// For example, if routes[0] = [1, 5, 7], this means that the 0ᵗʰ bus travels 
//in the sequence 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... forever. 
// 
//
// You will start at the bus stop source (You are not on any bus initially), 
//and you want to go to the bus stop target. You can travel between bus stops by 
//buses only. 
//
// Return the least number of buses you must take to travel from source to 
//target. Return -1 if it is not possible. 
//
// 
// Example 1: 
//
// 
//Input: routes = [[1,2,7],[3,6,7]], source = 1, target = 6
//Output: 2
//Explanation: The best strategy is take the first bus to the bus stop 7, then 
//take the second bus to the bus stop 6.
// 
//
// Example 2: 
//
// 
//Input: routes = [[7,12],[4,5,15],[6],[15,19],[9,12,13]], source = 15, target =
// 12
//Output: -1
// 
//
// 
// Constraints: 
//
// 
// 1 <= routes.length <= 500. 
// 1 <= routes[i].length <= 10⁵ 
// All the values of routes[i] are unique. 
// sum(routes[i].length) <= 10⁵ 
// 0 <= routes[i][j] < 10⁶ 
// 0 <= source, target < 10⁶ 
// 
//
// Related Topics Array Hash Table Breadth-First Search 👍 3548 👎 87

namespace BusRoutes
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,7],[3,6,7]]", 1, 6, 2)]
        [InlineData("[[7,12],[4,5,15],[6],[15,19],[9,12,13]]", 15, 12, -1)]
        public void BusRoutesTest(string routesJson, int source, int target, int expectedResult)
        {
            var routes = Helper.ToIntMatrix(routesJson);
            Assert.Equal(expectedResult, new Solution().NumBusesToDestination(routes, source, target));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target)
            {
                return 0;
            }

            var maxStop = routes.SelectMany(x => x).Max();
            if (maxStop < target)
            {
                return -1;
            }

            var n = routes.Length;
            var minBusesToReach = new int[maxStop + 1];
            Array.Fill(minBusesToReach, n+1);
            minBusesToReach[source] = 0;
            var flag = true;
            while (flag)
            {
                flag = false;
                foreach (var route in routes)
                {
                    var min = n + 1;
                    foreach (var stop in route)
                    {
                        min = Math.Min(min, minBusesToReach[stop]);
                    }

                    min++;
                    foreach (var stop in route)
                    {
                        if (minBusesToReach[stop] > min)
                        {
                            minBusesToReach[stop] = min;
                            flag = true;
                        }
                    }
                }
            }

            return minBusesToReach[target] < n+1? minBusesToReach[target] : -1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}