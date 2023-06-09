#include <gtest/gtest.h>
#include <leetcode/leetcode.h>
#include <stdlib.h>
#include <stdlib.h>

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

TEST(FindPivotIndex, Case1) {

    int nums[] = {1, 7, 3, 6, 5, 6};
    int size = (sizeof(nums) / sizeof(nums[0]));
    int result = pivotIndex(nums, size);

    ASSERT_EQ(3, result);
}

TEST(removeElement, Case1) {

    int nums[] = {3, 2, 2, 3};
    int size = (sizeof(nums) / sizeof(nums[0]));
    int result = removeElement(nums, size, 3);
    int expected[] = {2, 2};
    ASSERT_EQ(2, result);
    for (int i = 0; i < result; ++i) {
        ASSERT_EQ(expected[i], nums[i]);
    }
}

TEST(removeElement, Case2) {

    int nums[] = {0, 1, 2, 2, 3, 0, 4, 2};
    int size = (sizeof(nums) / sizeof(nums[0]));
    int result = removeElement(nums, size, 2);
    int expected[] = {0, 1, 4, 0, 3};
    ASSERT_EQ(5, result);
    for (int i = 0; i < result; ++i) {
        ASSERT_EQ(expected[i], nums[i]);
    }

}
/*
TEST(numUniqueEmails, Case1) {

    char *strs[] = {"test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com",
                    "testemail+david@lee.tcode.com"};  // Example input strings
    int strsSize = sizeof(strs) / sizeof(strs[0]);   // Calculate the number of strings

    int result = numUniqueEmails(strs, strsSize);  // Call the function with the parameters

    ASSERT_EQ(2, result);
}
*/
TEST(isIsomorphic, Case1) {

    bool result = isIsomorphic("egg", "add");

    ASSERT_EQ(true, result);
}

TEST(isIsomorphic, Case2) {

    bool result = isIsomorphic("foo", "bar");

    ASSERT_EQ(false, result);
}

TEST(isIsomorphic, Case3) {

    bool result = isIsomorphic("paper", "title");

    ASSERT_EQ(true, result);
}

TEST(checkPossibility, Case1) {

    int nums[] = {4, 2, 3};
    bool result = checkPossibility(nums, 3);

    ASSERT_EQ(true, result);
}


TEST(checkPossibility, Case2) {

    int nums[] = {4, 2, 1};
    bool result = checkPossibility(nums, 3);

    ASSERT_EQ(false, result);
}

TEST(checkPossibility, Case3) {

    int nums[] = {3, 4, 2, 3};
    bool result = checkPossibility(nums, 4);

    ASSERT_EQ(false, result);
}

TEST(checkPossibility, Case4) {

    int nums[] = {1, 1, 1};
    bool result = checkPossibility(nums, 3);

    ASSERT_EQ(true, result);
}

TEST(FindAnagrams, Case1) {

    int resultSize = 0;
    int *result = findAnagrams("cbaebabacd", "abc", &resultSize);

    int expected[] = {0, 6};
    ASSERT_EQ(2, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }

}

TEST(FindAnagrams, Case2) {

    int resultSize = 0;
    int *result = findAnagrams("abab", "ab", &resultSize);

    int expected[] = {0, 1, 2};
    ASSERT_EQ(3, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }

}

TEST(NextGreaterElement1, Case1) {

    int resultSize = 0;
    int nums1[] = {4, 2, 1};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int nums2[] = {1, 2, 3, 4};
    int nums2Size = sizeof(nums1) / sizeof(nums2[0]);
    int expected[] = {-1, 3, -1};
    int *result = nextGreaterElement(nums1, nums1Size, nums2, nums2Size, &resultSize);
    ASSERT_EQ(3, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}

TEST(NextGreaterElement1, Case2) {

    int resultSize = 0;
    int nums1[] = {4, 1, 2};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int nums2[] = {1, 3, 4, 2};
    int nums2Size = sizeof(nums1) / sizeof(nums2[0]);
    int expected[] = {-1, 3, -1};
    int *result = nextGreaterElement(nums1, nums1Size, nums2, nums2Size, &resultSize);
    ASSERT_EQ(3, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}

TEST(NextGreaterElement2, Case1) {

    int resultSize = 0;
    int nums1[] = {1, 2, 1};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int expected[] = {2, -1, 2};
    int *result = nextGreaterElements(nums1, nums1Size, &resultSize);
    ASSERT_EQ(3, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}

TEST(NextGreaterElement2, Case2) {

    int resultSize = 0;
    int nums1[] = {1, 5, 3, 6, 8};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int expected[] = {5, 6, 6, 8, -1};
    int *result = nextGreaterElements(nums1, nums1Size, &resultSize);
    ASSERT_EQ(5, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}


TEST(NextGreaterElement2, Case3) {

    int resultSize = 0;
    int nums1[] = {5, 4, 3, 2, 1};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int expected[] = {-1, 5, 5, 5, 5};
    int *result = nextGreaterElements(nums1, nums1Size, &resultSize);
    ASSERT_EQ(5, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}


TEST(NextGreaterElement2, Case4) {

    int resultSize = 0;
    int nums1[] = {1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 100};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);
    int expected[] = {2, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100, -1};
    int expectedSize = sizeof expected / sizeof(expected[1]);
    int *result = nextGreaterElements(nums1, nums1Size, &resultSize);
    ASSERT_EQ(expectedSize, resultSize);
    for (int i = 0; i < resultSize; ++i) {
        ASSERT_EQ(expected[i], result[i]);
    }
}

TEST (MaxNumberOfBalloons, TestCase1) {
    int result = maxNumberOfBalloons("nlaebolko");
    ASSERT_EQ(1, result);
}

TEST (MaxNumberOfBalloons, TestCase2) {
    int result = maxNumberOfBalloons("loonbalxballpoon");
    ASSERT_EQ(2, result);
}

TEST (WordPattern, TestCase1) {
    bool result = wordPattern("abba", "dog cat cat fish");
    ASSERT_EQ(false, result);
}

TEST (FindDifferenceOfTwoArrays, TestCase1) {
    int resultSize = 0;
    int *resultColumnSizes;
    int nums1[] = {1, 2, 3};
    int nums1Size = sizeof(nums1) / sizeof(nums1[0]);

    int nums2[] = {2, 4, 6};
    int nums2Size = sizeof(nums2) / sizeof(nums2[0]);


    int expected1[] = {1, 3};
    int expected2[] = {4, 6};

    int expectedSize = sizeof expected1 / sizeof(expected1[1]);
    int **result = findDifference(nums1, nums1Size, nums2, nums2Size, &resultSize, &resultColumnSizes);


}

TEST (ShortestCompletingWord, TestCase1) {

    char *strs[] = {strdup("step"), strdup("steps"), strdup("stripe"), strdup("stepple")};  // Example input strings
    int strsSize = sizeof(strs) / sizeof(strs[0]);   // Calculate the number of strings

    char *result = shortestCompletingWord("1s3 PSt", strs, strsSize);

    ASSERT_STREQ("steps", result);

}

TEST(OnesAndZeros, TestCase1) {
    char *strs[] = {strdup("10"),
                    strdup("0001"),
                    strdup("111001"),
                    strdup("1"),
                    strdup("0")
    };  // Example input strings
    int strsSize = sizeof(strs) / sizeof(strs[0]);   // Calculate the number of strings
    int result = findMaxForm(strs, strsSize, 5, 3);
    ASSERT_EQ(4, result);
}

TEST(summaryRanges, TestCase1) {
    int resultSize = 0;
    int nums1[] = {0, 1, 2, 4, 5, 7};
    int numsSize = sizeof(nums1) / sizeof(nums1[0]);   // Calculate the number of strings

    char **result = summaryRanges(nums1, numsSize, &resultSize);

    char *expected[] = {strdup("0->2"),
                        strdup("4->5"),
                        strdup("7")};

    ASSERT_EQ(3, resultSize);

    for (int i = 0; i < resultSize; ++i) {
        ASSERT_STREQ(expected[i], result[i]);
    }

}

TEST(islandPerimeter, TestCase1) {
    int numRows = 4;
    int numCols = 4;

    // Allocate memory for the grid
    int **grid = (int **) malloc(numRows * sizeof(int *));
    for (int i = 0; i < numRows; i++) {
        grid[i] = (int *) malloc(numCols * sizeof(int));
    }


    grid[0][0] = 0;
    grid[0][1] = 1;
    grid[0][2] = 0;
    grid[0][3] = 0;

    grid[1][0] = 1;
    grid[1][1] = 1;
    grid[1][2] = 1;
    grid[1][3] = 0;

    grid[2][0] = 0;
    grid[2][1] = 1;
    grid[2][2] = 0;
    grid[2][3] = 0;

    grid[3][0] = 1;
    grid[3][1] = 1;
    grid[3][2] = 0;
    grid[3][3] = 0;

    int gridSize = numRows;

    int *gridColSize = (int *) malloc(numRows * sizeof(int));
    for (int i = 0; i < numRows; i++) {
        gridColSize[i] = numCols;
    }

    int result = islandPerimeter(grid, gridSize, gridColSize);

    ASSERT_EQ(16, result);
    for (int i = 0; i < numRows; i++) {
        free(grid[i]);
    }

    free(grid);
    free(gridColSize);
}

TEST(ToHex, TestCase1) {
    for (int n = 1; n < 100; ++n) {
        std::stringstream ss;
        ss << std::hex << n;
        std::string res(ss.str());
        char *hex = toHex(n);

        ASSERT_STREQ(res.c_str(), hex);
    }
}

TEST(MatrixDiagonalSum, TestCase1) {
    int numRows = 3;
    int numCols = 3;

    // Allocate memory for the grid
    int **grid = (int **) malloc(numRows * sizeof(int *));
    for (int i = 0; i < numRows; i++) {
        grid[i] = (int *) malloc(numCols * sizeof(int));
    }


    grid[0][0] = 1;
    grid[0][1] = 2;
    grid[0][2] = 3;

    grid[1][0] = 4;
    grid[1][1] = 5;
    grid[1][2] = 6;

    grid[2][0] = 7;
    grid[2][1] = 8;
    grid[2][2] = 9;


    int *gridColSize = (int *) malloc(numRows * sizeof(int));
    for (int i = 0; i < numRows; i++) {
        gridColSize[i] = numCols;
    }
    int sum = diagonalSum(grid, numRows, gridColSize);
    ASSERT_EQ(25, sum);
}

TEST(LongestRepeatedCharacterReplacement, TestCase1) {
    int result = characterReplacement("ABAB", 2);
    ASSERT_EQ(4, result);
}

TEST(countNegatives, TestCase1) {
    int numRows = 4;
    int numCols = 4;

    // Allocate memory for the grid
    int **grid = (int **) malloc(numRows * sizeof(int *));
    for (int i = 0; i < numRows; i++) {
        grid[i] = (int *) malloc(numCols * sizeof(int));
    }
    //[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]

    grid[0][0] = 4;
    grid[0][1] = 3;
    grid[0][2] = 2;
    grid[0][3] = -1;

    grid[1][0] = 3;
    grid[1][1] = 2;
    grid[1][2] = 1;
    grid[1][3] = -1;

    grid[2][0] = 1;
    grid[2][1] = 1;
    grid[2][2] = -1;
    grid[2][3] = -2;

    grid[3][0] = -1;
    grid[3][1] = -1;
    grid[3][2] = -2;
    grid[3][3] = -3;

    int *gridColSize = (int *) malloc(numRows * sizeof(int));
    for (int i = 0; i < numRows; i++) {
        gridColSize[i] = numCols;
    }
    int count = countNegatives(grid, numRows, gridColSize);
    ASSERT_EQ(8, count);
}

TEST(countNegatives, TestCase2) {
    int numRows = 4;
    int numCols = 2;

    // Allocate memory for the grid
    int **grid = (int **) malloc(numRows * sizeof(int *));
    for (int i = 0; i < numRows; i++) {
        grid[i] = (int *) malloc(numCols * sizeof(int));
    }
    //[[4,3,2,-1],[3,2,1,-1],[1,1,-1,-2],[-1,-1,-2,-3]]

    grid[0][0] = 3;
    grid[0][1] = 2;

    grid[1][0] = -3;
    grid[1][1] = -3;

    grid[2][0] = -3;
    grid[2][1] = -3;

    grid[3][0] = -3;
    grid[3][1] = -3;

    int *gridColSize = (int *) malloc(numRows * sizeof(int));
    for (int i = 0; i < numRows; i++) {
        gridColSize[i] = numCols;
    }
    int count = countNegatives(grid, numRows, gridColSize);
    ASSERT_EQ(6, count);
}

TEST(findMaxAverage, TestCase1) {
    int nums[6] = {1, 12, -5, -6, 50, 3};
    double result = findMaxAverage(nums, 6, 4);
    ASSERT_EQ(12.75000, result);
}

TEST(findMaxAverage, TestCase2) {
    int nums[1] = {-1};
    double result = findMaxAverage(nums, 1, 1);
    ASSERT_EQ(-1, result);
}

TEST(findMaxAverage, TestCase3) {
    int nums[5] = {4, 0, 4, 3, 3};
    double result = findMaxAverage(nums, 5, 5);
    ASSERT_EQ(2.8, result);
}

TEST(mergeSort, TestCase1) {
    int nums[10] = {5, 0, 3, 2, 4, 8, 6, 9, 7, 1};
    int sorted_expected[10] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    int returnSize = 0;
    int numsSize = sizeof(nums) / sizeof(nums[0]);
    int *sorted = sortArray(nums, numsSize, &returnSize);

    ASSERT_EQ(numsSize, returnSize);
    for (int i = 0; i < returnSize; i++) {
        ASSERT_EQ(sorted_expected[i], sorted[i]);
    }
}

TEST(distributeCandies, TestCase1) {
    int nums[6] = {1, 1, 2, 2, 3, 3};

    int numsSize = sizeof(nums) / sizeof(nums[0]);
    int result = distributeCandies(nums, numsSize);

    ASSERT_EQ(3, result);

}

int main(int argc, char **argv) {
    ::testing::InitGoogleTest(&argc, argv);
    return RUN_ALL_TESTS();
}