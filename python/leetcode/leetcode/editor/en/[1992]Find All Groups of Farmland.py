# You are given a 0-indexed m x n binary matrix land where a 0 represents a 
# hectare of forested land and a 1 represents a hectare of farmland. 
# 
#  To keep the land organized, there are designated rectangular areas of 
# hectares that consist entirely of farmland. These rectangular areas are called groups. 
# No two groups are adjacent, meaning farmland in one group is not four-
# directionally adjacent to another farmland in a different group. 
# 
#  land can be represented by a coordinate system where the top left corner of 
# land is (0, 0) and the bottom right corner of land is (m-1, n-1). Find the 
# coordinates of the top left and bottom right corner of each group of farmland. A 
# group of farmland with a top left corner at (r1, c1) and a bottom right corner at (r2
# , c2) is represented by the 4-length array [r1, c1, r2, c2]. 
# 
#  Return a 2D array containing the 4-length arrays described above for each 
# group of farmland in land. If there are no groups of farmland, return an empty 
# array. You may return the answer in any order. 
# 
#  
#  Example 1: 
#  
#  
# Input: land = [[1,0,0],[0,1,1],[0,1,1]]
# Output: [[0,0,0,0],[1,1,2,2]]
# Explanation:
# The first group has a top left corner at land[0][0] and a bottom right corner 
# at land[0][0].
# The second group has a top left corner at land[1][1] and a bottom right 
# corner at land[2][2].
#  
# 
#  Example 2: 
#  
#  
# Input: land = [[1,1],[1,1]]
# Output: [[0,0,1,1]]
# Explanation:
# The first group has a top left corner at land[0][0] and a bottom right corner 
# at land[1][1].
#  
# 
#  Example 3: 
#  
#  
# Input: land = [[0]]
# Output: []
# Explanation:
# There are no groups of farmland.
#  
# 
#  
#  Constraints: 
# 
#  
#  m == land.length 
#  n == land[i].length 
#  1 <= m, n <= 300 
#  land consists of only 0's and 1's. 
#  Groups of farmland are rectangular in shape. 
#  
# 
#  Related Topics Array Depth-First Search Breadth-First Search Matrix 👍 1040 ?
# ? 55

import unittest
from typing import List


class FindAllGroupsOfFarmland_Test(unittest.TestCase):

    def test_findAllGroupsOfFarmland(self):
        test_data = [
            ([[1, 0, 0], [0, 1, 1], [0, 1, 1]], [[0, 0, 0, 0], [1, 1, 2, 2]]),
            ([[1, 1], [1, 1]], [[0, 0, 1, 1]])
        ]
        for land, expected in test_data:
            with self.subTest(land=land, expected=expected):
                self.assertSequenceEqual(expected, Solution().findFarmland(land))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findFarmland(self, land: List[List[int]]) -> List[List[int]]:
        result = []

        def dfs(row, col):
            x = row
            y = col
            while y < len(land[x]) and land[x][y] == 1:
                y += 1

            while x < len(land) and land[x][col] == 1:
                for i in range(col, y):
                    land[x][i] = 2.
                x += 1
            y -= 1
            x = x - 1

            return x, y

        for r in range(len(land)):
            for c in range(len(land[r])):
                if land[r][c] == 1:
                    x1, y1 = r, c
                    x2, y2 = dfs(x1, y1)
                    result.append([x1, y1, x2, y2])
        return result

# leetcode submit region end(Prohibit modification and deletion)
