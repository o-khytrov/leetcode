# Given n non-negative integers representing an elevation map where the width 
# of each bar is 1, compute how much water it can trap after raining. 
# 
#  
#  Example 1: 
#  
#  
# Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
# Output: 6
# Explanation: The above elevation map (black section) is represented by array [
# 0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) 
# are being trapped.
#  
# 
#  Example 2: 
# 
#  
# Input: height = [4,2,0,3,2,5]
# Output: 9
#  
# 
#  
#  Constraints: 
# 
#  
#  n == height.length 
#  1 <= n <= 2 * 10⁴ 
#  0 <= height[i] <= 10⁵ 
#  
# 
#  Related Topics Array Two Pointers Dynamic Programming Stack Monotonic Stack ?
# ? 31354 👎 488

import unittest
from typing import List


class TrappingRainWater_Test(unittest.TestCase):

    def test_trappingRainWater(self):
        test_data = [
            ([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1], 6),
            ([4, 2, 0, 3, 2, 5], 9),
            ([2, 0, 2], 2),
            ([4, 2, 3], 1)
        ]
        for data, expected in test_data:
            with self.subTest(data=data, expected=expected):
                self.assertEqual(expected, Solution().trap(data))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def trap(self, height: List[int]) -> int:
        w = 0
        max_right = [0] * len(height)
        max_left = [0] * len(height)
        max_l = 0
        max_r = 0
        for i, h in enumerate(height):
            max_l = max(max_l, h)
            max_left[i] = max_l
        i = len(height) - 1
        while i >= 0:
            max_r = max(max_r, height[i])
            max_right[i] = max_r
            i -= 1
        for i, h in enumerate(height):
            min_lr = min(max_left[i], max_right[i])
            if min_lr > h:
                w += min_lr - h
        return w

# leetcode submit region end(Prohibit modification and deletion)
