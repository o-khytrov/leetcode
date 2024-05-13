# You are given an m x n binary matrix grid. 
# 
#  A move consists of choosing any row or column and toggling each value in 
# that row or column (i.e., changing all 0's to 1's, and all 1's to 0's). 
# 
#  Every row of the matrix is interpreted as a binary number, and the score of 
# the matrix is the sum of these numbers. 
# 
#  Return the highest possible score after making any number of moves (
# including zero moves). 
# 
#  
#  Example 1: 
#  
#  
# Input: grid = [[0,0,1,1],[1,0,1,0],[1,1,0,0]]
# Output: 39
# Explanation: 0b1111 + 0b1001 + 0b1111 = 15 + 9 + 15 = 39
#  
# 
#  Example 2: 
# 
#  
# Input: grid = [[0]]
# Output: 1
#  
# 
#  
#  Constraints: 
# 
#  
#  m == grid.length 
#  n == grid[i].length 
#  1 <= m, n <= 20 
#  grid[i][j] is either 0 or 1. 
#  
# 
#  Related Topics Array Greedy Bit Manipulation Matrix 👍 2126 👎 206
import math
import unittest
from typing import List


class ScoreAfterFlippingMatrix_Test(unittest.TestCase):

    def test_scoreAfterFlippingMatrix(self):
        test_data = [
            ([[0, 0, 1, 1], [1, 0, 1, 0], [1, 1, 0, 0]], 39),
            ([[0]], 1)
        ]
        for matrix, expected in test_data:
            with self.subTest(matrix=matrix, expected=expected):
                self.assertEqual(expected, Solution().matrixScore(matrix))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def matrixScore(self, grid: List[List[int]]) -> int:
        total = 0
        for i in range(len(grid)):
            flip_row = False
            if grid[i][0] == 0:
                flip_row = True
            for j in range(len(grid[i])):
                if flip_row:
                    grid[i][j] = 1 if grid[i][j] == 0 else 0
                if grid[i][j] == 1:
                    p = int(math.pow(2, len(grid[i]) - 1 - j))
                    total += p

        for c in range(len(grid[0])):
            cost = 0
            for r in range(len(grid)):
                p = int(math.pow(2, len(grid[r]) - 1 - c))
                if grid[r][c] == 0:
                    cost += p
                else:
                    cost -= p
            if cost > 0:
                total += cost

        return total
# leetcode submit region end(Prohibit modification and deletion)
