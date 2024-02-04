# You are climbing a staircase. It takes n steps to reach the top. 
# 
#  Each time you can either climb 1 or 2 steps. In how many distinct ways can 
# you climb to the top? 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 2
# Output: 2
# Explanation: There are two ways to climb to the top.
# 1. 1 step + 1 step
# 2. 2 steps
#  
# 
#  Example 2: 
# 
#  
# Input: n = 3
# Output: 3
# Explanation: There are three ways to climb to the top.
# 1. 1 step + 1 step + 1 step
# 2. 1 step + 2 steps
# 3. 2 steps + 1 step
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 45 
#  
# 
#  Related Topics Math Dynamic Programming Memoization 👍 21252 👎 758

import unittest


class ClimbingStairs_Test(unittest.TestCase):

    def test_climbingStairs(self):
        test_data = [
            (2, 2),
            (3, 3),
        ]
        for n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, Solution().climbStairs(n))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:

    def climbStairs(self, n: int) -> int:
        memo = {}

        def climb(i):
            if i > n:
                return 0
            if i == n:
                return 1
            if i in memo:
                return memo[i]
            memo[i] = climb(i + 1) + climb(i + 2)
            return memo[i]

        return climb(1) + climb(2)

# leetcode submit region end(Prohibit modification and deletion)
