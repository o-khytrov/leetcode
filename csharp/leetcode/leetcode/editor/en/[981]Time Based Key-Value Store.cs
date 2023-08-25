/**
Design a time-based key-value data structure that can store multiple values for 
the same key at different time stamps and retrieve the key's value at a certain 
timestamp. 

 Implement the TimeMap class: 

 
 TimeMap() Initializes the object of the data structure. 
 void set(String key, String value, int timestamp) Stores the key key with the 
value value at the given time timestamp. 
 String get(String key, int timestamp) Returns a value such that set was called 
previously, with timestamp_prev <= timestamp. If there are multiple such values,
 it returns the value associated with the largest timestamp_prev. If there are 
no values, it returns "". 
 

 
 Example 1: 

 
Input
["TimeMap", "set", "get", "get", "set", "get", "get"]
[[], ["foo", "bar", 1], ["foo", 1], ["foo", 3], ["foo", "bar2", 4], ["foo", 4], 
["foo", 5]]
Output
[null, null, "bar", "bar", null, "bar2", "bar2"]

Explanation
TimeMap timeMap = new TimeMap();
timeMap.set("foo", "bar", 1);  // store the key "foo" and value "bar" along 
with timestamp = 1.
timeMap.get("foo", 1);         // return "bar"
timeMap.get("foo", 3);         // return "bar", since there is no value 
corresponding to foo at timestamp 3 and timestamp 2, then the only value is at 
timestamp 1 is "bar".
timeMap.set("foo", "bar2", 4); // store the key "foo" and value "bar2" along 
with timestamp = 4.
timeMap.get("foo", 4);         // return "bar2"
timeMap.get("foo", 5);         // return "bar2"
 

 
 Constraints: 

 
 1 <= key.length, value.length <= 100 
 key and value consist of lowercase English letters and digits. 
 1 <= timestamp <= 10⁷ 
 All the timestamps timestamp of set are strictly increasing. 
 At most 2 * 10⁵ calls will be made to set and get. 
 

 Related Topics Hash Table String Binary Search Design 👍 4337 👎 424

*/


using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace TimeBasedKeyValueStore
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"TimeMap\", \"set\", \"get\", \"get\", \"set\", \"get\", \"get\"]",
            "[[], [\"foo\", \"bar\", 1], [\"foo\", 1], [\"foo\", 3], [\"foo\", \"bar2\", 4], [\"foo\", 4], [\"foo\", 5]]",
            "[null, null, \"bar\", \"bar\", null, \"bar2\", \"bar2\"]")]
        [InlineData("[\"TimeMap\",\"set\",\"set\",\"get\",\"get\",\"get\",\"get\",\"get\"]"
            , "[[],[\"love\",\"high\",10],[\"love\",\"low\",20],[\"love\",5],[\"love\",10],[\"love\",15],[\"love\",20],[\"love\",25]]"
            , "[null,null,null,\"\",\"high\",\"high\",\"low\",\"low\"]")]
        [InlineData("[\"TimeMap\",\"set\",\"set\",\"get\",\"set\",\"get\",\"get\"]"
            ,"[[],[\"a\",\"bar\",1],[\"x\",\"b\",3],[\"b\",3],[\"foo\",\"bar2\",4],[\"foo\",4],[\"foo\",5]]"
            ,"[null,null,null,null,null,\"bar2\",\"bar2\"]")]
        public void TimeMapTest(string callsJson, string parametersJson, string outputJson)
        {
            var commands = JsonSerializer.Deserialize<string[]>(callsJson) ?? throw new ArgumentException();
            var parameters = JsonSerializer.Deserialize<List<List<JsonElement>>>(parametersJson) ??
                             throw new ArgumentException();
            var expectedOutputs = JsonSerializer.Deserialize<List<string>>(outputJson) ?? throw new ArgumentException();
            TimeMap timeMap = null;
            for (var i = 0; i < commands.Length; i++)
            {
                var command = commands[i];
                var parameter = parameters[i];
                var expectedOutput = expectedOutputs[i];
                if (command == "TimeMap")
                {
                    timeMap = new TimeMap();
                }

                if (command == "set")
                {
                    timeMap.Set(parameter[0].GetString(), parameter[1].GetString(), parameter[2].GetInt32());
                }

                if (command == "get")
                {
                    var result = timeMap.Get(parameter[0].GetString(), parameter[1].GetInt32());
                    Assert.Equal(expectedOutput, result);
                }
            }
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class TimeMap
    {
        private Dictionary<string, List<(int, string)>> _map;

        public TimeMap()
        {
            _map = new();
        }

        public void Set(string key, string value, int timestamp)
        {
            if (_map.ContainsKey(key))
            {
                _map[key].Add((timestamp, value));
            }
            else
            {
                _map.Add(key, new List<(int, string)>()
                {
                    (timestamp, value)
                });
            }
        }

        public string Get(string key, int timestamp)
        {
            if (!_map.ContainsKey(key))
            {
                return "";
            }

            var keys = _map[key];
            var l = 0;
            var r = keys.Count - 1;

            if (keys[0].Item1 > timestamp)
            {
                return "";
            }

            var maxTimeStampPrevIndex = -1;
            var maxTimeStampPev = -1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var timestampPrev = keys[mid].Item1;
                if (timestampPrev == timestamp)
                {
                    return keys[mid].Item2;
                }

                if (timestampPrev > timestamp)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                    if (timestampPrev > maxTimeStampPev)
                    {
                        maxTimeStampPev = timestampPrev;
                        maxTimeStampPrevIndex = mid;
                    }
                }
            }

            return maxTimeStampPrevIndex >= 0 ? keys[maxTimeStampPrevIndex].Item2 : "";
        }
    }

    /**
     * Your TimeMap object will be instantiated and called as such:
     * TimeMap obj = new TimeMap();
     * obj.Set(key,value,timestamp);
     * string param_2 = obj.Get(key,timestamp);
     */
//leetcode submit region end(Prohibit modification and deletion)
}