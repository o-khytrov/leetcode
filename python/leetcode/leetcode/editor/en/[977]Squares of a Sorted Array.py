# Given an integer array nums sorted in non-decreasing order, return an array 
# of the squares of each number sorted in non-decreasing order. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [-4,-1,0,3,10]
# Output: [0,1,9,16,100]
# Explanation: After squaring, the array becomes [16,1,0,9,100].
# After sorting, it becomes [0,1,9,16,100].
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [-7,-3,2,3,11]
# Output: [4,9,9,49,121]
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁴ 
#  -10⁴ <= nums[i] <= 10⁴ 
#  nums is sorted in non-decreasing order. 
#  
# 
#  
# Follow up: Squaring each element and sorting the new array is very trivial, 
# could you find an 
# O(n) solution using a different approach?
# 
#  Related Topics Array Two Pointers Sorting 👍 8881 👎 222

import unittest
from typing import List


class SquaresOfASortedArray_Test(unittest.TestCase):

    def test_squaresOfASortedArray(self):
        test_data = [([-4, -1, 0, 3, 10], [0, 1, 9, 16, 100]),
                     ([-7, -3, 2, 3, 11], [4, 9, 9, 49, 121])
                     ]
        for arr, expected in test_data:
            with self.subTest():
                self.assertSequenceEqual(expected, Solution().sortedSquares(arr))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def sortedSquares(self, nums: List[int]) -> List[int]:
        return sorted(n * n for n in nums)

# leetcode submit region end(Prohibit modification and deletion)
