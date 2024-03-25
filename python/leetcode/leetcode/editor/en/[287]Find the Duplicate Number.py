# Given an array of integers nums containing n + 1 integers where each integer 
# is in the range [1, n] inclusive. 
# 
#  There is only one repeated number in nums, return this repeated number. 
# 
#  You must solve the problem without modifying the array nums and uses only 
# constant extra space. 
# 
#  
#  Example 1: 
# 
#  
# Input: nums = [1,3,4,2,2]
# Output: 2
#  
# 
#  Example 2: 
# 
#  
# Input: nums = [3,1,3,4,2]
# Output: 3
#  
# 
#  Example 3: 
# 
#  
# Input: nums = [3,3,3,3,3]
# Output: 3 
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 10⁵ 
#  nums.length == n + 1 
#  1 <= nums[i] <= n 
#  All the integers in nums appear only once except for precisely one integer 
# which appears two or more times. 
#  
# 
#  
#  Follow up: 
# 
#  
#  How can we prove that at least one duplicate number must exist in nums? 
#  Can you solve the problem in linear runtime complexity? 
#  
# 
#  Related Topics Array Two Pointers Binary Search Bit Manipulation 👍 22628 👎 
# 4261

import unittest
from typing import List


class FindTheDuplicateNumber_Test(unittest.TestCase):

    def test_findTheDuplicateNumber(self):
        pass


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        m = {}
        for n in nums:
            m[n] = m.get(n, 0) + 1
            if m[n] > 1:
                return n
        return -1

# leetcode submit region end(Prohibit modification and deletion)
