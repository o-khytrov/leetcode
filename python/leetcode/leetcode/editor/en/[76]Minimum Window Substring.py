# Given two strings s and t of lengths m and n respectively, return the minimum 
# window substring of s such that every character in t (including duplicates) is 
# included in the window. If there is no such substring, return the empty string 
# "". 
# 
#  The testcases will be generated such that the answer is unique. 
# 
#  
#  Example 1: 
# 
#  
# Input: s = "ADOBECODEBANC", t = "ABC"
# Output: "BANC"
# Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' 
# from string t.
#  
# 
#  Example 2: 
# 
#  
# Input: s = "a", t = "a"
# Output: "a"
# Explanation: The entire string s is the minimum window.
#  
# 
#  Example 3: 
# 
#  
# Input: s = "a", t = "aa"
# Output: ""
# Explanation: Both 'a's from t must be included in the window.
# Since the largest window of s only has one 'a', return empty string.
#  
# 
#  
#  Constraints: 
# 
#  
#  m == s.length 
#  n == t.length 
#  1 <= m, n <= 10⁵ 
#  s and t consist of uppercase and lowercase English letters. 
#  
# 
#  
#  Follow up: Could you find an algorithm that runs in O(m + n) time? 
# 
#  Related Topics Hash Table String Sliding Window 👍 17016 👎 692

import unittest


class MinimumWindowSubstring_Test(unittest.TestCase):

    def test_minimumWindowSubstring(self):
        test_data = [
            ("ADOBECODEBANC", "ABC", "BANC"),
            ("a", "aa", ""),
            ("a", "a", "a"),
        ]
        for s, t, expected in test_data:
            with self.subTest(s=s, t=t, expected=expected):
                self.assertEqual(expected, Solution().minWindow(s, t))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def minWindow(self, s: str, t: str) -> str:
        target = {}
        for c in t:
            if c in target.keys():
                target[c] += 1
            else:
                target[c] = 1

        def is_subset(tar, sour):
            for key, value in tar.items():
                if key not in sour.keys() or sour[key] < value:
                    return False
            return True

        window = {c: 0 for c in s}
        ans = ""
        r = 0
        l = 0
        while r < len(s):
            window[s[r]] += 1
            while l <= r and is_subset(target, window):
                tmp = s[l:r + 1]
                if len(tmp) < len(ans) or ans == "":
                    ans = tmp
                window[s[l]] -= 1
                l += 1
            r += 1
        return ans

# leetcode submit region end(Prohibit modification and deletion)
