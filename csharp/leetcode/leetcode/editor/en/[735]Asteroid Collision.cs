/**
We are given an array asteroids of integers representing asteroids in a row.

 For each asteroid, the absolute value represents its size, and the sign
represents its direction (positive meaning right, negative meaning left). Each
asteroid moves at the same speed.

 Find out the state of the asteroids after all collisions. If two asteroids
meet, the smaller one will explode. If both are the same size, both will explode.
Two asteroids moving in the same direction will never meet.


 Example 1:


Input: asteroids = [5,10,-5]
Output: [5,10]
Explanation: The 10 and -5 collide resulting in 10. The 5 and 10 never collide.


 Example 2:


Input: asteroids = [8,-8]
Output: []
Explanation: The 8 and -8 collide exploding each other.


 Example 3:


Input: asteroids = [10,2,-5]
Output: [10]
Explanation: The 2 and -5 collide resulting in -5. The 10 and -5 collide
resulting in 10.



 Constraints:


 2 <= asteroids.length <= 10⁴
 -1000 <= asteroids[i] <= 1000
 asteroids[i] != 0


 Related Topics Array Stack Simulation 👍 7392 👎 882

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text.Json;
using Xunit;
using Xunit.Sdk;

namespace AsteroidCollision
{
    public class Tests
    {
        [Theory]
        [InlineData("[5,10,-5]", "[5,10]")]
        [InlineData("[10,2,-5]", "[10]")]
        [InlineData("[10,2,-11]", "[-11]")]
        [InlineData("[8,-8]", "[]")]
        [InlineData("[-2,-1,1,2]", "[-2,-1,1,2]")]
        [InlineData("[-2,-2,1,-2]", "[-2,-2,-2]")]
        public void AsteroidCollisionTest(string asteroidsJson, string expectedResultJson)
        {
            var asteroids = JsonSerializer.Deserialize<int[]>(asteroidsJson)
                            ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().AsteroidCollision(asteroids)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] AsteroidCollision(int[] asteroids)
        {
            var stack = new Stack<int>();
            for (var i = 0; i < asteroids.Length; i++)
            {
                var a = asteroids[i];
                if (stack.Count == 0)
                {
                    stack.Push(a);
                }
                else
                {
                    begin:
                    // moving in the same direction
                    if (stack.Peek() < 0 && a < 0)
                    {
                        stack.Push(a);
                    }

                    // moving in the same direction
                    if (stack.Peek() > 0 && a > 0)
                    {
                        stack.Push(a);
                    }

                    // moving in the same direction
                    if (stack.Peek() < 0 && a > 0)
                    {
                        stack.Push(a);
                    }

                    if (stack.Peek() > 0 && a < 0)
                    {
                        var sum = stack.Peek() + a;
                        if (sum == 0)
                        {
                            stack.Pop();
                        }

                        if (sum < 0)
                        {
                            stack.Pop();
                            if (stack.Count > 0)
                            {
                                goto begin;
                            }

                            stack.Push(a);
                            // do lop 
                        }
                    }
                }
            }

            return stack.Reverse().ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}