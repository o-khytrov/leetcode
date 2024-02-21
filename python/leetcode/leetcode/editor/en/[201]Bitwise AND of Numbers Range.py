# Given two integers left and right that represent the range [left, right], 
# return the bitwise AND of all numbers in this range, inclusive. 
# 
#  
#  Example 1: 
# 
#  
# Input: left = 5, right = 7
# Output: 4
#  
# 
#  Example 2: 
# 
#  
# Input: left = 0, right = 0
# Output: 0
#  
# 
#  Example 3: 
# 
#  
# Input: left = 1, right = 2147483647
# Output: 0
#  
# 
#  
#  Constraints: 
# 
#  
#  0 <= left <= right <= 2³¹ - 1 
#  
# 
#  Related Topics Bit Manipulation 👍 3663 👎 274

import unittest


class BitwiseAndOfNumbersRange_Test(unittest.TestCase):

    def test_bitwiseAndOfNumbersRange(self):
        pass


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def rangeBitwiseAnd(self, left: int, right: int) -> int:
        res = 0
        for i in range(32):
            bit = (left >> i) & 1
            if not bit:
                continue
            remain = left % (1 << (i + 1))
            diff = (1 << (i + 1)) - remain
            if right - left < diff:
                res = res | (1 << i)
        return res

# leetcode submit region end(Prohibit modification and deletion)
