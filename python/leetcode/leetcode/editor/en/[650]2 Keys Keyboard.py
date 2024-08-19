# There is only one character 'A' on the screen of a notepad. You can perform 
# one of two operations on this notepad for each step: 
# 
#  
#  Copy All: You can copy all the characters present on the screen (a partial 
# copy is not allowed). 
#  Paste: You can paste the characters which are copied last time. 
#  
# 
#  Given an integer n, return the minimum number of operations to get the 
# character 'A' exactly n times on the screen. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 3
# Output: 3
# Explanation: Initially, we have one character 'A'.
# In step 1, we use Copy All operation.
# In step 2, we use Paste operation to get 'AA'.
# In step 3, we use Paste operation to get 'AAA'.
#  
# 
#  Example 2: 
# 
#  
# Input: n = 1
# Output: 0
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 1000 
#  
# 
#  Related Topics Math Dynamic Programming 👍 4063 👎 238
import unittest


class Tests(unittest.TestCase):
    def test(self):
        test_data = [
            (2, 2),
            (3, 3),
            (1, 0)
        ]
        for n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, Solution().minSteps(n))


if __name__ == "__main__":
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def minSteps(self, n: int) -> int:
        def recursion(screen, buffer):
            if screen > n:
                return float('inf')
            if screen == n:
                return 0
            if buffer > 0:
                paste = recursion(screen + buffer, buffer) + 1
            else:
                paste = float("inf")
            copy = recursion(screen * 2, screen) + 2

            return min(paste, copy)

        return recursion(1, 0)

    # leetcode submit region end(Prohibit modification and deletion)
