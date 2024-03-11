import unittest


class Tests(unittest.TestCase):

    def test_sort(self):
        test_data = [
            ("cba", "abcd", "cbad"),
            ("bcafg", "abcd", "bcad")

        ]
        for order, s, expected in test_data:
            with self.subTest(order=order, s=s):
                self.assertEqual(expected, Solution().customSortString(order, s))


class Solution(object):

    def customSortString(self, order, s):
        """
        :type order: str
        :type s: str
        :rtype: str
        """
        m = {}
        o = 0
        for n in order:
            m[n] = o
            o += 1
        for c in range(ord('a'), ord('z') + 1):
            if not chr(c) in m:
                m[chr(c)] = o
                o += 1
        s = "".join(sorted(s, key=lambda c: m.get(c, 0)))
        return s


if __name__ == '__main__':
    unittest.main()
