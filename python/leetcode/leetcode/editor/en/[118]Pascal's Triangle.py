# Given an integer numRows, return the first numRows of Pascal's triangle. 
# 
#  In Pascal's triangle, each number is the sum of the two numbers directly 
# above it as shown: 
#  
#  
#  Example 1: 
#  Input: numRows = 5
# Output: [[1],[1,1],[1,2,1],[1,3,3,1],[1,4,6,4,1]]
#  
#  Example 2: 
#  Input: numRows = 1
# Output: [[1]]
#  
#  
#  Constraints: 
# 
#  
#  1 <= numRows <= 30 
#  
# 
#  Related Topics Array Dynamic Programming 👍 12401 👎 410
import json
import unittest
from typing import List


class PascalsTriangle_Test(unittest.TestCase):

    def test_pascalsTriangle(self):
        test_data = [(5, "[[1], [1, 1], [1, 2, 1], [1, 3, 3, 1], [1, 4, 6, 4, 1]]")]
        for n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, json.dumps(Solution().generate(n)))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def generate(self, numRows: int) -> List[List[int]]:
        def get_safe(nums, i):
            if i < 0 or i >= len(nums):
                return 0
            return nums[i]

        result = []
        if numRows <= 0:
            return result
        for i in range(numRows):
            row = []
            if i == 0:
                row.append(1)
            else:
                for j in range(i + 1):
                    prev = result[i - 1]
                    row.append(get_safe(prev, j - 1) + get_safe(prev, j ))
            result.append(row)
        return result

# leetcode submit region end(Prohibit modification and deletion)
