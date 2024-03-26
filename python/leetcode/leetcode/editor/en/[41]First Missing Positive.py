# Given an unsorted integer array nums. Return the smallest positive integer 
# that is not present in nums. 
# 
#  You must implement an algorithm that runs in O(n) time and uses O(1) 
# auxiliary space. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,2,0]
# Output: 3
# Explanation: The numbers in the range [1,2] are all in the array.
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [3,4,-1,1]
# Output: 2
# Explanation: 1 is in the array but 2 is missing.
#  
# 
#  Example 3: 
# 
#  
# Input: nums = [7,8,9,11,12]
# Output: 1
# Explanation: The smallest positive integer 1 is missing.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁵ 
#  -2³¹ <= nums[i] <= 2³¹ - 1 
#  
# 
#  Related Topics Array Hash Table 👍 16461 👎 1813

import unittest
from typing import List


class FirstMissingPositive_Test(unittest.TestCase):

    def test_firstMissingPositive(self):
        test_data = [
            ([1, 2, 0], 3),
            ([3, 4, -1, 1], 2),
            ([7, 8, 9, 11, 12], 1)
        ]
        for nums, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertEquals(expected, Solution().firstMissingPositive(nums))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def firstMissingPositive(self, nums: List[int]) -> int:
        m = {}
        min_val = 10_000_000
        max_val = -10_000_000
        for num in nums:
            if num > 0:
                m[num] = m.get(num, 0) + 1
                min_val = min(min_val, num)
                max_val = max(max_val, num)
        if min_val > 1:
            for i in range(1, min_val):
                if i not in m:
                    return i
        for i in range(min_val, max_val):
            if i not in m:
                return i
        return max_val + 1

# leetcode submit region end(Prohibit modification and deletion)
