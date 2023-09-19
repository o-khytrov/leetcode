/**
You are given a phone number as a string number. number consists of digits,
spaces ' ', and/or dashes '-'.

 You would like to reformat the phone number in a certain manner. Firstly,
remove all spaces and dashes. Then, group the digits from left to right into blocks
of length 3 until there are 4 or fewer digits. The final digits are then grouped
as follows:


 2 digits: A single block of length 2.
 3 digits: A single block of length 3.
 4 digits: Two blocks of length 2 each.


 The blocks are then joined by dashes. Notice that the reformatting process
should never produce any blocks of length 1 and produce at most two blocks of
length 2.

 Return the phone number after formatting.


 Example 1:


Input: number = "1-23-45 6"
Output: "123-456"
Explanation: The digits are "123456".
Step 1: There are more than 4 digits, so group the next 3 digits. The 1st block
is "123".
Step 2: There are 3 digits remaining, so put them in a single block of length 3.
 The 2nd block is "456".
Joining the blocks gives "123-456".


 Example 2:


Input: number = "123 4-567"
Output: "123-45-67"
Explanation: The digits are "1234567".
Step 1: There are more than 4 digits, so group the next 3 digits. The 1st block
is "123".
Step 2: There are 4 digits left, so split them into two blocks of length 2. The
blocks are "45" and "67".
Joining the blocks gives "123-45-67".


 Example 3:


Input: number = "123 4-5678"
Output: "123-456-78"
Explanation: The digits are "12345678".
Step 1: The 1st block is "123".
Step 2: The 2nd block is "456".
Step 3: There are 2 digits left, so put them in a single block of length 2. The
3rd block is "78".
Joining the blocks gives "123-456-78".



 Constraints:


 2 <= number.length <= 100
 number consists of digits and the characters '-' and ' '.
 There are at least two digits in number.


 Related Topics String 👍 312 👎 192

*/

using System.Linq;
using System.Text;
using Xunit;

namespace ReformatPhoneNumber
{
    public class Tests
    {
        [Theory]
        [InlineData("1-23-45 6", "123-456")]
        [InlineData("123 4-567", "123-45-67")]
        [InlineData("12", "12")]
        [InlineData("9964-", "99-64")]
        public void ReformatPhoneNumberTest(string number, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().ReformatNumber(number));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string ReformatNumber(string number)
        {
            var digits = number.Where(char.IsDigit).ToArray();
            if (digits.Length <= 3)
            {
                return new string(digits);
            }

            var sb = new StringBuilder();
            var count = 0;

            var length = digits.Length;
            var mod = digits.Length % 3;
            var lastDigits = 0;
            if (mod == 1)
            {
                lastDigits = 4;
            }

            if (mod == 2)
            {
                lastDigits = 2;
            }

            length = digits.Length - lastDigits;
            for (var i = 0; i < length; i++)
            {
                sb.Append(digits[i]);
                if (i < length - 1 && (i + 1) % 3 == 0)
                {
                    sb.Append('-');
                }
            }

            if (lastDigits > 0)
            {
                if (length > 0)
                {
                    sb.Append('-');
                }

                if (lastDigits == 2)
                {
                    sb.Append(digits[^2]);
                    sb.Append(digits[^1]);
                }

                if (lastDigits == 4)
                {
                    sb.Append(digits[^4]);
                    sb.Append(digits[^3]);
                    sb.Append('-');
                    sb.Append(digits[^2]);
                    sb.Append(digits[^1]);
                }
            }

            return sb.ToString();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}