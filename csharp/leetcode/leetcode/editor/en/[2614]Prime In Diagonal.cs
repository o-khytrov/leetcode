/**
You are given a 0-indexed two-dimensional integer array nums.

 Return the largest prime number that lies on at least one of the diagonals of
nums. In case, no prime is present on any of the diagonals, return 0.

 Note that:


 An integer is prime if it is greater than 1 and has no positive integer
divisors other than 1 and itself.
 An integer val is on one of the diagonals of nums if there exists an integer i
for which nums[i][i] = val or an i for which nums[i][nums.length - i - 1] = val.





 In the above diagram, one diagonal is [1,5,9] and another diagonal is [3,5,7].



 Example 1:


Input: nums = [[1,2,3],[5,6,7],[9,10,11]]
Output: 11
Explanation: The numbers 1, 3, 6, 9, and 11 are the only numbers present on at
least one of the diagonals. Since 11 is the largest prime, we return 11.


 Example 2:


Input: nums = [[1,2,3],[5,17,7],[9,11,10]]
Output: 17
Explanation: The numbers 1, 3, 9, 10, and 17 are all present on at least one of
the diagonals. 17 is the largest prime, so we return 17.



 Constraints:


 1 <= nums.length <= 300
 nums.length == numsi.length
 1 <= nums[i][j] <= 4*10⁶


 Related Topics Array Math Matrix Number Theory 👍 287 👎 29

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace PrimeInDiagonal
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,3],[5,6,7],[9,10,11]]", 11)]
        [InlineData("[[1,2,3],[5,17,7],[9,11,10]]", 17)]
        public void PrimeInDiagonalTest(string matrixJson, int expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson) ??
                         throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().DiagonalPrime(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly HashSet<int> Primes = new();

        private bool IsPrime(int number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (Primes.Contains(number))
            {
                return true;
            }

            var tmp = number;
            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            Primes.Add(number);
            return true;
        }

        public int DiagonalPrime(int[][] nums)
        {
            var maxPrime = 0;
            var l = 0;
            var r = nums.Length - 1;
            foreach (var row in nums)
            {
                var left = row[l];
                var right = row[r];
                if (IsPrime(left))
                {
                    maxPrime = Math.Max(maxPrime, left);
                }

                if (IsPrime(right))
                {
                    maxPrime = Math.Max(maxPrime, right);
                }

                l++;
                r--;
            }

            return maxPrime;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}