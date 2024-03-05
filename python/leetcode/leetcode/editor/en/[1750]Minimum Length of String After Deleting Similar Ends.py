# Given a string s consisting only of characters 'a', 'b', and 'c'. You are 
# asked to apply the following algorithm on the string any number of times: 
# 
#  
#  Pick a non-empty prefix from the string s where all the characters in the 
# prefix are equal. 
#  Pick a non-empty suffix from the string s where all the characters in this 
# suffix are equal. 
#  The prefix and the suffix should not intersect at any index. 
#  The characters from the prefix and suffix must be the same. 
#  Delete both the prefix and the suffix. 
#  
# 
#  Return the minimum length of s after performing the above operation any 
# number of times (possibly zero times). 
# 
#  
#  Example 1: 
# 
#  
# Input: s = "ca"
# Output: 2
# Explanation: You can't remove any characters, so the string stays as is.
#  
# 
#  Example 2: 
# 
#  
# Input: s = "cabaabac"
# Output: 0
# Explanation: An optimal sequence of operations is:
# - Take prefix = "c" and suffix = "c" and remove them, s = "abaaba".
# - Take prefix = "a" and suffix = "a" and remove them, s = "baab".
# - Take prefix = "b" and suffix = "b" and remove them, s = "aa".
# - Take prefix = "a" and suffix = "a" and remove them, s = "". 
# 
#  Example 3: 
# 
#  
# Input: s = "aabccabba"
# Output: 3
# Explanation: An optimal sequence of operations is:
# - Take prefix = "aa" and suffix = "a" and remove them, s = "bccabb".
# - Take prefix = "b" and suffix = "bb" and remove them, s = "cca".
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 10⁵ 
#  s only consists of characters 'a', 'b', and 'c'. 
#  
# 
#  Related Topics Two Pointers String 👍 885 👎 72

import unittest


class MinimumLengthOfStringAfterDeletingSimilarEnds_Test(unittest.TestCase):

    def test_minimumLengthOfStringAfterDeletingSimilarEnds(self):
        test_data = [("ca", 2), ("cabaabac", 0), ("aabccabba", 3),
                     ("bbbbbbbbbbbbbbbbbbbbbbbbbbbabbbbbbbbbbbbbbbccbcbcbccbbabbb", 1),
                     ("abbbbbbbbbbbbbbbbbbba", 0)
                     ]
        for s, expected in test_data:
            with self.subTest(s=s, expected=expected):
                self.assertEqual(expected, Solution().minimumLength(s))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def minimumLength(self, s: str) -> int:
        l = 0
        r = len(s) - 1
        while l < r and s[l] == s[r]:

            common = s[l]
            l += 1
            r -= 1
            while l <= r and s[l] == common:
                l += 1
            while l <= r and s[r] == common:
                r -= 1

        return r - l + 1

    # leetcode submit region end(Prohibit modification and deletion)
