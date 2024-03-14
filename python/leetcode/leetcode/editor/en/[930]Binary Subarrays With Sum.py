# Given a binary array nums and an integer goal, return the number of non-empty 
# subarrays with a sum goal. 
# 
#  A subarray is a contiguous part of the array. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,0,1,0,1], goal = 2
# Output: 4
# Explanation: The 4 subarrays are bolded and underlined below:
# [1,0,1,0,1]
# [1,0,1,0,1]
# [1,0,1,0,1]
# [1,0,1,0,1]
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [0,0,0,0,0], goal = 0
# Output: 15
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 3 * 10⁴ 
#  nums[i] is either 0 or 1. 
#  0 <= goal <= nums.length 
#  
# 
#  Related Topics Array Hash Table Sliding Window Prefix Sum 👍 3522 👎 115

import unittest
from typing import List


class BinarySubarraysWithSum_Test(unittest.TestCase):

    def test_binarySubarraysWithSum(self):
        test_data = [
            ([1, 0, 1, 0, 1], 2, 4),
            ([0, 0, 0, 0, 0], 0, 15)
        ]
        for nums, goal, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertEqual(expected, Solution().numSubarraysWithSum(nums, goal))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def numSubarraysWithSum(self, nums: List[int], goal: int) -> int:
        total_count = 0
        current_sum = 0
        m = {}
        for num in nums:
            current_sum += num
            if current_sum == goal:
                total_count += 1
            if current_sum - goal in m:
                total_count += m[current_sum - goal]
            m[current_sum] = m.get(current_sum, 0) + 1
        return total_count

# leetcode submit region end(Prohibit modification and deletion)
