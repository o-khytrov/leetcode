# You are given an integer array nums consisting of n elements, and an integer 
# k. 
# 
#  Find a contiguous subarray whose length is equal to k that has the maximum 
# average value and return this value. Any answer with a calculation error less 
# than 10⁻⁵ will be accepted. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,12,-5,-6,50,3], k = 4
# Output: 12.75000
# Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [5], k = 1
# Output: 5.00000
#  
# 
#  
#  Constraints: 
# 
#  
#  n == nums.length 
#  1 <= k <= n <= 10⁵ 
#  -10⁴ <= nums[i] <= 10⁴ 
#  
# 
#  Related Topics Array Sliding Window 👍 3287 👎 284

import unittest
from typing import List


class MaximumAverageSubarrayI_Test(unittest.TestCase):

    def test_maximumAverageSubarrayI(self):
        test_data = [
            ([1, 12, -5, -6, 50, 3], 4, 12.75),
            ([5], 1, 5),
            ([4, 0, 4, 3, 3], 5, 2.8),
        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k, expected=expected):
                self.assertEqual(expected, Solution().findMaxAverage(nums, k))
        pass


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findMaxAverage(self, nums: List[int], k: int) -> float:
        l = 0
        r = k - 1
        max_avg = float('-inf')
        sum = 0
        for num in nums[:r]:
            sum += num

        while r < len(nums):
            sum += nums[r]
            if (r - l + 1) > k:
                sum -= nums[l]
                l += 1
            avg = sum / (r - l + 1)
            max_avg = max(max_avg, avg)
            r += 1

        return max_avg

# leetcode submit region end(Prohibit modification and deletion)
