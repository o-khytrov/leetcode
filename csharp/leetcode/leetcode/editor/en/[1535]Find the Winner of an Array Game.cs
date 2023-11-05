using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

//Given an integer array arr of distinct integers and an integer k. 
//
// A game will be played between the first two elements of the array (i.e. arr[0
//] and arr[1]). In each round of the game, we compare arr[0] with arr[1], the 
//larger integer wins and remains at position 0, and the smaller integer moves to 
//the end of the array. The game ends when an integer wins k consecutive rounds. 
//
// Return the integer which will win the game. 
//
// It is guaranteed that there will be a winner of the game. 
//
// 
// Example 1: 
//
// 
//Input: arr = [2,1,3,5,4,6,7], k = 2
//Output: 5
//Explanation: Let's see the rounds of the game:
//Round |       arr       | winner | win_count
//  1   | [2,1,3,5,4,6,7] | 2      | 1
//  2   | [2,3,5,4,6,7,1] | 3      | 1
//  3   | [3,5,4,6,7,1,2] | 5      | 1
//  4   | [5,4,6,7,1,2,3] | 5      | 2
//So we can see that 4 rounds will be played and 5 is the winner because it 
//wins 2 consecutive games.
// 
//
// Example 2: 
//
// 
//Input: arr = [3,2,1], k = 10
//Output: 3
//Explanation: 3 will win the first 10 rounds consecutively.
// 
//
// 
// Constraints: 
//
// 
// 2 <= arr.length <= 10⁵ 
// 1 <= arr[i] <= 10⁶ 
// arr contains distinct integers. 
// 1 <= k <= 10⁹ 
// 
//
// Related Topics Array Simulation 👍 867 👎 41

namespace FindTheWinnerOfAnArrayGame
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,1,3,5,4,6,7]", 2, 5)]
        [InlineData("[3,2,1]", 10, 3)]
        public void FindTheWinnerOfAnArrayGameTest(string arrJson, int k, int expectedResult)
        {
            var arr = JsonSerializer.Deserialize<int[]>(arrJson)
                      ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().GetWinner(arr, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int GetWinner(int[] arr, int k)
        {
            if (k == 1)
            {
                if (arr.Length == 1)
                {
                    return arr[0];
                }

                return Math.Max(arr[0], arr[1]);
            }

            if (k > arr.Length)
            {
                return arr.Max();
            }


            var currentWinner = arr[0];
            var winsCount = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (currentWinner > arr[i])
                {
                    winsCount++;
                }
                else
                {
                    currentWinner = arr[i];
                    winsCount = 1;
                }


                if (winsCount == k)
                {
                    return currentWinner;
                }
            }

            return currentWinner;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}