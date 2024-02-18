# You are given an integer n. There are n rooms numbered from 0 to n - 1. 
# 
#  You are given a 2D integer array meetings where meetings[i] = [starti, endi] 
# means that a meeting will be held during the half-closed time interval [starti, 
# endi). All the values of starti are unique. 
# 
#  Meetings are allocated to rooms in the following manner: 
# 
#  
#  Each meeting will take place in the unused room with the lowest number. 
#  If there are no available rooms, the meeting will be delayed until a room 
# becomes free. The delayed meeting should have the same duration as the original 
# meeting. 
#  When a room becomes unused, meetings that have an earlier original start 
# time should be given the room. 
#  
# 
#  Return the number of the room that held the most meetings. If there are 
# multiple rooms, return the room with the lowest number. 
# 
#  A half-closed interval [a, b) is the interval between a and b including a 
# and not including b. 
# 
#  
#  Example 1: 
# 
#  
# Input: n = 2, meetings = [[0,10],[1,5],[2,7],[3,4]]
# Output: 0
# Explanation:
# - At time 0, both rooms are not being used. The first meeting starts in room 0
# .
# - At time 1, only room 1 is not being used. The second meeting starts in room 
# 1.
# - At time 2, both rooms are being used. The third meeting is delayed.
# - At time 3, both rooms are being used. The fourth meeting is delayed.
# - At time 5, the meeting in room 1 finishes. The third meeting starts in room 
# 1 for the time period [5,10).
# - At time 10, the meetings in both rooms finish. The fourth meeting starts in 
# room 0 for the time period [10,11).
# Both rooms 0 and 1 held 2 meetings, so we return 0. 
#  
# 
#  Example 2: 
# 
#  
# Input: n = 3, meetings = [[1,20],[2,10],[3,5],[4,9],[6,8]]
# Output: 1
# Explanation:
# - At time 1, all three rooms are not being used. The first meeting starts in 
# room 0.
# - At time 2, rooms 1 and 2 are not being used. The second meeting starts in 
# room 1.
# - At time 3, only room 2 is not being used. The third meeting starts in room 2
# .
# - At time 4, all three rooms are being used. The fourth meeting is delayed.
# - At time 5, the meeting in room 2 finishes. The fourth meeting starts in 
# room 2 for the time period [5,10).
# - At time 6, all three rooms are being used. The fifth meeting is delayed.
# - At time 10, the meetings in rooms 1 and 2 finish. The fifth meeting starts 
# in room 1 for the time period [10,12).
# Room 0 held 1 meeting while rooms 1 and 2 each held 2 meetings, so we return 1
# . 
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= n <= 100 
#  1 <= meetings.length <= 10⁵ 
#  meetings[i].length == 2 
#  0 <= starti < endi <= 5 * 10⁵ 
#  All the values of starti are unique. 
#  
# 
#  Related Topics Array Hash Table Sorting Heap (Priority Queue) Simulation 👍 1
# 284 👎 79
import heapq
import unittest
from typing import List


class MeetingRoomsIii_Test(unittest.TestCase):

    def test_meetingRoomsIii(self):
        test_data = [
            (2, [[0, 10], [1, 5], [2, 7], [3, 4]], 0)
        ]
        for n, meetings, expected in test_data:
            with self.subTest(expected=expected):
                self.assertEqual(expected, Solution().mostBooked(n, meetings))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def mostBooked(self, n: int, meetings: List[List[int]]) -> int:
        meetings.sort()
        available = [i for i in range(n)]
        used = []  # (end time, room number)
        count = [0] * n
        for start, end in meetings:
            while used and start >= used[0][0]:
                _, room = heapq.heappop(used)  # free all rooms where meeting ended at sart time
                heapq.heappush(available, room)
            if not available:
                end_time, room = heapq.heappop(used)
                end = end_time + (end - start)
                heapq.heappush(available, room)
            room = heapq.heappop(available)
            heapq.heappush(used, (end, room))
            count[room] += 1
        return count.index(max(count))

# leetcode submit region end(Prohibit modification and deletion)
