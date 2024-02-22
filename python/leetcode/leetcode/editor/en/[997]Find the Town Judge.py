# In a town, there are n people labeled from 1 to n. There is a rumor that one 
# of these people is secretly the town judge. 
# 
#  If the town judge exists, then: 
# 
#  
#  The town judge trusts nobody. 
#  Everybody (except for the town judge) trusts the town judge. 
#  There is exactly one person that satisfies properties 1 and 2. 
#  
# 
#  You are given an array trust where trust[i] = [ai, bi] representing that the 
# person labeled ai trusts the person labeled bi. If a trust relationship does 
# not exist in trust array, then such a trust relationship does not exist. 
# 
#  Return the label of the town judge if the town judge exists and can be 
# identified, or return -1 otherwise. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 2, trust = [[1,2]]
# Output: 2
#  
# 
#  Example 2: 
# 
#  
# Input: n = 3, trust = [[1,3],[2,3]]
# Output: 3
#  
# 
#  Example 3: 
# 
#  
# Input: n = 3, trust = [[1,3],[2,3],[3,1]]
# Output: -1
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 1000 
#  0 <= trust.length <= 10⁴ 
#  trust[i].length == 2 
#  All the pairs of trust are unique. 
#  ai != bi 
#  1 <= ai, bi <= n 
#  
# 
#  Related Topics Array Hash Table Graph 👍 6355 👎 549

import unittest
from typing import List


class FindTheTownJudge_Test(unittest.TestCase):

    def test_findTheTownJudge(self):
        test_data = [
            (2, [[1, 2]], 2),
            (3, [[1, 3], [2, 3]], 3),
            (3, [[1, 3], [2, 3], [3, 1]], -1)
        ]
        for n, trust, expected in test_data:
            with self.subTest(n=n, trust=trust, expected=expected):
                self.assertEqual(expected, Solution().findJudge(n, trust))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def findJudge(self, n: int, trust: List[List[int]]) -> int:
        trust_scores = {i: 0 for i in range(1, n + 1)}
        trusted_people = {i: 0 for i in range(1, n + 1)}
        for t in trust:
            source = t[0]
            target = t[1]
            trust_scores[target] = trust_scores.get(target, 0) + 1
            trusted_people[source] = trusted_people.get(source, 0) + 1
        for person, score in trust_scores.items():
            if score == n - 1 and trusted_people[person] == 0:
                return person
        return -1

# leetcode submit region end(Prohibit modification and deletion)
