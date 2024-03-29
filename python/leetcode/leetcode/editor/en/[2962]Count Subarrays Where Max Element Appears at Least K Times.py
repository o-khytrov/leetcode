# You are given an integer array nums and a positive integer k. 
# 
#  Return the number of subarrays where the maximum element of nums appears at 
# least k times in that subarray. 
# 
#  A subarray is a contiguous sequence of elements within an array. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,3,2,3,3], k = 2
# Output: 6
# Explanation: The subarrays that contain the element 3 at least 2 times are: [1
# ,3,2,3], [1,3,2,3,3], [3,2,3], [3,2,3,3], [2,3,3] and [3,3].
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [1,4,2,1], k = 3
# Output: 0
# Explanation: No subarray contains the element 4 at least 3 times.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁵ 
#  1 <= nums[i] <= 10⁶ 
#  1 <= k <= 10⁵ 
#  
# 
#  Related Topics Array Sliding Window 👍 818 👎 39

import unittest
from typing import List


class CountSubarraysWhereMaxElementAppearsAtLeastKTimes_Test(unittest.TestCase):

    def test_countSubarraysWhereMaxElementAppearsAtLeastKTimes(self):
        test_data = [
            ([1, 3, 2, 3, 3], 2, 6),
            ([1, 4, 2, 1], 3, 0),
            ([28, 5, 58, 91, 24, 91, 53, 9, 48, 85, 16, 70, 91, 91, 47, 91, 61, 4, 54, 61, 49], 1, 187)

        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k):
                self.assertEqual(expected, Solution().countSubarrays(nums, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        l = 0
        r = 0
        max_value = max(nums)
        max_count = 0
        ans = 0
        while r < len(nums):
            if nums[r] == max_value:
                max_count += 1
            while max_count == k:
                if nums[l] == max_value:
                    max_count -= 1
                l += 1
            ans += l
            r += 1

        return ans

# leetcode submit region end(Prohibit modification and deletion)
