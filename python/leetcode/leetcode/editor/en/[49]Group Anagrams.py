# Given an array of strings strs, group the anagrams together. You can return 
# the answer in any order. 
# 
#  An Anagram is a word or phrase formed by rearranging the letters of a 
# different word or phrase, typically using all the original letters exactly once. 
# 
#  
#  Example 1: 
#  Input: strs = ["eat","tea","tan","ate","nat","bat"]
# Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
#  
#  Example 2: 
#  Input: strs = [""]
# Output: [[""]]
#  
#  Example 3: 
#  Input: strs = ["a"]
# Output: [["a"]]
#  
#  
#  Constraints: 
# 
#  
#  1 <= strs.length <= 10⁴ 
#  0 <= strs[i].length <= 100 
#  strs[i] consists of lowercase English letters. 
#  
# 
#  Related Topics Array Hash Table String Sorting 👍 18290 👎 555
import json
import unittest
from typing import List


class GroupAnagrams_Test(unittest.TestCase):

    def test_groupAnagrams(self):
        test_data = [
            (["eat", "tea", "tan", "ate", "nat", "bat"], [["bat"], ["nat", "tan"], ["ate", "eat", "tea"]]),
            ([""], [[""]]),
            (["a"], [["a"]]),
        ]
        for strs, expected in test_data:
            with self.subTest(strs=strs, expected=expected):
                self.assertEqual(json.dumps(expected), json.dumps(Solution().groupAnagrams(strs)))
        pass


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        m = {}
        for s in strs:
            sor = str(sorted(s))
            m[sor] = m.get(sor, []) + [s]

        return list(m.values())

# leetcode submit region end(Prohibit modification and deletion)
