/**
Design a system that manages the reservation state of n seats that are numbered
from 1 to n.

 Implement the SeatManager class:


 SeatManager(int n) Initializes a SeatManager object that will manage n seats
numbered from 1 to n. All seats are initially available.
 int reserve() Fetches the smallest-numbered unreserved seat, reserves it, and
returns its number.
 void unreserve(int seatNumber) Unreserves the seat with the given seatNumber.



 Example 1:


Input
["SeatManager", "reserve", "reserve", "unreserve", "reserve", "reserve",
"reserve", "reserve", "unreserve"]
[[5], [], [], [2], [], [], [], [], [5]]
Output
[null, 1, 2, null, 2, 3, 4, 5, null]

Explanation
SeatManager seatManager = new SeatManager(5); // Initializes a SeatManager with
5 seats.
seatManager.reserve();    // All seats are available, so return the lowest
numbered seat, which is 1.
seatManager.reserve();    // The available seats are [2,3,4,5], so return the
lowest of them, which is 2.
seatManager.unreserve(2); // Unreserve seat 2, so now the available seats are [2
,3,4,5].
seatManager.reserve();    // The available seats are [2,3,4,5], so return the
lowest of them, which is 2.
seatManager.reserve();    // The available seats are [3,4,5], so return the
lowest of them, which is 3.
seatManager.reserve();    // The available seats are [4,5], so return the
lowest of them, which is 4.
seatManager.reserve();    // The only available seat is seat 5, so return 5.
seatManager.unreserve(5); // Unreserve seat 5, so now the available seats are [5
].



 Constraints:


 1 <= n <= 10⁵
 1 <= seatNumber <= n
 For each call to reserve, it is guaranteed that there will be at least one
unreserved seat.
 For each call to unreserve, it is guaranteed that seatNumber will be reserved.

 At most 10⁵ calls in total will be made to reserve and unreserve.


 Related Topics Design Heap (Priority Queue) 👍 1278 👎 81

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace SeatReservationManager
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[\"SeatManager\", \"reserve\", \"reserve\", \"unreserve\", \"reserve\", \"reserve\", \"reserve\", \"reserve\", \"unreserve\"]",
            "[[5], [], [], [2], [], [], [], [], [5]]", "[null, 1, 2, null, 2, 3, 4, 5, null]")]
        public void SeatReservationManagerTest(string methodsJson, string argumentsJson, string outputJson)
        {
            var methods = JsonSerializer.Deserialize<string[]>(methodsJson)
                          ?? throw new ArgumentException("Invalid json");
            var arguments = JsonSerializer.Deserialize<int[][]>(argumentsJson) ??
                            throw new ArgumentException("Invalid json");

            var output = JsonSerializer.Deserialize<int?[]>(outputJson) ??
                         throw new ArgumentException("Invalid json");

            SeatManager seatManager = null;
            for (int i = 0; i < methods.Length; i++)
            {
                var method = methods[i];
                if (method == "SeatManager")
                {
                    seatManager = new SeatManager(arguments[i][0]);
                }

                if (method == "reserve")
                {
                    var result = seatManager.Reserve();
                    Assert.Equal(output[i].GetValueOrDefault(), result);
                }

                if (method == "unreserve")
                {
                    seatManager.Unreserve(arguments[i][0]);
                }
            }
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class SeatManager
    {
        // private Dictionary<int, bool> _seats = new();
        private readonly PriorityQueue<int, int> _seats = new();

        public SeatManager(int n)
        {
            for (var i = 1; i <= n; i++)
            {
                _seats.Enqueue(i, i);
            }
        }

        public int Reserve()
        {
            return _seats.Dequeue();
        }

        public void Unreserve(int seatNumber)
        {
            _seats.Enqueue(seatNumber, seatNumber);
        }
    }

    /**
     * Your SeatManager object will be instantiated and called as such:
     * SeatManager obj = new SeatManager(n);
     * int param_1 = obj.Reserve();
     * obj.Unreserve(seatNumber);
     */
//leetcode submit region end(Prohibit modification and deletion)
}