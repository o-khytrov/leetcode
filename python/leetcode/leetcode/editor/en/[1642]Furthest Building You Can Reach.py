# You are given an integer array heights representing the heights of buildings, 
# some bricks, and some ladders. 
# 
#  You start your journey from building 0 and move to the next building by 
# possibly using bricks or ladders. 
# 
#  While moving from building i to building i+1 (0-indexed), 
# 
#  
#  If the current building's height is greater than or equal to the next 
# building's height, you do not need a ladder or bricks. 
#  If the current building's height is less than the next building's height, 
# you can either use one ladder or (h[i+1] - h[i]) bricks. 
#  
# 
#  Return the furthest building index (0-indexed) you can reach if you use the 
# given ladders and bricks optimally. 
# 
#  
#  Example 1: 
#  
#  
# Input: heights = [4,2,7,6,9,14,12], bricks = 5, ladders = 1
# Output: 4
# Explanation: Starting at building 0, you can follow these steps:
# - Go to building 1 without using ladders nor bricks since 4 >= 2.
# - Go to building 2 using 5 bricks. You must use either bricks or ladders 
# because 2 < 7.
# - Go to building 3 without using ladders nor bricks since 7 >= 6.
# - Go to building 4 using your only ladder. You must use either bricks or 
# ladders because 6 < 9.
# It is impossible to go beyond building 4 because you do not have any more 
# bricks or ladders.
#  
# 
#  Example 2: 
# 
#  
# Input: heights = [4,12,2,7,3,18,20,3,19], bricks = 10, ladders = 2
# Output: 7
#  
# 
#  Example 3: 
# 
#  
# Input: heights = [14,3,19,3], bricks = 17, ladders = 0
# Output: 3
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= heights.length <= 10⁵ 
#  1 <= heights[i] <= 10⁶ 
#  0 <= bricks <= 10⁹ 
#  0 <= ladders <= heights.length 
#  
# 
#  Related Topics Array Greedy Heap (Priority Queue) 👍 4894 👎 101
import heapq
import unittest
from typing import List


class FurthestBuildingYouCanReach_Test(unittest.TestCase):

    def test_furthestBuildingYouCanReach(self):
        test_data = [
            ([4, 2, 7, 6, 9, 14, 12], 5, 1, 4),
            ([14, 3, 19, 3], 17, 0, 3),
            ([14, 3, 19, 3], 17, 0, 3),
            ([1, 5, 1, 2, 3, 4, 10000], 4, 1, 5)
        ]
        for heights, bricks, ladders, expect in test_data:
            with self.subTest(heights=heights, bricks=bricks, ladders=ladders, expect=expect):
                self.assertEqual(expect, Solution().furthestBuilding(heights, bricks, ladders))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def furthestBuilding(self, heights: List[int], bricks: int, ladders: int) -> int:
        heap = []
        for i in range(len(heights) - 1):
            diff = heights[i + 1] - heights[i]
            if diff <= 0:
                continue

            bricks -= diff
            heapq.heappush(heap, -diff)

            if bricks < 0:
                if ladders == 0:
                    return i
                ladders -= 1
                bricks += -heapq.heappop(heap)

        return len(heights) - 1

# leetcode submit region end(Prohibit modification and deletion)
