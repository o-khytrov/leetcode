# Given an integer array nums of length n where all the integers of nums are in 
# the range [1, n] and each integer appears once or twice, return an array of all 
# the integers that appears twice. 
# 
#  You must write an algorithm that runs in O(n) time and uses only constant 
# extra space. 
# 
#  
#  Example 1: 
#  Input: nums = [4,3,2,7,8,2,3,1]
# Output: [2,3]
#  
#  Example 2: 
#  Input: nums = [1,1,2]
# Output: [1]
#  
#  Example 3: 
#  Input: nums = [1]
# Output: []
#  
#  
#  Constraints: 
# 
#  
#  n == nums.length 
#  1 <= n <= 10⁵ 
#  1 <= nums[i] <= n 
#  Each element in nums appears once or twice. 
#  
# 
#  Related Topics Array Hash Table 👍 10166 👎 386

import unittest
from typing import List


class FindAllDuplicatesInAnArray_Test(unittest.TestCase):

    def test_findAllDuplicatesInAnArray(self):
        test_data = [
            ([4, 3, 2, 7, 8, 2, 3, 1], [2, 3]),
            ([1, 1, 2], [1])
        ]
        for nums, expected in test_data:
            with self.subTest(nums=nums, expected=expected):
                self.assertSequenceEqual(expected, Solution().findDuplicates(nums))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findDuplicates(self, nums: List[int]) -> List[int]:
        result = set()
        nums.sort()
        prev = None
        for i in range(len(nums)):
            if nums[i] == prev:
                result.add(nums[i])
            prev = nums[i]

        return list(result)

# leetcode submit region end(Prohibit modification and deletion)
