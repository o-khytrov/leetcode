# Given an m x n 2D binary grid grid which represents a map of '1's (land) and 
# '0's (water), return the number of islands. 
# 
#  An island is surrounded by water and is formed by connecting adjacent lands 
# horizontally or vertically. You may assume all four edges of the grid are all 
# surrounded by water. 
# 
#  
#  Example 1: 
# 
#  
# Input: grid = [
#   ["1","1","1","1","0"],
#   ["1","1","0","1","0"],
#   ["1","1","0","0","0"],
#   ["0","0","0","0","0"]
# ]
# Output: 1
#  
# 
#  Example 2: 
# 
#  
# Input: grid = [
#   ["1","1","0","0","0"],
#   ["1","1","0","0","0"],
#   ["0","0","1","0","0"],
#   ["0","0","0","1","1"]
# ]
# Output: 3
#  
# 
#  
#  Constraints: 
# 
#  
#  m == grid.length 
#  n == grid[i].length 
#  1 <= m, n <= 300 
#  grid[i][j] is '0' or '1'. 
#  
# 
#  Related Topics Array Depth-First Search Breadth-First Search Union Find 
# Matrix 👍 22276 👎 499

import unittest
from typing import List


class NumberOfIslands_Test(unittest.TestCase):

    def test_numberOfIslands(self):
        test_data = [
            (
                [["1", "1", "1", "1", "0"],
                 ["1", "1", "0", "1", "0"],
                 ["1", "1", "0", "0", "0"],
                 ["0", "0", "0", "0", "0"]],
                1),

            (
                [["1", "1", "0", "0", "0"],
                 ["1", "1", "0", "0", "0"],
                 ["0", "0", "1", "0", "0"],
                 ["0", "0", "0", "1", "1"]],
                3),
            (
                [["1", "1", "1", "1", "0"],
                 ["1", "1", "0", "1", "0"],
                 ["1", "1", "0", "0", "0"],
                 ["0", "0", "0", "0", "0"]],1
            )
        ]
        for grid, expected in test_data:
            with self.subTest(grid=grid, expected=expected):
                self.assertEqual(expected, Solution().numIslands(grid))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def numIslands(self, grid: List[List[str]]) -> int:
        visited = set()
        n = 0

        def dfs(row, col):
            if row < 0 or row > len(grid) - 1 or col < 0 or col > len(grid[0]) - 1:
                return
            if grid[row][col] != "1":
                return

            grid[row][col] = '2'
            dfs(row + 1, col)
            dfs(row - 1, col)
            dfs(row, col + 1)
            dfs(row, col - 1)

        for r in range(len(grid)):
            for c in range(len(grid[r])):
                if grid[r][c] == "1":
                    n += 1
                    dfs(r, c)
        return n
