# You are given an integer array score of size n, where score[i] is the score 
# of the iᵗʰ athlete in a competition. All the scores are guaranteed to be unique. 
# 
#  The athletes are placed based on their scores, where the 1ˢᵗ place athlete 
# has the highest score, the 2ⁿᵈ place athlete has the 2ⁿᵈ highest score, and so on.
#  The placement of each athlete determines their rank: 
# 
#  
#  The 1ˢᵗ place athlete's rank is "Gold Medal". 
#  The 2ⁿᵈ place athlete's rank is "Silver Medal". 
#  The 3ʳᵈ place athlete's rank is "Bronze Medal". 
#  For the 4ᵗʰ place to the nᵗʰ place athlete, their rank is their placement 
# number (i.e., the xᵗʰ place athlete's rank is "x"). 
#  
# 
#  Return an array answer of size n where answer[i] is the rank of the iᵗʰ 
# athlete. 
# 
#  
#  Example 1: 
# 
#  
# Input: score = [5,4,3,2,1]
# Output: ["Gold Medal","Silver Medal","Bronze Medal","4","5"]
# Explanation: The placements are [1ˢᵗ, 2ⁿᵈ, 3ʳᵈ, 4ᵗʰ, 5ᵗʰ]. 
# 
#  Example 2: 
# 
#  
# Input: score = [10,3,8,9,4]
# Output: ["Gold Medal","5","Bronze Medal","Silver Medal","4"]
# Explanation: The placements are [1ˢᵗ, 5ᵗʰ, 3ʳᵈ, 2ⁿᵈ, 4ᵗʰ].
# 
#  
# 
#  
#  Constraints: 
# 
#  
#  n == score.length 
#  1 <= n <= 10⁴ 
#  0 <= score[i] <= 10⁶ 
#  All the values in score are unique. 
#  
# 
#  Related Topics Array Sorting Heap (Priority Queue) 👍 1860 👎 117

import unittest
from typing import List


class RelativeRanks_Test(unittest.TestCase):

    def test_relativeRanks(self):
        test_data = [
            ([5, 4, 3, 2, 1], ["Gold Medal", "Silver Medal", "Bronze Medal", "4", "5"]),
            ([10, 3, 8, 9, 4], ["Gold Medal", "5", "Bronze Medal", "Silver Medal", "4"])
        ]
        for score, expected in test_data:
            with self.subTest(score=score, expected=expected):
                self.assertSequenceEqual(expected, Solution().findRelativeRanks(score))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findRelativeRanks(self, score: List[int]) -> List[str]:
        titles = {
            0: "Gold Medal",
            1: "Silver Medal",
            2: "Bronze Medal"
        }
        m = {}
        ans = [0] * len(score)
        scores_sorted = sorted(score, reverse=True)

        for i in range(len(score)):
            m[score[i]] = i

        for i, s in enumerate(scores_sorted):
            position = m[s]
            ans[position] = str(titles.get(i, i + 1))
        return ans

# leetcode submit region end(Prohibit modification and deletion)
