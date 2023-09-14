/**
A password is said to be strong if it satisfies all the following criteria:


 It has at least 8 characters.
 It contains at least one lowercase letter.
 It contains at least one uppercase letter.
 It contains at least one digit.
 It contains at least one special character. The special characters are the
characters in the following string: "!@#$%^&*()-+".
 It does not contain 2 of the same character in adjacent positions (i.e., "aab"
violates this condition, but "aba" does not).


 Given a string password, return true if it is a strong password. Otherwise,
return false.


 Example 1:


Input: password = "IloveLe3tcode!"
Output: true
Explanation: The password meets all the requirements. Therefore, we return true.



 Example 2:


Input: password = "Me+You--IsMyDream"
Output: false
Explanation: The password does not contain a digit and also contains 2 of the
same character in adjacent positions. Therefore, we return false.


 Example 3:


Input: password = "1aB!"
Output: false
Explanation: The password does not meet the length requirement. Therefore, we
return false.


 Constraints:


 1 <= password.length <= 100
 password consists of letters, digits, and special characters: "!@#$%^&*()-+".


 Related Topics String 👍 302 👎 36

*/

using System.Collections.Generic;
using Xunit;

namespace StrongPasswordCheckerII
{
    public class Tests
    {
        [Theory]
        [InlineData("Me+You--IsMyDream", false)]
        [InlineData("IloveLe3tcode!", true)]
        [InlineData("1aB!", false)]
        [InlineData("ziyS5FrPQhoQ5oEWRpHW2MjI7sGfcMJdcsjQnIyRbdCilvFaQN07jQtAkOklbjFrU5KcHzw4EvJ41Yz2Ykyd", false)]
        public void StrongPasswordCheckerIITest(string password, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().StrongPasswordCheckerII(password));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static HashSet<char> _special = new()
            { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+', '-' };

        public bool StrongPasswordCheckerII(string password)
        {
            var length = password.Length;
            if (length < 8)
            {
                return false;
            }

            var loweLetters = 0;
            var upperLetters = 0;
            var digits = 0;
            var special = 0;

            char prev = password[0];
            for (int i = 0; i < length; i++)
            {
                var c = password[i];
                if (char.IsUpper(c))
                {
                    upperLetters++;
                }

                if (char.IsLower(c))
                {
                    loweLetters++;
                }

                if (char.IsDigit(c))
                {
                    digits++;
                }

                if (_special.Contains(c))
                {
                    special++;
                }

                if (i > 0 && c == prev)
                {
                    return false;
                }

                prev = c;
            }

            return loweLetters >= 1 && upperLetters >= 1 && digits >= 1 && special >= 1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}