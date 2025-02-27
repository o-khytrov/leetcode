# A sequence x1, x2, ..., xn is Fibonacci-like if: 
# 
#  
#  n >= 3 
#  xi + xi+1 == xi+2 for all i + 2 <= n 
#  
# 
#  Given a strictly increasing array arr of positive integers forming a 
# sequence, return the length of the longest Fibonacci-like subsequence of arr. If one 
# does not exist, return 0. 
# 
#  A subsequence is derived from another sequence arr by deleting any number of 
# elements (including none) from arr, without changing the order of the remaining 
# elements. For example, [3, 5, 8] is a subsequence of [3, 4, 5, 6, 7, 8]. 
# 
#  
#  Example 1: 
# 
#  
# Input: arr = [1,2,3,4,5,6,7,8]
# Output: 5
# Explanation: The longest subsequence that is fibonacci-like: [1,2,3,5,8]. 
# 
#  Example 2: 
# 
#  
# Input: arr = [1,3,7,11,12,14,18]
# Output: 3
# Explanation: The longest subsequence that is fibonacci-like: [1,11,12], [3,11,
# 14] or [7,11,18]. 
# 
#  
#  Constraints: 
# 
#  
#  3 <= arr.length <= 1000 
#  1 <= arr[i] < arr[i + 1] <= 10⁹ 
#  
# 
#  Related Topics Array Hash Table Dynamic Programming 👍 2215 👎 84
from typing import List


# leetcode submit region begin(Prohibit modification and deletion)
class Solution:
    def lenLongestFibSubseq(self, arr: List[int]) -> int:
        num2ind = {}
        for i, n in enumerate(arr):
            num2ind[n] = i

        def dfs(start, target):
            res = 0
            if target == 0:
                for i in range(start, len(arr)):
                    for j in range(i + 1, len(arr)):
                        s = arr[i] + arr[j]
                        if s in num2ind:
                            res = max(res, dfs(num2ind[s], s + arr[j]) + 2)
            else:
                if target in num2ind:
                    return 1 + dfs(num2ind[target], target + arr[start])
                else:
                    return 1

            return res

        return dfs(0, 0)


result = Solution().lenLongestFibSubseq([1, 2, 3, 4, 5, 6, 7, 8])
print(result)

result = Solution().lenLongestFibSubseq([1, 3, 7, 11, 12, 14, 18])
print(result)

# leetcode submit region end(Prohibit modification and deletion)
