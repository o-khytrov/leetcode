# An n x n grid is composed of 1 x 1 squares where each 1 x 1 square consists 
# of a '/', '\', or blank space ' '. These characters divide the square into 
# contiguous regions. 
# 
#  Given the grid grid represented as a string array, return the number of 
# regions. 
# 
#  Note that backslash characters are escaped, so a '\' is represented as '\\'. 
# 
# 
#  
#  Example 1: 
#  
#  
# Input: grid = [" /","/ "]
# Output: 2
#  
# 
#  Example 2: 
#  
#  
# Input: grid = [" /","  "]
# Output: 1
#  
# 
#  Example 3: 
#  
#  
# Input: grid = ["/\\","\\/"]
# Output: 5
# Explanation: Recall that because \ characters are escaped, "\\/" refers to \/,
#  and "/\\" refers to /\.
#  
# 
#  
#  Constraints: 
# 
#  
#  n == grid.length == grid[i].length 
#  1 <= n <= 30 
#  grid[i][j] is either '/', '\', or ' '. 
#  
# 
#  Related Topics Array Hash Table Depth-First Search Breadth-First Search 
# Union Find Matrix 👍 3456 👎 703
import unittest
from typing import List


class Tests(unittest.TestCase):
    def test_case1(self):
        test_data = [
            ([" /", "/ "], 2),
            (["/\\", "\\/"], 5)

        ]
        for grid, expected in test_data:
            with self.subTest(grid=grid, expected=expected):
                self.assertEquals(expected, Solution().regionsBySlashes(grid))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def regionsBySlashes(self, grid: List[str]) -> int:
        scaled = [[0] * (len(grid) * 3) for _ in range(len(grid) * 3)]
        for i, row in enumerate(grid):
            for j, cell in enumerate(row):
                if cell == "/":
                    scaled[i * 3 + 2][j * 3] = 1  # bottom left
                    scaled[i * 3 + 1][j * 3 + 1] = 1  # center
                    scaled[i * 3][j * 3 + 2] = 1  # rop right
                if cell == "\\":
                    scaled[i * 3][j * 3] = 1  # top left
                    scaled[i * 3 + 1][j * 3 + 1] = 1  # center
                    scaled[i * 3 + 2][j * 3 + 2] = 1  # rop right

        def dfs(r, c):
            if r < 0 or r == len(scaled) or c < 0 or c == len(scaled[r]) or scaled[r][c] != 0:
                return
            scaled[r][c] = -1
            dfs(r + 1, c)
            dfs(r - 1, c)
            dfs(r, c + 1)
            dfs(r, c - 1)

        ans = 0
        for r in range(len(scaled)):
            for c in range(len(scaled[r])):
                if scaled[r][c] == 0:
                    ans += 1
                    dfs(r, c)
        return ans

# leetcode submit region end(Prohibit modification and deletion)
