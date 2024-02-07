# Given a string s, sort it in decreasing order based on the frequency of the 
# characters. The frequency of a character is the number of times it appears in the 
# string. 
# 
#  Return the sorted string. If there are multiple answers, return any of them. 
# 
# 
#  
#  Example 1: 
# 
#  
# Input: s = "tree"
# Output: "eert"
# Explanation: 'e' appears twice while 'r' and 't' both appear once.
# So 'e' must appear before both 'r' and 't'. Therefore "eetr" is also a valid 
# answer.
#  
# 
#  Example 2: 
# 
#  
# Input: s = "cccaaa"
# Output: "aaaccc"
# Explanation: Both 'c' and 'a' appear three times, so both "cccaaa" and 
# "aaaccc" are valid answers.
# Note that "cacaca" is incorrect, as the same characters must be together.
#  
# 
#  Example 3: 
# 
#  
# Input: s = "Aabb"
# Output: "bbAa"
# Explanation: "bbaA" is also a valid answer, but "Aabb" is incorrect.
# Note that 'A' and 'a' are treated as two different characters.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= s.length <= 5 * 10⁵ 
#  s consists of uppercase and lowercase English letters and digits. 
#  
# 
#  Related Topics Hash Table String Sorting Heap (Priority Queue) Bucket Sort 
# Counting 👍 7702 👎 256

import unittest


class SortCharactersByFrequency_Test(unittest.TestCase):

    def test_sortCharactersByFrequency(self):
        test_data = [
            ("tree", "eert"),
            ("cccaaa", "aaaccc"),
        ]
        for s, expected in test_data:
            with self.subTest(s=s, expected=expected):
                self.assertEqual(expected, Solution().frequencySort(s))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def frequencySort(self, s: str) -> str:
        char_count_map = {}
        for c in s:
            char_count_map[c] = char_count_map.get(c, 0) + 1
        map_sorted = sorted(char_count_map.items(), key=lambda item: (-item[1], item[0]))
        ans = ""
        for char_count in map_sorted:
            for i in range(char_count[1]):
                ans += char_count[0]
        return ans

# leetcode submit region end(Prohibit modification and deletion)
