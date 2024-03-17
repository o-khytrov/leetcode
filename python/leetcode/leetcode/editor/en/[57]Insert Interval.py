# You are given an array of non-overlapping intervals intervals where intervals[
# i] = [starti, endi] represent the start and the end of the iᵗʰ interval and 
# intervals is sorted in ascending order by starti. You are also given an interval 
# newInterval = [start, end] that represents the start and end of another interval. 
# 
#  Insert newInterval into intervals such that intervals is still sorted in 
# ascending order by starti and intervals still does not have any overlapping 
# intervals (merge overlapping intervals if necessary). 
# 
#  Return intervals after the insertion. 
# 
#  Note that you don't need to modify intervals in-place. You can make a new 
# array and return it. 
# 
#  
#  Example 1: 
# 
#  
# Input: intervals = [[1,3],[6,9]], newInterval = [2,5]
# Output: [[1,5],[6,9]]
#  
# 
#  Example 2: 
# 
#  
# Input: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
# Output: [[1,2],[3,10],[12,16]]
# Explanation: Because the new interval [4,8] overlaps with [3,5],[6,7],[8,10].
#  
# 
#  
#  Constraints: 
# 
#  
#  0 <= intervals.length <= 10⁴ 
#  intervals[i].length == 2 
#  0 <= starti <= endi <= 10⁵ 
#  intervals is sorted by starti in ascending order. 
#  newInterval.length == 2 
#  0 <= start <= end <= 10⁵ 
#  
# 
#  Related Topics Array 👍 9745 👎 737

import unittest
from typing import List


class InsertInterval_Test(unittest.TestCase):

    def test_insertInterval(self):
        test_data = [
            ([[1, 3], [6, 9]], [2, 5], [[1, 5], [6, 9]]),
            ([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4, 8], [[1, 2], [3, 10], [12, 16]]),
            ([[1, 5]], [2, 3], [[1, 5]]),
            ([[0, 5], [9, 12]], [7, 16], [[0, 5], [7, 16]]),
            ([[0, 7], [8, 8], [9, 11]], [0, 13], [[0, 13]])
        ]
        for intervals, new_interval, expected in test_data:
            with self.subTest(intervals=intervals, new_interval=new_interval):
                self.assertSequenceEqual(expected, Solution().insert(intervals, new_interval))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        if len(intervals) == 0:
            return [newInterval]
        if newInterval[0] < intervals[0][0] and newInterval[1] > intervals[-1][1]:
            return [newInterval]
        overlapping = []
        for index, interval in enumerate(intervals):
            start = interval[0]
            end = interval[1]
            if start <= newInterval[0] <= end or start <= newInterval[1] <= end or newInterval[0] <= start and \
                    newInterval[1] >= end:
                overlapping.append((index, interval))
            if index > 0 and newInterval[0] > intervals[index - 1][1] and newInterval[1] < start:
                intervals.insert(index, newInterval)
                return intervals
        result = []
        if overlapping:
            overlapping[0][1][0] = min(overlapping[0][1][0], newInterval[0])
            overlapping[-1][1][1] = max(overlapping[-1][1][1], newInterval[1])
            first_index = overlapping[0][0]
            last_index = overlapping[-1][0]
            new_interval = [overlapping[0][1][0], overlapping[-1][1][1]]
            result = [new_interval] + intervals[last_index + 1:]
            if first_index > 0:
                result = intervals[:first_index] + result
        else:
            if newInterval[0] > intervals[-1][1]:
                return intervals + [newInterval]
            elif newInterval[1] < intervals[0][0]:
                return [newInterval] + intervals
            elif newInterval[0] < intervals[-1][0] and newInterval[1] > intervals[-1][1]:
                intervals.pop()
                intervals.append(newInterval)
                return intervals

        return result

# leetcode submit region end(Prohibit modification and deletion)
