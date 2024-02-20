# Given an integer n, return true if it is a power of two. Otherwise, return 
# false. 
# 
#  An integer n is a power of two, if there exists an integer x such that n == 2
# ˣ. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 1
# Output: true
# Explanation: 2⁰ = 1
#  
# 
#  Example 2: 
# 
#  
# Input: n = 16
# Output: true
# Explanation: 2⁴ = 16
#  
# 
#  Example 3: 
# 
#  
# Input: n = 3
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  -2³¹ <= n <= 2³¹ - 1 
#  
# 
#  
# Follow up: Could you solve it without loops/recursion?
# 
#  Related Topics Math Bit Manipulation Recursion 👍 6421 👎 405

import unittest


class PowerOfTwo_Test(unittest.TestCase):

    def test_powerOfTwo(self):
        test_data = [(1, True)]
        for n, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().isPowerOfTwo(n))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:

    def get_all_powers(self):
        powers = set()
        p = 0
        while p < 32:
            powers.add(2 ** p)
            p += 1
        return powers


    def isPowerOfTwo(self, n: int) -> bool:
        powers = self.get_all_powers()
        print(powers)
        return n in powers

# leetcode submit region end(Prohibit modification and deletion)
