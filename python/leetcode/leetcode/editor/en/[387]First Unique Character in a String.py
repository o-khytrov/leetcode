# Given a string s, find the first non-repeating character in it and return its 
# index. If it does not exist, return -1. 
# 
#  
#  Example 1: 
#  Input: s = "leetcode"
# Output: 0
#  
#  Example 2: 
#  Input: s = "loveleetcode"
# Output: 2
#  
#  Example 3: 
#  Input: s = "aabb"
# Output: -1
#  
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 10⁵ 
#  s consists of only lowercase English letters. 
#  
# 
#  Related Topics Hash Table String Queue Counting 👍 8580 👎 279

import unittest


class FirstUniqueCharacterInAString_Test(unittest.TestCase):

    def test_firstUniqueCharacterInAString(self):
        test_data = [
            ("leetcode", 0),
            ("loveleetcode", 2),
            ("aabb", -1),
        ]
        for s, expected in test_data:
            with self.subTest(s=s, expected=expected):
                self.assertEqual(expected, Solution().firstUniqChar(s))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def firstUniqChar(self, s: str) -> int:
        map = {}
        for i, c in enumerate(s):
            if c not in map:
                map[c] = (1, i)
            else:
                map[c] = (map[c][0] + 1, i)
        unique = {}
        for c in map:
            if map[c][0] == 1:
                unique[c] = map[c][1]
        if len(unique) == 0:
            return -1
        return [v for v in sorted(unique.values())][0]

# leetcode submit region end(Prohibit modification and deletion)
