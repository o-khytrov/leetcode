using System.Collections.Generic;
using Xunit;

//The chess knight has a unique movement, it may move two squares vertically 
//and one square horizontally, or two squares horizontally and one square vertically 
//(with both forming the shape of an L). The possible movements of chess knight 
//are shown in this diagaram: 
//
// A chess knight can move as indicated in the chess diagram below: 
// 
// We have a chess knight and a phone pad as shown below, the knight can only 
//stand on a numeric cell (i.e. blue cell). 
// 
// Given an integer n, return how many distinct phone numbers of length n we 
//can dial. 
//
// You are allowed to place the knight on any numeric cell initially and then 
//you should perform n - 1 jumps to dial a number of length n. All jumps should be 
//valid knight jumps. 
//
// As the answer may be very large, return the answer modulo 10⁹ + 7. 
//
// 
// Example 1: 
//
// 
//Input: n = 1
//Output: 10
//Explanation: We need to dial a number of length 1, so placing the knight over 
//any numeric cell of the 10 cells is sufficient.
// 
//
// Example 2: 
//
// 
//Input: n = 2
//Output: 20
//Explanation: All the valid number we can dial are [04, 06, 16, 18, 27, 29, 34,
// 38, 40, 43, 49, 60, 61, 67, 72, 76, 81, 83, 92, 94]
// 
//
// Example 3: 
//
// 
//Input: n = 3131
//Output: 136006598
//Explanation: Please take care of the mod.
// 
//
// 
// Constraints: 
//
// 
// 1 <= n <= 5000 
// 
//
// Related Topics Dynamic Programming 👍 2482 👎 412

namespace KnightDialer
{
    public class Tests
    {
        [Theory]
        [InlineData(1, 10)]
        [InlineData(2, 20)]
        [InlineData(5, 240)]
        [InlineData(6, 544)]
        [InlineData(7, 1256)]
        [InlineData(50, 267287516)]
        [InlineData(3131, 136006598)]
        public void KnightDialerTest(int n, int expectedResul)
        {
            Assert.Equal(expectedResul, new Solution().KnightDialer(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly char[][] Pad =
        {
            new[]
            {
                '1', '2', '3'
            },
            new[]
            {
                '4', '5', '6'
            },
            new[]
            {
                '7', '8', '9'
            },
            new[]
            {
                '*', '0', '#'
            }
        };

        private readonly Dictionary<(int, int, int), int> _memo = new();
        static int mod = (int) 1e9 + 7;

        private int Jump(int x, int y, int n, int digits)
        {
            if (x > Pad.Length - 1 || x < 0 || y > Pad[0].Length - 1 || y < 0)
            {
                return 0;
            }


            if (!char.IsDigit(Pad[x][y]))
            {
                return 0;
            }

            if (digits == n)
            {
                return 1;
            }

            var memoKey = (digits, x, y);
            if (_memo.ContainsKey(memoKey))
            {
                return _memo[memoKey];
            }

            var total = 0;
            total = (total + Jump(x - 1, y - 2, n, digits + 1)) % mod;
            total = (total + Jump(x - 2, y - 1, n, digits + 1)) % mod;
            total = (total + Jump(x + 1, y - 2, n, digits + 1)) % mod;
            total = (total + Jump(x + 2, y - 1, n, digits + 1)) % mod;
            total = (total + Jump(x - 2, y + 1, n, digits + 1)) % mod;
            total = (total + Jump(x - 1, y + 2, n, digits + 1)) % mod;
            total = (total + Jump(x + 1, y + 2, n, digits + 1)) % mod;
            total = (total + Jump(x + 2, y + 1, n, digits + 1)) % mod;
            if (!_memo.ContainsKey(memoKey))
            {
                _memo[memoKey] = total % mod;
            }

            return _memo[memoKey];
        }

        public int KnightDialer(int n)
        {
            var count = 0;

            for (var r = 0; r < Pad.Length; r++)
            {
                for (int c = 0; c < Pad[r].Length; c++)
                {
                    count = (count + Jump(r, c, n, 1)) % mod;
                }
            }

            return count;
        }
    }

//leetcode submit region end(Prohibit modification and deletion)
}