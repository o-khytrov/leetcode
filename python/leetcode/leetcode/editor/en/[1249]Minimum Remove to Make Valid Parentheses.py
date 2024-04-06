# Given a string s of '(' , ')' and lowercase English characters. 
# 
#  Your task is to remove the minimum number of parentheses ( '(' or ')', in 
# any positions ) so that the resulting parentheses string is valid and return any 
# valid string. 
# 
#  Formally, a parentheses string is valid if and only if: 
# 
#  
#  It is the empty string, contains only lowercase characters, or 
#  It can be written as AB (A concatenated with B), where A and B are valid 
# strings, or 
#  It can be written as (A), where A is a valid string. 
#  
# 
#  
#  Example 1: 
# 
#  
# Input: s = "lee(t(c)o)de)"
# Output: "lee(t(c)o)de"
# Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
#  
# 
#  Example 2: 
# 
#  
# Input: s = "a)b(c)d"
# Output: "ab(c)d"
#  
# 
#  Example 3: 
# 
#  
# Input: s = "))(("
# Output: ""
# Explanation: An empty string is also valid.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 10⁵ 
#  s[i] is either'(' , ')', or lowercase English letter. 
#  
# 
#  Related Topics String Stack 👍 6488 👎 130

import unittest


class MinimumRemoveToMakeValidParentheses_Test(unittest.TestCase):

    def test_minimumRemoveToMakeValidParentheses(self):
        test_data = [
            ("lee(t(c)o)de)", "lee(t(c)o)de"),
            ("a)b(c)d", "ab(c)d"),
            ("))((", ""),
            ("(a(b(c)d)", "a(b(c)d)")

        ]
        for s, expected in test_data:
            with self.subTest(s=s, expected=expected):
                self.assertEqual(expected, Solution().minRemoveToMakeValid(s))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def minRemoveToMakeValid(self, s: str) -> str:
        stack = []
        open = 0
        closed = 0

        for c in s:
            stack.append(c)
            if c == "(":
                open += 1
            if c == ")":
                closed += 1
            if closed > open:
                stack.pop()
                closed -= 1
        s = "".join(stack)
        stack = []

        open = 0
        closed = 0
        i = len(s) - 1
        while i >= 0:
            c = s[i]
            stack.append(c)
            if c == "(":
                open += 1
            if c == ")":
                closed += 1
            if open > closed:
                stack.pop()
                open -= 1
            i -= 1
        return "".join(stack)[::-1]

# leetcode submit region end(Prohibit modification and deletion)
