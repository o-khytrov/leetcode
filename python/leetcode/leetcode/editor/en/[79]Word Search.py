# Given an m x n grid of characters board and a string word, return true if 
# word exists in the grid. 
# 
#  The word can be constructed from letters of sequentially adjacent cells, 
# where adjacent cells are horizontally or vertically neighboring. The same letter 
# cell may not be used more than once. 
# 
#  
#  Example 1: 
#  
#  
# Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
#  "ABCCED"
# Output: true
#  
# 
#  Example 2: 
#  
#  
# Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
#  "SEE"
# Output: true
#  
# 
#  Example 3: 
#  
#  
# Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
#  "ABCB"
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  m == board.length 
#  n = board[i].length 
#  1 <= m, n <= 6 
#  1 <= word.length <= 15 
#  board and word consists of only lowercase and uppercase English letters. 
#  
# 
#  
#  Follow up: Could you use search pruning to make your solution faster with a 
# larger board? 
# 
#  Related Topics Array Backtracking Matrix 👍 14919 👎 617

import unittest
from typing import List


class WordSearch_Test(unittest.TestCase):

    def test_wordSearch(self):
        test_data = [
            ([["A", "B", "C", "E"], ["S", "F", "C", "S"], ["A", "D", "E", "E"]], "ABCCED", True),
            ([["A", "B", "C", "E"], ["S", "F", "C", "S"], ["A", "D", "E", "E"]], "SEE", True),
            ([["A", "B", "C", "E"], ["S", "F", "C", "S"], ["A", "D", "E", "E"]], "ABCB", False)
        ]
        for grid, word, expected in test_data:
            with self.subTest(grid=grid, word=word, expected=expected):
                self.assertEqual(expected, Solution().exist(grid, word))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def exist(self, board: List[List[str]], word: str) -> bool:

        n = len(board)
        w = len(board[0])

        def dfs(row, col, pos, visited):
            if pos == len(word):
                return True
            if row < 0 or row > n - 1 or col < 0 or col > w - 1:
                return False
            if (row, col) in visited:
                return False
            val = board[row][col]
            if val != word[pos]:
                return False
            visited.add((row, col))
            if dfs(row - 1, col, pos + 1, set(visited)):
                return True

            if dfs(row + 1, col, pos + 1, set(visited)):
                return True

            if dfs(row, col + 1, pos + 1, set(visited)):
                return True

            if dfs(row, col - 1, pos + 1, set(visited)):
                return True

            return False

        for r, row in enumerate(board):
            for c, col in enumerate(row):
                if col == word[0]:
                    if dfs(r, c, 0, set()):
                        return True
        return False

# leetcode submit region end(Prohibit modification and deletion)
