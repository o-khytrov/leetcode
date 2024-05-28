# You are given two strings s and t of the same length and an integer maxCost. 
# 
#  You want to change s to t. Changing the iᵗʰ character of s to iᵗʰ character 
# of t costs |s[i] - t[i]| (i.e., the absolute difference between the ASCII values 
# of the characters). 
# 
#  Return the maximum length of a substring of s that can be changed to be the 
# same as the corresponding substring of t with a cost less than or equal to 
# maxCost. If there is no substring from s that can be changed to its corresponding 
# substring from t, return 0. 
# 
#  
#  Example 1: 
# 
#  
# Input: s = "abcd", t = "bcdf", maxCost = 3
# Output: 3
# Explanation: "abc" of s can change to "bcd".
# That costs 3, so the maximum length is 3.
#  
# 
#  Example 2: 
# 
#  
# Input: s = "abcd", t = "cdef", maxCost = 3
# Output: 1
# Explanation: Each character in s costs 2 to change to character in t,  so the 
# maximum length is 1.
#  
# 
#  Example 3: 
# 
#  
# Input: s = "abcd", t = "acde", maxCost = 0
# Output: 1
# Explanation: You cannot make any change, so the maximum length is 1.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 10⁵ 
#  t.length == s.length 
#  0 <= maxCost <= 10⁶ 
#  s and t consist of only lowercase English letters. 
#  
# 
#  Related Topics String Binary Search Sliding Window Prefix Sum 👍 1675 👎 126

import unittest


class GetEqualSubstringsWithinBudget_Test(unittest.TestCase):

    def test_getEqualSubstringsWithinBudget(self):
        test_data = [
            ("abcd", "bcdf", 3, 3),
            ("abcd", "cdef", 3, 1),
            ("abcd", "acde", 0, 1)
        ]
        for s, t, maxCost, expected in test_data:
            with self.subTest(s=s, t=t, expected=expected):
                self.assertEqual(expected, Solution().equalSubstring(s, t, maxCost))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def equalSubstring(self, s: str, t: str, maxCost: int) -> int:
        curCost = 0
        l = 0
        res = 0
        for r in range(len(s)):
            curCost += abs(ord(s[r]) - ord(t[r]))
            while curCost > maxCost:
                curCost -= abs(ord(s[l]) - ord(t[l]))
                l += 1
            res = max(res, r-l+1)
        return res
# leetcode submit region end(Prohibit modification and deletion)
