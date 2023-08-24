/**
We are playing the Guess Game. The game is as follows: 

 I pick a number from 1 to n. You have to guess which number I picked. 

 Every time you guess wrong, I will tell you whether the number I picked is 
higher or lower than your guess. 

 You call a pre-defined API int guess(int num), which returns three possible 
results: 

 
 -1: Your guess is higher than the number I picked (i.e. num > pick). 
 1: Your guess is lower than the number I picked (i.e. num < pick). 
 0: your guess is equal to the number I picked (i.e. num == pick). 
 

 Return the number that I picked. 

 
 Example 1: 

 
Input: n = 10, pick = 6
Output: 6
 

 Example 2: 

 
Input: n = 1, pick = 1
Output: 1
 

 Example 3: 

 
Input: n = 2, pick = 1
Output: 1
 

 
 Constraints: 

 
 1 <= n <= 2³¹ - 1 
 1 <= pick <= n 
 

 Related Topics Binary Search Interactive 👍 3282 👎 417

*/

using Xunit;

namespace GuessNumberHigherOrLower
{
    public class Tests
    {
        [Theory]
        [InlineData(10, 6)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        public void GuessNumberHigherOrLowerTest(int n, int pick)
        {
            var sut = new Solution
            {
                Number = pick
            };
            Assert.Equal(pick, sut.GuessNumber(n));
        }
    }

    public class GuessGame
    {
        public int Number { get; set; }

        protected int guess(int num)
        {
            if (num == Number)
            {
                return 0;
            }

            return num > Number ? -1 : 1;
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    /** 
 * Forward declaration of guess API.
 * @param  num   your guess
 * @return 	     -1 if num is higher than the picked number
 *			      1 if num is lower than the picked number
 *               otherwise return 0
 * int guess(int num);
 */
    public class Solution : GuessGame
    {
        public int GuessNumber(int n)
        {
            var l = 0;
            var r = n;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var guess = this.guess(mid);
                if (guess == 0)
                {
                    return mid;
                }

                if (guess == -1)
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