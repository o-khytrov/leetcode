# Given an array nums of size n, return the majority element. 
# 
#  The majority element is the element that appears more than ⌊n / 2⌋ times. 
# You may assume that the majority element always exists in the array. 
# 
#  
#  Example 1: 
#  Input: nums = [3,2,3]
# Output: 3
#  
#  Example 2: 
#  Input: nums = [2,2,1,1,1,2,2]
# Output: 2
#  
#  
#  Constraints: 
# 
#  
#  n == nums.length 
#  1 <= n <= 5 * 10⁴ 
#  -10⁹ <= nums[i] <= 10⁹ 
#  
# 
#  
# Follow-up: Could you solve the problem in linear time and in 
# O(1) space?
# 
#  Related Topics Array Hash Table Divide and Conquer Sorting Counting 👍 18238 
# 👎 567
import math
import unittest
from typing import List


class MajorityElement_Test(unittest.TestCase):

    def test_majorityElement(self):
        test_data = [
            ([3, 2, 3], 3),
            ([2, 2, 1, 1, 1, 2, 2], 2)
        ]
        for nums, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertEqual(expected, Solution().majorityElement(nums))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        m = {}
        n = len(nums)
        for num in nums:
            m[num] = m.get(num, 0) + 1
            if m[num] > n//2:
                return num
        return -1

# leetcode submit region end(Prohibit modification and deletion)
