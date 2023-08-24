/**
Given an array of integers nums which is sorted in ascending order, and an 
integer target, write a function to search target in nums. If target exists, then 
return its index. Otherwise, return -1. 

 You must write an algorithm with O(log n) runtime complexity. 

 
 Example 1: 

 
Input: nums = [-1,0,3,5,9,12], target = 9
Output: 4
Explanation: 9 exists in nums and its index is 4
 

 Example 2: 

 
Input: nums = [-1,0,3,5,9,12], target = 2
Output: -1
Explanation: 2 does not exist in nums so return -1
 

 
 Constraints: 

 
 1 <= nums.length <= 10⁴ 
 -10⁴ < nums[i], target < 10⁴ 
 All the integers in nums are unique. 
 nums is sorted in ascending order. 
 

 Related Topics Array Binary Search 👍 10528 👎 210

*/

namespace BinarySearch
{
//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int Search(int[] nums, int target)
        {
            var l = 0;
            var r = nums.Length - 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }

                if (nums[mid] > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return -1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}