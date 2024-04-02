# Given two strings s and t, determine if they are isomorphic. 
# 
#  Two strings s and t are isomorphic if the characters in s can be replaced to 
# get t. 
# 
#  All occurrences of a character must be replaced with another character while 
# preserving the order of characters. No two characters may map to the same 
# character, but a character may map to itself. 
# 
#  
#  Example 1: 
#  Input: s = "egg", t = "add"
# Output: true
#  
#  Example 2: 
#  Input: s = "foo", t = "bar"
# Output: false
#  
#  Example 3: 
#  Input: s = "paper", t = "title"
# Output: true
#  
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 5 * 10⁴ 
#  t.length == s.length 
#  s and t consist of any valid ascii character. 
#  
# 
#  Related Topics Hash Table String 👍 8444 👎 1956

import unittest


class IsomorphicStrings_Test(unittest.TestCase):

    def test_isomorphicStrings(self):
        test_data = [
            ("egg", "add", True),
            ("foo", "bar", False),
            ("paper", "title", True),
            ("badc", "baba", False)
        ]
        for s, t, expected in test_data:
            with self.subTest(s=s, t=t):
                self.assertEqual(expected, Solution().isIsomorphic(s, t))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def isIsomorphic(self, s: str, t: str) -> bool:
        m = {}
        m2 = {}
        if len(s) != len(t):
            return False
        for c1, c2 in zip(s, t):
            if c1 in m:
                if m[c1] != c2:
                    return False
            else:
                m[c1] = c2
            if c2 in m2:
                if m2[c2] != c1:
                    return False
            else:
                m2[c2] = c1
        return True

# leetcode submit region end(Prohibit modification and deletion)
