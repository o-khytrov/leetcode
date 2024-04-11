# Given string num representing a non-negative integer num, and an integer k, 
# return the smallest possible integer after removing k digits from num. 
# 
#  
#  Example 1: 
# 
#  
# Input: num = "1432219", k = 3
# Output: "1219"
# Explanation: Remove the three digits 4, 3, and 2 to form the new number 1219 
# which is the smallest.
#  
# 
#  Example 2: 
# 
#  
# Input: num = "10200", k = 1
# Output: "200"
# Explanation: Remove the leading 1 and the number is 200. Note that the output 
# must not contain leading zeroes.
#  
# 
#  Example 3: 
# 
#  
# Input: num = "10", k = 2
# Output: "0"
# Explanation: Remove all the digits from the number and it is left with 
# nothing which is 0.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= k <= num.length <= 10⁵ 
#  num consists of only digits. 
#  num does not have any leading zeros except for the zero itself. 
#  
# 
#  Related Topics String Stack Greedy Monotonic Stack 👍 8778 👎 426

import unittest


class RemoveKDigits_Test(unittest.TestCase):

    def test_removeKDigits(self):
        test_data = [
            ("1432219", 3, "1219"),
            ("10200", 1, "200"),
            ("10", 2, "0"),
            ("10", 1, "0"),
            ("112", 1, "11"),
            ("1111111", 3, "1111")

        ]
        for num, k, exp in test_data:
            with self.subTest(num=num, k=k, exp=exp):
                self.assertEqual(exp, Solution().removeKdigits(num, k))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def removeKdigits(self, num: str, k: int) -> str:
        stack = []
        for digit in num:
            while stack and k > 0 and stack[-1] > digit:
                stack.pop()
                k -= 1
            stack.append(digit)
        stack = stack[:-k] if k > 0 else stack
        return ''.join(stack).lstrip("0") or "0"

# leetcode submit region end(Prohibit modification and deletion)
