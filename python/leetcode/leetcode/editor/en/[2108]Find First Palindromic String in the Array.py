# Given an array of strings words, return the first palindromic string in the 
# array. If there is no such string, return an empty string "". 
# 
#  A string is palindromic if it reads the same forward and backward. 
# 
#  
#  Example 1: 
# 
#  
# Input: words = ["abc","car","ada","racecar","cool"]
# Output: "ada"
# Explanation: The first string that is palindromic is "ada".
# Note that "racecar" is also palindromic, but it is not the first.
#  
# 
#  Example 2: 
# 
#  
# Input: words = ["notapalindrome","racecar"]
# Output: "racecar"
# Explanation: The first and only string that is palindromic is "racecar".
#  
# 
#  Example 3: 
# 
#  
# Input: words = ["def","ghi"]
# Output: ""
# Explanation: There are no palindromic strings, so the empty string is 
# returned.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= words.length <= 100 
#  1 <= words[i].length <= 100 
#  words[i] consists only of lowercase English letters. 
#  
# 
#  Related Topics Array Two Pointers String 👍 1254 👎 42

import unittest
from typing import List


class FindFirstPalindromicStringInTheArray_Test(unittest.TestCase):

    def test_findFirstPalindromicStringInTheArray(self):
        test_data = [(["abc", "car", "ada", "racecar", "cool"], "ada"),
                     (["notapalindrome", "racecar"], "racecar")
                     ]
        for words, expected in test_data:
            with self.subTest(words=words, expected=expected):
                self.assertEqual(expected, Solution().firstPalindrome(words))
        pass


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def firstPalindrome(self, words: List[str]) -> str:
        def is_palindrome(string: str):
            l = 0
            r = len(string) - 1
            while l <= r:
                if string[l] != string[r]:
                    return False
                l += 1
                r -= 1
            return True

        for word in words:
            if is_palindrome(word):
                return word
        return ""
# leetcode submit region end(Prohibit modification and deletion)
