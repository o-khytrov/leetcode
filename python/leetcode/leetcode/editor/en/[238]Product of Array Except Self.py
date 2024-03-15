# Given an integer array nums, return an array answer such that answer[i] is 
# equal to the product of all the elements of nums except nums[i]. 
# 
#  The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit 
# integer. 
# 
#  You must write an algorithm that runs in O(n) time and without using the 
# division operation. 
# 
#  
#  Example 1: 
#  Input: nums = [1,2,3,4]
# Output: [24,12,8,6]
#  
#  Example 2: 
#  Input: nums = [-1,1,0,-3,3]
# Output: [0,0,9,0,0]
#  
#  
#  Constraints: 
# 
#  
#  2 <= nums.length <= 10⁵ 
#  -30 <= nums[i] <= 30 
#  The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit 
# integer. 
#  
# 
#  
#  Follow up: Can you solve the problem in O(1) extra space complexity? (The 
# output array does not count as extra space for space complexity analysis.) 
# 
#  Related Topics Array Prefix Sum 👍 21728 👎 1322

import unittest
from typing import List


class ProductOfArrayExceptSelf_Test(unittest.TestCase):

    def test_productOfArrayExceptSelf(self):
        test_data = [
            ([1, 2, 3, 4], [24, 12, 8, 6]),
            ([-1, 1, 0, -3, 3], [0, 0, 9, 0, 0])
        ]
        for nums, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertSequenceEqual(expected, Solution().productExceptSelf(nums))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def productExceptSelf(self, nums: List[int]) -> List[int]:
        prefix = [1]
        prefix2 = [1]
        for i in range(len(nums)):
            prefix.append(prefix[-1] * nums[i])
            prefix2.append(prefix2[-1] * nums[len(nums) - 1 - i])
        prefix2.reverse()
        result = []
        for i in range(1, len(prefix2)):
            left = prefix[i-1]
            right = prefix2[i]
            result.append(left*right)
        return result

    # leetcode submit region end(Prohibit modification and deletion)
