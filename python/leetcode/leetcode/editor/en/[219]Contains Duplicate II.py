# Given an integer array nums and an integer k, return true if there are two 
# distinct indices i and j in the array such that nums[i] == nums[j] and abs(i - j) <
# = k. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,2,3,1], k = 3
# Output: true
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [1,0,1,1], k = 1
# Output: true
#  
# 
#  Example 3: 
# 
#  
# Input: nums = [1,2,3,1,2,3], k = 2
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= nums.length <= 10⁵ 
#  -10⁹ <= nums[i] <= 10⁹ 
#  0 <= k <= 10⁵ 
#  
# 
#  Related Topics Array Hash Table Sliding Window 👍 5878 👎 2999

import unittest
from typing import List


class ContainsDuplicateIi_Test(unittest.TestCase):

    def test_containsDuplicateIi(self):
        test_data = [
            ([1, 2, 3, 1], 3, True),
            ([1, 2, 3, 1, 2, 3], 2, False),
        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k, expected=expected):
                self.assertEqual(expected, Solution().containsNearbyDuplicate(nums, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def containsNearbyDuplicate(self, nums: List[int], k: int) -> bool:
        s = {}
        for i, num in enumerate(nums):
            if num in s and abs(s[num] - i) <= k:
                return True
            s[num] = i
        return False

# leetcode submit region end(Prohibit modification and deletion)
