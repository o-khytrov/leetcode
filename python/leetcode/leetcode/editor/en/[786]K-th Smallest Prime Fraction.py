# You are given a sorted integer array arr containing 1 and prime numbers, 
# where all the integers of arr are unique. You are also given an integer k. 
# 
#  For every i and j where 0 <= i < j < arr.length, we consider the fraction 
# arr[i] / arr[j]. 
# 
#  Return the kᵗʰ smallest fraction considered. Return your answer as an array 
# of integers of size 2, where answer[0] == arr[i] and answer[1] == arr[j]. 
# 
#  
#  Example 1: 
# 
#  
# Input: arr = [1,2,3,5], k = 3
# Output: [2,5]
# Explanation: The fractions to be considered in sorted order are:
# 1/5, 1/3, 2/5, 1/2, 3/5, and 2/3.
# The third fraction is 2/5.
#  
# 
#  Example 2: 
# 
#  
# Input: arr = [1,7], k = 1
# Output: [1,7]
#  
# 
#  
#  Constraints: 
# 
#  
#  2 <= arr.length <= 1000 
#  1 <= arr[i] <= 3 * 10⁴ 
#  arr[0] == 1 
#  arr[i] is a prime number for i > 0. 
#  All the numbers of arr are unique and sorted in strictly increasing order. 
#  1 <= k <= arr.length * (arr.length - 1) / 2 
#  
# 
#  
# Follow up: Can you solve the problem with better than 
# O(n²) complexity?
# 
#  Related Topics Array Two Pointers Binary Search Sorting Heap (Priority Queue)
#  👍 1442 👎 71

import unittest
from fractions import Fraction
from typing import List


class KThSmallestPrimeFraction_Test(unittest.TestCase):

    def test_kThSmallestPrimeFraction(self):
        test_data = [
            ([1, 2, 3, 5], 3, [2, 5]),
            ([1, 7], 1, [1, 7])
        ]
        for nums, k, expected in test_data:
            with self.subTest(nums=nums, k=k):
                self.assertSequenceEqual(expected, Solution().kthSmallestPrimeFraction(nums, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def kthSmallestPrimeFraction(self, arr: List[int], k: int) -> List[int]:
        fractions = []
        for i in range(len(arr)):
            for j in range(i + 1, len(arr)):
                fractions.append((arr[i], arr[j]))
        fractions = sorted(fractions, key=lambda x: x[0] / x[1])
        result = fractions[k - 1]
        return [result[0], result[1]]

# leetcode submit region end(Prohibit modification and deletion)
