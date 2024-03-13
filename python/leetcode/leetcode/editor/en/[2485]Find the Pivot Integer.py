# Given a positive integer n, find the pivot integer x such that: 
# 
#  
#  The sum of all elements between 1 and x inclusively equals the sum of all 
# elements between x and n inclusively. 
#  
# 
#  Return the pivot integer x. If no such integer exists, return -1. It is 
# guaranteed that there will be at most one pivot index for the given input. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 8
# Output: 6
# Explanation: 6 is the pivot integer since: 1 + 2 + 3 + 4 + 5 + 6 = 6 + 7 + 8 =
#  21.
#  
# 
#  Example 2: 
# 
#  
# Input: n = 1
# Output: 1
# Explanation: 1 is the pivot integer since: 1 = 1.
#  
# 
#  Example 3: 
# 
#  
# Input: n = 4
# Output: -1
# Explanation: It can be proved that no such integer exist.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 1000 
#  
# 
#  Related Topics Math Prefix Sum 👍 1172 👎 42

import unittest


class FindThePivotInteger_Test(unittest.TestCase):

    def test_findThePivotInteger(self):
        test_data = [
            (8, 6),
            (1, 1),
            (4, -1)
        ]
        for n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, Solution().pivotInteger(n))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def pivotInteger(self, n: int) -> int:
        sums = [0]
        for i in range(1, n + 1):
            sums.append(i + sums[i - 1])
        i = n
        s = 0
        while i >= 0:
            s += i
            if sums[i] == s:
                return i
            i -= 1
        return -1

# leetcode submit region end(Prohibit modification and deletion)
