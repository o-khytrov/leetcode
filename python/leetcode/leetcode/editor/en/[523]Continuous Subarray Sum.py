# Given an integer array nums and an integer k, return true if nums has a good 
# subarray or false otherwise. 
# 
#  A good subarray is a subarray where: 
# 
#  
#  its length is at least two, and 
#  the sum of the elements of the subarray is a multiple of k. 
#  
# 
#  Note that: 
# 
#  
#  A subarray is a contiguous part of the array. 
#  An integer x is a multiple of k if there exists an integer n such that x = n 
# * k. 0 is always a multiple of k. 
#  
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [23,2,4,6,7], k = 6
# Output: true
# Explanation: [2, 4] is a continuous subarray of size 2 whose elements sum up 
# to 6.
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [23,2,6,4,7], k = 6
# Output: true
# Explanation: [23, 2, 6, 4, 7] is an continuous subarray of size 5 whose 
# elements sum up to 42.
# 42 is a multiple of 6 because 42 = 7 * 6 and 7 is an integer.
#  
# 
#  Example 3: 
# 
#  
# Input: nums = [23,2,6,4,7], k = 13
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁵ 
#  0 <= nums[i] <= 10⁹ 
#  0 <= sum(nums[i]) <= 2³¹ - 1 
#  1 <= k <= 2³¹ - 1 
#  
# 
#  Related Topics Array Hash Table Math Prefix Sum 👍 5819 👎 586

import unittest
from typing import List


class ContinuousSubarraySum_Test(unittest.TestCase):

    def test_continuousSubarraySum(self):
        test_data = [
            ([23, 2, 4, 6, 7], 6, True),
            ([23, 2, 6, 4, 7], 6, True),
            ([23, 2, 6, 4, 7], 13, False),
            ([23, 2, 4, 6, 6], 7, True),
            ([5, 0, 0, 0], 3, True),
            ([2, 4, 3], 6, True),
            ([1, 3, 6, 0, 9, 6, 9], 7, True),
            ([1, 0], 2, False),
            ([1, 2, 12], 6, False)

        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k):
                self.assertEqual(expected, Solution().checkSubarraySum(nums, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def checkSubarraySum(self, nums: List[int], k: int) -> bool:
        s = 0
        m = {0: -1}

        print("-------------------------------")
        print(nums, k)
        for i in range(len(nums)):
            s += nums[i]
            print(m)
            if s % k in m:
                if i - m[s % k] >= 2:
                    return True
            else:
                m[s % k] = i
        print("-------------------------------")
        return False
    # leetcode submit region end(Prohibit modification and deletion)
