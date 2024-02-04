# Given an array of integers nums which is sorted in ascending order, and an 
# integer target, write a function to search target in nums. If target exists, then 
# return its index. Otherwise, return -1. 
# 
#  You must write an algorithm with O(log n) runtime complexity. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [-1,0,3,5,9,12], target = 9
# Output: 4
# Explanation: 9 exists in nums and its index is 4
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [-1,0,3,5,9,12], target = 2
# Output: -1
# Explanation: 2 does not exist in nums so return -1
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁴ 
#  -10⁴ < nums[i], target < 10⁴ 
#  All the integers in nums are unique. 
#  nums is sorted in ascending order. 
#  
# 
#  Related Topics Array Binary Search 👍 11397 👎 233

import unittest
from typing import List


class BinarySearch_Test(unittest.TestCase):

    def test_binarySearch(self):
        test_data = [
            ([-1, 0, 3, 5, 9, 12], 9, 4),
            ([-1, 0, 3, 5, 9, 12], 2, -1),
        ]
        for nums, target, expected in test_data:
            with self.subTest(nums=nums, target=target, expected=expected):
                self.assertEqual(expected, Solution().search(nums, target))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        l = 0
        r = len(nums) - 1
        while l <= r:
            mid = (l + r) // 2
            val = nums[mid]
            if val == target:
                return mid
            if val > target:
                r = mid - 1
            else:
                l = mid + 1
        return -1

# leetcode submit region end(Prohibit modification and deletion)
