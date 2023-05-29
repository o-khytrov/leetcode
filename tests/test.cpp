#include <gtest/gtest.h>
#include <leetcode/leetcode.h>

TEST(MultiplyTests, strStrTest) {
    const auto expected = 5;
    char *haystack = "mississippi";
    char *needle = "ssip";
    const auto actual = strStr(haystack, needle);
    ASSERT_EQ(expected, actual);
}

TEST(lengthOfLastWord, HelloWorld) {

    const auto actual = lengthOfLastWord("Hello World");
    ASSERT_EQ(5, actual);
}

TEST(lengthOfLastWord, FlyMeToTheMoon) {

    const auto actual = lengthOfLastWord("   fly me   to   the moon  ");
    ASSERT_EQ(4, actual);
}

TEST(longestCommonPrefix, flower) {

    char *strs[] = {strdup("flower"), strdup("flow"), ("flight")};  // Example input strings
    int strsSize = sizeof(strs) / sizeof(strs[0]);   // Calculate the number of strings

    char *result = longestCommonPrefix(strs, strsSize);  // Call the function with the parameters

    ASSERT_STREQ("fl", result);
}


int main(int argc, char **argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}