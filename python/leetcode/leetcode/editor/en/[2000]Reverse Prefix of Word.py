# Given a 0-indexed string word and a character ch, reverse the segment of word 
# that starts at index 0 and ends at the index of the first occurrence of ch (
# inclusive). If the character ch does not exist in word, do nothing. 
# 
#  
#  For example, if word = "abcdefd" and ch = "d", then you should reverse the 
# segment that starts at 0 and ends at 3 (inclusive). The resulting string will be 
# "dcbaefd". 
#  
# 
#  Return the resulting string. 
# 
#  
#  Example 1: 
# 
#  
# Input: word = "abcdefd", ch = "d"
# Output: "dcbaefd"
# Explanation: The first occurrence of "d" is at index 3. 
# Reverse the part of word from 0 to 3 (inclusive), the resulting string is 
# "dcbaefd".
#  
# 
#  Example 2: 
# 
#  
# Input: word = "xyxzxe", ch = "z"
# Output: "zxyxxe"
# Explanation: The first and only occurrence of "z" is at index 3.
# Reverse the part of word from 0 to 3 (inclusive), the resulting string is 
# "zxyxxe".
#  
# 
#  Example 3: 
# 
#  
# Input: word = "abcd", ch = "z"
# Output: "abcd"
# Explanation: "z" does not exist in word.
# You should not do any reverse operation, the resulting string is "abcd".
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= word.length <= 250 
#  word consists of lowercase English letters. 
#  ch is a lowercase English letter. 
#  
# 
#  Related Topics Two Pointers String 👍 1202 👎 34

import unittest


class ReversePrefixOfWord_Test(unittest.TestCase):

    def test_reversePrefixOfWord(self):
        test_data = [
            ("abcdefd", 'd', "dcbaefd"),
            ("xyxzxe", 'z', "zxyxxe"),
            ("abcd", 'z', "abcd"),
        ]
        for word, ch, expected in test_data:
            with self.subTest(data=word, ch=ch):
                self.assertEqual(expected, Solution().reversePrefix(word, ch))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def reversePrefix(self, word: str, ch: str) -> str:
        if ch in word:
            i = word.index(ch)
            return "".join(reversed(word[0:i + 1])) + word[i+1:]
        return word

# leetcode submit region end(Prohibit modification and deletion)
