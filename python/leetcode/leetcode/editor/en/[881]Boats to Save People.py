# You are given an array people where people[i] is the weight of the iᵗʰ person,
#  and an infinite number of boats where each boat can carry a maximum weight of 
# limit. Each boat carries at most two people at the same time, provided the sum 
# of the weight of those people is at most limit. 
# 
#  Return the minimum number of boats to carry every given person. 
# 
#  
#  Example 1: 
# 
#  
# Input: people = [1,2], limit = 3
# Output: 1
# Explanation: 1 boat (1, 2)
#  
# 
#  Example 2: 
# 
#  
# Input: people = [3,2,2,1], limit = 3
# Output: 3
# Explanation: 3 boats (1, 2), (2) and (3)
#  
# 
#  Example 3: 
# 
#  
# Input: people = [3,5,3,4], limit = 5
# Output: 4
# Explanation: 4 boats (3), (3), (4), (5)
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= people.length <= 5 * 10⁴ 
#  1 <= people[i] <= limit <= 3 * 10⁴ 
#  
# 
#  Related Topics Array Two Pointers Greedy Sorting 👍 5980 👎 144

import unittest
from typing import List


class BoatsToSavePeople_Test(unittest.TestCase):

    def test_boatsToSavePeople(self):
        test_data = [
            ([1, 2], 3, 1),
            ([3, 2, 2, 1], 3, 3),
            ([3, 5, 3, 4], 5, 4),
            ([2, 49, 10, 7, 11, 41, 47, 2, 22, 6, 13, 12, 33, 18, 10, 26, 2, 6, 50, 10], 50, 11)
        ]
        for people, limit, expected in test_data:
            with self.subTest(people=people, limit=limit, expected=expected):
                self.assertEqual(expected, Solution().numRescueBoats(people, limit))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def numRescueBoats(self, people: List[int], limit: int) -> int:

        people.sort()
        boats = 0
        while people:
            group = people.pop(-1)

            while group < limit and people and people[0] + group <= limit:
                group += people.pop(0)
                break
            boats += 1

        return boats

# leetcode submit region end(Prohibit modification and deletion)
