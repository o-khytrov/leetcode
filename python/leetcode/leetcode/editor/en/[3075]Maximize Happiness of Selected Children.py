# You are given an array happiness of length n, and a positive integer k. 
# 
#  There are n children standing in a queue, where the iᵗʰ child has happiness 
# value happiness[i]. You want to select k children from these n children in k 
# turns. 
# 
#  In each turn, when you select a child, the happiness value of all the 
# children that have not been selected till now decreases by 1. Note that the happiness 
# value cannot become negative and gets decremented only if it is positive. 
# 
#  Return the maximum sum of the happiness values of the selected children you 
# can achieve by selecting k children. 
# 
#  
#  Example 1: 
# 
#  
# Input: happiness = [1,2,3], k = 2
# Output: 4
# Explanation: We can pick 2 children in the following way:
# - Pick the child with the happiness value == 3. The happiness value of the 
# remaining children becomes [0,1].
# - Pick the child with the happiness value == 1. The happiness value of the 
# remaining child becomes [0]. Note that the happiness value cannot become less than 
# 0.
# The sum of the happiness values of the selected children is 3 + 1 = 4.
#  
# 
#  Example 2: 
# 
#  
# Input: happiness = [1,1,1,1], k = 2
# Output: 1
# Explanation: We can pick 2 children in the following way:
# - Pick any child with the happiness value == 1. The happiness value of the 
# remaining children becomes [0,0,0].
# - Pick the child with the happiness value == 0. The happiness value of the 
# remaining child becomes [0,0].
# The sum of the happiness values of the selected children is 1 + 0 = 1.
#  
# 
#  Example 3: 
# 
#  
# Input: happiness = [2,3,4,5], k = 1
# Output: 5
# Explanation: We can pick 1 child in the following way:
# - Pick the child with the happiness value == 5. The happiness value of the 
# remaining children becomes [1,2,3].
# The sum of the happiness values of the selected children is 5.
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n == happiness.length <= 2 * 10⁵ 
#  1 <= happiness[i] <= 10⁸ 
#  1 <= k <= n 
#  
# 
#  Related Topics Array Greedy Sorting 👍 247 👎 26

import unittest
from typing import List


class MaximizeHappinessOfSelectedChildren_Test(unittest.TestCase):

    def test_maximizeHappinessOfSelectedChildren(self):
        test_data = [
            ([1, 2, 3], 2, 4),
            ([1, 1, 1, 1], 2, 1),
            ([2, 3, 4, 5], 1, 5)
        ]
        for nums, target, expected in test_data:
            with self.subTest(nums=nums, target=target, expected=expected):
                self.assertEqual(expected, Solution().maximumHappinessSum(nums, target))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def maximumHappinessSum(self, happiness: List[int], k: int) -> int:
        happiness = sorted(happiness)
        r = 0
        ans = 0
        while happiness and r < k:
            ans += max(0, happiness.pop(-1) - r)
            r += 1
        return ans

# leetcode submit region end(Prohibit modification and deletion)
