# Given a string s containing only three types of characters: '(', ')' and '*', 
# return true if s is valid. 
# 
#  The following rules define a valid string: 
# 
#  
#  Any left parenthesis '(' must have a corresponding right parenthesis ')'. 
#  Any right parenthesis ')' must have a corresponding left parenthesis '('. 
#  Left parenthesis '(' must go before the corresponding right parenthesis ')'. 
# 
#  '*' could be treated as a single right parenthesis ')' or a single left 
# parenthesis '(' or an empty string "". 
#  
# 
#  
#  Example 1: 
#  Input: s = "()"
# Output: true
#  
#  Example 2: 
#  Input: s = "(*)"
# Output: true
#  
#  Example 3: 
#  Input: s = "(*))"
# Output: true
#  
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 100 
#  s[i] is '(', ')' or '*'. 
#  
# 
#  Related Topics String Dynamic Programming Stack Greedy 👍 5395 👎 156

import unittest
from functools import cache


class ValidParenthesisString_Test(unittest.TestCase):

    def test_validParenthesisString(self):
        test_data = [
            ("()", True),
            ("(*)", True),
            ("(*))", True),
            ("(((((()*)(*)*))())())(()())())))((**)))))(()())()", False),
            (
                "((((()(()()()*()(((((*)()*(**(())))))(())()())(((())())())))))))(((((())*)))()))(()((*()*(*)))(*)()",
                True)
        ]
        for s, expected in test_data:
            with self.subTest(s=s, expected=expected):
                self.assertEqual(expected, Solution().checkValidString(s))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:

    def __init__(self):
        self.memo = {}

    def checkValidString(self, s: str) -> bool:
        n = len(s)

        @cache
        def dfs(index, balance):
            if index == n:
                return balance == 0
            if balance < 0:
                return False
            if s[index] == "(":
                return dfs(index + 1, balance + 1)
            if s[index] == ")":
                return dfs(index + 1, balance - 1)
            else:
                return dfs(index + 1, balance - 1) or dfs(index + 1, balance + 1) or dfs(index + 1, balance)

        return dfs(0, 0)

# leetcode submit region end(Prohibit modification and deletion)
