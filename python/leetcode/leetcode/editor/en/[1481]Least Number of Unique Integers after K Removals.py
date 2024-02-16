# Given an array of integers arr and an integer k. Find the least number of 
# unique integers after removing exactly k elements. 
# 
#  
#  
# 
#  
#  Example 1: 
# 
#  
# Input: arr = [5,5,4], k = 1
# Output: 1
# Explanation: Remove the single 4, only 5 is left.
#  
# 
# Example 2:
# 
#  
# Input: arr = [4,3,1,1,3,3,2], k = 3
# Output: 2
# Explanation: Remove 4, 2 and either one of the two 1s or three 3s. 1 and 3 
# will be left. 
# 
#  
#  Constraints: 
# 
#  
#  1 <= arr.length <= 10^5 
#  1 <= arr[i] <= 10^9 
#  0 <= k <= arr.length 
#  
# 
#  Related Topics Array Hash Table Greedy Sorting Counting 👍 1747 👎 180

import unittest
from typing import List


class LeastNumberOfUniqueIntegersAfterKRemovals_Test(unittest.TestCase):

    def test_leastNumberOfUniqueIntegersAfterKRemovals(self):
        test_data = [
            ([5, 5, 4], 1, 1),
            ([4, 3, 1, 1, 3, 3, 2], 3, 2),
        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k, expected=expected):
                self.assertEqual(expected, Solution().findLeastNumOfUniqueInts(nums, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findLeastNumOfUniqueInts(self, arr: List[int], k: int) -> int:
        m = {}
        for num in arr:
            m[num] = m.get(num, 0) + 1
        ms = sorted(m.items(), key=lambda x: x[1])
        result = len(ms)

        r = k
        for kvp in ms:
            if r == 0:
                break
            rem = min(r, kvp[1])
            if rem == kvp[1]:
                result -= 1
            r -= rem

        return result

# leetcode submit region end(Prohibit modification and deletion)
