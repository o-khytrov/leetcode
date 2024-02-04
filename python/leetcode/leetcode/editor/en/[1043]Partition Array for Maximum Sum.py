# Given an integer array arr, partition the array into (contiguous) subarrays 
# of length at most k. After partitioning, each subarray has their values changed 
# to become the maximum value of that subarray. 
# 
#  Return the largest sum of the given array after partitioning. Test cases are 
# generated so that the answer fits in a 32-bit integer. 
# 
#  
#  Example 1: 
# 
#  
# Input: arr = [1,15,7,9,2,5,10], k = 3
# Output: 84
# Explanation: arr becomes [15,15,15,9,10,10,10]
#  
# 
#  Example 2: 
# 
#  
# Input: arr = [1,4,1,5,7,3,6,1,9,9,3], k = 4
# Output: 83
#  
# 
#  Example 3: 
# 
#  
# Input: arr = [1], k = 1
# Output: 1
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= arr.length <= 500 
#  0 <= arr[i] <= 10⁹ 
#  1 <= k <= arr.length 
#  
# 
#  Related Topics Array Dynamic Programming 👍 4067 👎 304

import unittest
from typing import List


class PartitionArrayForMaximumSum_Test(unittest.TestCase):

    def test_partitionArrayForMaximumSum(self):
        test_data = [
            ([1, 15, 7, 9, 2, 5, 10], 3, 84),
            ([1, 4, 1, 5, 7, 3, 6, 1, 9, 9, 3], 4, 83)
        ]
        for arr, k, expected in test_data:
            with self.subTest(arr=arr, k=k, expected=expected):
                self.assertEqual(expected, Solution().maxSumAfterPartitioning(arr, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:

    def maxSumAfterPartitioning(self, arr: List[int], k: int) -> int:
        N = len(arr)
        K = k + 1

        dp = [0] * K

        for start in range(N - 1, -1, -1):
            curr_max = 0
            end = min(N, start + k)

            for i in range(start, end):
                curr_max = max(curr_max, arr[i])
                dp[start % K] = max(dp[start % K], dp[(i + 1) % K] + curr_max * (i - start + 1))

        return dp[0]

# leetcode submit region end(Prohibit modification and deletion)
