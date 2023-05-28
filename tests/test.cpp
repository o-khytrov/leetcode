#include <gtest/gtest.h>
#include <leetcode/leetcode.h>

TEST(MultiplyTests, strStrTest) {
    const auto expected = 5;
    char *haystack = "mississippi";
    char *needle = "ssip";
    const auto actual = strStr(haystack, needle);
    ASSERT_EQ(expected, actual);
}


int main(int argc, char **argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}