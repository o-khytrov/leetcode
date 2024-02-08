# Given an integer n, return the least number of perfect square numbers that 
# sum to n. 
# 
#  A perfect square is an integer that is the square of an integer; in other 
# words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 
# are perfect squares while 3 and 11 are not. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 12
# Output: 3
# Explanation: 12 = 4 + 4 + 4.
#  
# 
#  Example 2: 
# 
#  
# Input: n = 13
# Output: 2
# Explanation: 13 = 4 + 9.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 10⁴ 
#  
# 
#  Related Topics Math Dynamic Programming Breadth-First Search 👍 10604 👎 433

import unittest


class PerfectSquares_Test(unittest.TestCase):

    def test_perfectSquares(self):
        test_data = [
            (12, 3),
            (13, 2),
            (1, 1),
        ]
        for n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, Solution().numSquares(n))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def __init__(self):
        self.memo = {}

    def numSquares(self, n: int) -> int:
        if n == 1:
            return 1
        if n == 0:
            return 0
        if n in self.memo:
            return self.memo[n]
        i = 1
        answer = -1
        while i * i <= n:
            s = i * i
            sub_problem = n - s
            sub_solution = self.numSquares(sub_problem)

            if sub_solution >= 0:
                if answer > 0:
                    answer = min(answer, sub_solution + 1)
                else:
                    answer = sub_solution + 1
            i += 1
        self.memo[n] = answer
        return self.memo[n]

# leetcode submit region end(Prohibit modification and deletion)
