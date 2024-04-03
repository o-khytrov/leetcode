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
            ([["A", "B", "C", "E"], ["S", "F", "C", "S"], ["A", "D", "E", "E"]], "ABCB", False),
            ([["a", "b"], ["c", "d"]], "cdba", True)
        ]
        for grid, word, expected in test_data:
            with self.subTest(grid=grid, word=word, expected=expected):
                self.assertEqual(expected, Solution().exist(grid, word))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def dfs(self, board, row, col, word, index):
        if row < 0 or row >= len(board) or col < 0 or col >= len(board[0]):
            return False

        if board[row][col] != word[index]:
            return False
        if index == len(word) - 1:
            return True
        tmp = board[row][col]
        board[row][col] = '\0'
        up = self.dfs(board, row + 1, col, word, index + 1)
        down = self.dfs(board, row - 1, col, word, index + 1)
        right = self.dfs(board, row, col + 1, word, index + 1)
        left = self.dfs(board, row, col - 1, word, index + 1)
        board[row][col] = tmp
        return up or down or right or left

    def exist(self, board: List[List[str]], word: str) -> bool:
        for row in range(len(board)):
            for column in range(len(board[row])):
                if board[row][column] == word[0]:
                    if self.dfs(board, row, column, word, 0):
                        return True
        return False

# leetcode submit region end(Prohibit modification and deletion)
