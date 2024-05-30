# Given an array of integers arr. 
# 
#  We want to select three indices i, j and k where (0 <= i < j <= k < arr.
# length). 
# 
#  Let's define a and b as follows: 
# 
#  
#  a = arr[i] ^ arr[i + 1] ^ ... ^ arr[j - 1] 
#  b = arr[j] ^ arr[j + 1] ^ ... ^ arr[k] 
#  
# 
#  Note that ^ denotes the bitwise-xor operation. 
# 
#  Return the number of triplets (i, j and k) Where a == b. 
# 
#  
#  Example 1: 
# 
#  
# Input: arr = [2,3,1,6,7]
# Output: 4
# Explanation: The triplets are (0,1,2), (0,2,2), (2,3,4) and (2,4,4)
#  
# 
#  Example 2: 
# 
#  
# Input: arr = [1,1,1,1,1]
# Output: 10
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= arr.length <= 300 
#  1 <= arr[i] <= 10⁸ 
#  
# 
#  Related Topics Array Hash Table Math Bit Manipulation Prefix Sum 👍 1809 👎 1
# 18

import unittest
from typing import List


class CountTripletsThatCanFormTwoArraysOfEqualXor_Test(unittest.TestCase):

    def test_countTripletsThatCanFormTwoArraysOfEqualXor(self):
        test_data = [
            ([2, 3, 1, 6, 7], 4),
            ([1, 1, 1, 1, 1], 10)
        ]
        for arr, expected in test_data:
            with self.subTest(arr=arr, expected=expected):
                self.assertEqual(expected, Solution().countTriplets(arr))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def countTriplets(self, arr: List[int]) -> int:
        count = 0
        for i in range(len(arr)):
            xor = arr[i]
            for j in range(i + 1, len(arr)):
                xor ^= arr[j]
                l = j - i + 1
                if xor == 0 and l >= 2:
                    count += l - 1
        return count

# leetcode submit region end(Prohibit modification and deletion)
