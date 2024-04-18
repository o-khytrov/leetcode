# You are given row x col grid representing a map where grid[i][j] = 1 
# represents land and grid[i][j] = 0 represents water. 
# 
#  Grid cells are connected horizontally/vertically (not diagonally). The grid 
# is completely surrounded by water, and there is exactly one island (i.e., one or 
# more connected land cells). 
# 
#  The island doesn't have "lakes", meaning the water inside isn't connected to 
# the water around the island. One cell is a square with side length 1. The grid 
# is rectangular, width and height don't exceed 100. Determine the perimeter of 
# the island. 
# 
#  
#  Example 1: 
#  
#  
# Input: grid = [[0,1,0,0],[1,1,1,0],[0,1,0,0],[1,1,0,0]]
# Output: 16
# Explanation: The perimeter is the 16 yellow stripes in the image above.
#  
# 
#  Example 2: 
# 
#  
# Input: grid = [[1]]
# Output: 4
#  
# 
#  Example 3: 
# 
#  
# Input: grid = [[1,0]]
# Output: 4
#  
# 
#  
#  Constraints: 
# 
#  
#  row == grid.length 
#  col == grid[i].length 
#  1 <= row, col <= 100 
#  grid[i][j] is 0 or 1. 
#  There is exactly one island in grid. 
#  
# 
#  Related Topics Array Depth-First Search Breadth-First Search Matrix 👍 6401 ?
# ? 343

import unittest
from typing import List


class IslandPerimeter_Test(unittest.TestCase):

    def test_islandPerimeter(self):
        test_data = [
            ([[0, 1, 0, 0], [1, 1, 1, 0], [0, 1, 0, 0], [1, 1, 0, 0]], 16),
            ([[1]], 4),
            ([[1, 0]], 4)
        ]
        for grid, expected in test_data:
            with self.subTest(test_data=grid, expected=expected):
                self.assertEqual(expected, Solution().islandPerimeter(grid))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def islandPerimeter(self, grid: List[List[int]]) -> int:
        p = [0]
        visited = set()

        def get_neighbor(row, col):
            if row < 0 or row >= len(grid) or col < 0 or col >= len(grid[0]):
                return 1
            return 1 if not grid[row][col] else 0

        def get_cell_borers(row, col):
            b = 0
            b += get_neighbor(row - 1, col)
            b += get_neighbor(row + 1, col)
            b += get_neighbor(row, col + 1)
            b += get_neighbor(row, col - 1)
            return b

        def dfs(row, col):
            if row < 0 or row >= len(grid) or col < 0 or col >= len(grid[0]):
                return
            if (row, col) in visited:
                return
            visited.add((row, col))
            if grid[row][col] == 0:
                return
            p[0] += get_cell_borers(row, col)
            dfs(row + 1, col)
            dfs(row - 1, col)
            dfs(row, col - 1)
            dfs(row, col + 1)

        for r in range(len(grid)):
            for c in range(len(grid[r])):
                if grid[r][c] == 1:
                    dfs(r, c)
                    break

        return p[0]

# leetcode submit region end(Prohibit modification and deletion)
