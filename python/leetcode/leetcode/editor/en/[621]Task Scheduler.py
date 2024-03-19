# You are given an array of CPU tasks, each represented by letters A to Z, and 
# a cooling time, n. Each cycle or interval allows the completion of one task. 
# Tasks can be completed in any order, but there's a constraint: identical tasks must 
# be separated by at least n intervals due to cooling time. 
# 
#  Return the minimum number of intervals required to complete all tasks. 
# 
#  
#  Example 1: 
# 
#  
#  Input: tasks = ["A","A","A","B","B","B"], n = 2 
#  
# 
#  Output: 8 
# 
#  Explanation: A possible sequence is: A -> B -> idle -> A -> B -> idle -> A ->
#  B. 
# 
#  After completing task A, you must wait two cycles before doing A again. The 
# same applies to task B. In the 3ʳᵈ interval, neither A nor B can be done, so you 
# idle. By the 4ᵗʰ cycle, you can do A again as 2 intervals have passed. 
# 
#  Example 2: 
# 
#  
#  Input: tasks = ["A","C","A","B","D","B"], n = 1 
#  
# 
#  Output: 6 
# 
#  Explanation: A possible sequence is: A -> B -> C -> D -> A -> B. 
# 
#  With a cooling interval of 1, you can repeat a task after just one other 
# task. 
# 
#  Example 3: 
# 
#  
#  Input: tasks = ["A","A","A", "B","B","B"], n = 3 
#  
# 
#  Output: 10 
# 
#  Explanation: A possible sequence is: A -> B -> idle -> idle -> A -> B -> 
# idle -> idle -> A -> B. 
# 
#  There are only two types of tasks, A and B, which need to be separated by 3 
# intervals. This leads to idling twice between repetitions of these tasks. 
# 
#  
#  Constraints: 
# 
#  
#  1 <= tasks.length <= 10⁴ 
#  tasks[i] is an uppercase English letter. 
#  0 <= n <= 100 
#  
# 
#  Related Topics Array Hash Table Greedy Sorting Heap (Priority Queue) 
# Counting 👍 9642 👎 1983

import unittest
from typing import List


class TaskScheduler_Test(unittest.TestCase):

    def test_taskScheduler(self):
        test_data = [
            (["A", "A", "A", "B", "B", "B"], 2, 8),
            (["A", "C", "A", "B", "D", "B"], 1, 6),
            (["A", "A", "A", "B", "B", "B"], 3, 10),
            (["A", "A", "A", "B", "B", "B"], 50, 104),
            (["A", "A", "A", "A", "A", "A", "B", "C", "D", "E", "F", "G"], 1, 12)
        ]
        for tasks, n, expected in test_data:
            with self.subTest(n=n, expected=expected):
                self.assertEqual(expected, Solution().leastInterval(tasks, n))


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        # Counter array to store the frequency of each task
        counter = [0] * 26
        max_val = 0
        max_count = 0

        # Traverse through tasks to calculate task frequencies
        for task in tasks:
            key = ord(task) - ord('A')
            counter[key] += 1
            if max_val == counter[key]:
                max_count += 1
            elif max_val < counter[key]:
                max_val = counter[key]
                max_count = 1

        # Calculate idle slots, available tasks, and idles needed
        part_count = max_val - 1
        part_length = n - (max_count - 1)
        empty_slots = part_count * part_length
        available_tasks = len(tasks) - max_val * max_count
        idles = max(0, empty_slots - available_tasks)

        # Return the total time required
        return len(tasks) + idles

# leetcode submit region end(Prohibit modification and deletion)
