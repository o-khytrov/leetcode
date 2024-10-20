# A boolean expression is an expression that evaluates to either true or false. 
# It can be in one of the following shapes: 
# 
#  
#  't' that evaluates to true. 
#  'f' that evaluates to false. 
#  '!(subExpr)' that evaluates to the logical NOT of the inner expression 
# subExpr. 
#  '&(subExpr1, subExpr2, ..., subExprn)' that evaluates to the logical AND of 
# the inner expressions subExpr1, subExpr2, ..., subExprn where n >= 1. 
#  '|(subExpr1, subExpr2, ..., subExprn)' that evaluates to the logical OR of 
# the inner expressions subExpr1, subExpr2, ..., subExprn where n >= 1. 
#  
# 
#  Given a string expression that represents a boolean expression, return the 
# evaluation of that expression. 
# 
#  It is guaranteed that the given expression is valid and follows the given 
# rules. 
# 
#  
#  Example 1: 
# 
#  
# Input: expression = "&(|(f))"
# Output: false
# Explanation: 
# First, evaluate |(f) --> f. The expression is now "&(f)".
# Then, evaluate &(f) --> f. The expression is now "f".
# Finally, return false.
#  
# 
#  Example 2: 
# 
#  
# Input: expression = "|(f,f,f,t)"
# Output: true
# Explanation: The evaluation of (false OR false OR false OR true) is true.
#  
# 
#  Example 3: 
# 
#  
# Input: expression = "!(&(f,t))"
# Output: true
# Explanation: 
# First, evaluate &(f,t) --> (false AND true) --> false --> f. The expression 
# is now "!(f)".
# Then, evaluate !(f) --> NOT false --> true. We return true.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= expression.length <= 2 * 10⁴ 
#  expression[i] is one following characters: '(', ')', '&', '|', '!', 't', 'f',
#  and ','. 
#  
# 
#  Related Topics String Stack Recursion 👍 1495 👎 75
import unittest


class Tests(unittest.TestCase):
    def test(self):
        test_data = [
            ("&(|(f))", False),
            ("|(f,f,f,t)", True),
            ("!(&(f,t))", True),
            ("|(&(t,f,t),t)", True),
            ("|(&(t,f,t),!(t))", False),
            (
                "&(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))),&(!(&(&(!(&(f)),&(t),|(f,f,t)),|(t),|(f,f,t))),!(&(&(&(t,t,f),|(f,f,t),|(f)),!(&(t)),!(&(|(f,f,t),&(&(f),&(!(t),&(f),|(f)),&(!(&(f)),&(t),|(f,f,t))),&(t))))),!(&(f))))",
                False)
        ]
        for expression, expected in test_data:
            with self.subTest(expression=expression, expected=expected):
                self.assertEqual(expected, Solution().parseBoolExpr(expression))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def parseBoolExpr(self, expression: str) -> bool:
        print(expression)

        def parse_not(i: int) -> (bool, int):

            if expression[i] == "t":
                return False, i + 2
            if expression[i] == "f":
                return True, i + 2
            if expression[i] == "&":
                res, i = parse_and(i + 2)
                return True if not res else False, i + 1
            if expression[i] == "|":
                res, i = parse_and(i + 2)
                return True if not res else False, i + 1
            if expression[i] == "!":
                res, i = parse_not(i + 2)
                return True if not res else False, i + 1

        def parse_or(i: int) -> (bool, int):
            temp = i
            is_true = False
            while i < len(expression):
                if expression[i] == "t":
                    is_true = True
                if expression[i] == "&":
                    res, i = parse_and(i + 2)
                    if res:
                        is_true = True
                if expression[i] == "|":
                    res, i = parse_or(i + 2)
                    if res:
                        is_true = True
                if expression[i] == "!":
                    res, i = parse_not(i + 2)
                    if res:
                        is_true = True
                if expression[i] == ")":
                    break
                i += 1
            print(f"\tor:{expression[temp:i]} {is_true}")
            return is_true, i + 1

        def parse_and(i: int) -> (bool, int):
            is_true = True
            temp = i

            while i < len(expression):
                if expression[i] == "f":
                    is_true = False
                if expression[i] == "&":
                    res, i = parse_and(i + 2)
                    if not res:
                        is_true = False
                if expression[i] == "|":
                    res, i = parse_or(i + 2)
                    if not res:
                        is_true = False
                if expression[i] == "!":
                    res, i = parse_not(i + 2)
                    if not res:
                        is_true = False
                if expression[i] == ")":
                    break
                i += 1
            print(f"\tand:{expression[temp:i]} {is_true}")
            return is_true, i + 1

        result = True
        if expression[0] == "!":
            result, _ = parse_not(2)

        if expression[0] == "|":
            result, _ = parse_or(2)

        if expression[0] == "&":
            result, _ = parse_and(2)
        print(f"\t{result}")
        return result

# leetcode submit region end(Prohibit modification and deletion)
