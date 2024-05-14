# In a gold mine grid of size m x n, each cell in this mine has an integer 
# representing the amount of gold in that cell, 0 if it is empty. 
# 
#  Return the maximum amount of gold you can collect under the conditions: 
# 
#  
#  Every time you are located in a cell you will collect all the gold in that 
# cell. 
#  From your position, you can walk one step to the left, right, up, or down. 
#  You can't visit the same cell more than once. 
#  Never visit a cell with 0 gold. 
#  You can start and stop collecting gold from any position in the grid that 
# has some gold. 
#  
# 
#  
#  Example 1: 
# 
#  
# Input: grid = [[0,6,0],[5,8,7],[0,9,0]]
# Output: 24
# Explanation:
# [[0,6,0],
#  [5,8,7],
#  [0,9,0]]
# Path to get the maximum gold, 9 -> 8 -> 7.
#  
# 
#  Example 2: 
# 
#  
# Input: grid = [[1,0,7],[2,0,6],[3,4,5],[0,3,0],[9,0,20]]
# Output: 28
# Explanation:
# [[1,0,7],
#  [2,0,6],
#  [3,4,5],
#  [0,3,0],
#  [9,0,20]]
# Path to get the maximum gold, 1 -> 2 -> 3 -> 4 -> 5 -> 6 -> 7.
#  
# 
#  
#  Constraints: 
# 
#  
#  m == grid.length 
#  n == grid[i].length 
#  1 <= m, n <= 15 
#  0 <= grid[i][j] <= 100 
#  There are at most 25 cells containing gold. 
#  
# 
#  Related Topics Array Backtracking Matrix 👍 3003 👎 82

import unittest
from typing import List


class PathWithMaximumGold_Test(unittest.TestCase):

    def test_pathWithMaximumGold(self):
        test_data = [
            ([[0, 6, 0], [5, 8, 7], [0, 9, 0]], 24),
            ([[1, 0, 7], [2, 0, 6], [3, 4, 5], [0, 3, 0], [9, 0, 20]], 28)
        ]
        for grid, expected in test_data:
            with self.subTest(grid=grid, expected=expected):
                self.assertEqual(expected, Solution().getMaximumGold(grid))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def getMaximumGold(self, grid: List[List[int]]) -> int:
        def backtrack(grid, i, j):
            if i < 0 or i >= len(grid) or j < 0 or j >= len(grid[0]):
                return 0
            if grid[i][j] <= 0:
                return 0
            tmp = grid[i][j]
            s = tmp
            grid[i][j] = -1
            left = backtrack(grid, i, j + 1)
            right = backtrack(grid, i, j - 1)
            up = backtrack(grid, i - 1, j)
            down = backtrack(grid, i + 1, j)
            grid[i][j] = tmp
            return tmp + max(left, right, up, down)

        ans = 0
        for i in range(len(grid)):
            for j in range(len(grid[i])):
                ans = max(ans, backtrack(grid, i, j))

        return ans

# leetcode submit region end(Prohibit modification and deletion)
