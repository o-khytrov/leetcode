using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

//There is an integer array nums that consists of n unique elements, but you 
//have forgotten it. However, you do remember every pair of adjacent elements in 
//nums. 
//
// You are given a 2D integer array adjacentPairs of size n - 1 where each 
//adjacentPairs[i] = [ui, vi] indicates that the elements ui and vi are adjacent in 
//nums. 
//
// It is guaranteed that every adjacent pair of elements nums[i] and nums[i+1] 
//will exist in adjacentPairs, either as [nums[i], nums[i+1]] or [nums[i+1], nums[
//i]]. The pairs can appear in any order. 
//
// Return the original array nums. If there are multiple solutions, return any 
//of them. 
//
// 
// Example 1: 
//
// 
//Input: adjacentPairs = [[2,1],[3,4],[3,2]]
//Output: [1,2,3,4]
//Explanation: This array has all its adjacent pairs in adjacentPairs.
//Notice that adjacentPairs[i] may not be in left-to-right order.
// 
//
// Example 2: 
//
// 
//Input: adjacentPairs = [[4,-2],[1,4],[-3,1]]
//Output: [-2,4,1,-3]
//Explanation: There can be negative numbers.
//Another solution is [-3,1,4,-2], which would also be accepted.
// 
//
// Example 3: 
//
// 
//Input: adjacentPairs = [[100000,-100000]]
//Output: [100000,-100000]
// 
//
// 
// Constraints: 
//
// 
// nums.length == n 
// adjacentPairs.length == n - 1 
// adjacentPairs[i].length == 2 
// 2 <= n <= 10⁵ 
// -10⁵ <= nums[i], ui, vi <= 10⁵ 
// There exists some nums that has adjacentPairs as its pairs. 
// 
//
// Related Topics Array Hash Table 👍 1653 👎 63

namespace RestoreTheArrayFromAdjacentPairs
{
    public class Tests
    {
        [Theory]
        [InlineData("[[2,1],[3,4],[3,2]]", "[1,2,3,4]")]
        [InlineData("[[4,-2],[1,4],[-3,1]]", "[-2,4,1,-3]")]
        [InlineData("[[100000,-100000]]", "[100000,-100000]")]
        [InlineData("[[-3,-9],[-5,3],[2,-9],[6,-3],[6,1],[5,3],[8,5],[-5,1],[7,2]]", "[7,2,-9,-3,6,1,-5,3,5,8]")]
        public void RestoreTheArrayFromAdjacentPairsTest(string inputJson, string expectedResultJson)
        {
            var adjacentPairs = Helper.ToIntMatrix(inputJson);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().RestoreArray(adjacentPairs)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public void Resolve(List<int> result, Dictionary<int, HashSet<int>> dict, int n)
        {
            var val = dict[n];
            dict.Remove(n);
        }

        public int[] RestoreArray(int[][] adjacentPairs)
        {
            if (adjacentPairs.Length == 1)
            {
                return adjacentPairs[0];
            }

            var result = new List<int>();
            var dic = new Dictionary<int, List<int>>();
            for (int i = 0; i < adjacentPairs.Length; i++)
            {
                var pair = adjacentPairs[i];
                var one = pair[0];
                var two = pair[1];
                if (!dic.TryAdd(one, new List<int>() { two }))
                {
                    dic[one].Add(two);
                }

                if (!dic.TryAdd(two, new List<int>() { one }))
                {
                    dic[two].Add(one);
                }
            }

            var number = dic.Keys.First();
            result.Add(dic[number][0]);
            result.Add(number);
            if (dic[number].Count > 1)
            {
                result.Add(dic[number][1]);
            }

            dic.Remove(number);
            while (dic.Count > 0)
            {
                AddRight(result, dic);

                AddLeft(result, dic);
            }


            return result.ToArray();
        }

        private static void AddRight(List<int> result, Dictionary<int, List<int>> dic)
        {
            //Add number to the right
            var prevNumber = result[^2];
            var number = result[^1];
            while (dic.ContainsKey(number))
            {
                var neighbourPar = dic[number];
                if (neighbourPar.All(x => x == prevNumber))
                {
                    dic.Remove(number);
                    break;
                }

                var next = dic[number].First(x => x != prevNumber);
                result.Add(next);

                dic.Remove(number);

                prevNumber = number;
                number = result[^1];
            }
        }

        private static void AddLeft(List<int> result, Dictionary<int, List<int>> dic)
        {
            var prevNumber = result[1];
            var number = result[0];
            while (dic.ContainsKey(number))
            {
                var neighbourPar = dic[number];
                if (neighbourPar.All(x => x == prevNumber))
                {
                    dic.Remove(number);
                    break;
                }

                var next = dic[number].First(x => x != prevNumber);
                result.Insert(0, next);

                dic.Remove(number);

                prevNumber = number;
                number = result[^1];
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}