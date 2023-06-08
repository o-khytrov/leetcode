#include <stdbool.h>
#include <leetcode/ones_and_zeros.h>

#ifdef __cplusplus
extern "C"
{
#endif
int strStr(char *haystack, char *needle);

bool isSubsequence(char *s, char *t);

bool canPlaceFlowers(int *flowerbed, int flowerbedSize, int n);

void sortColors(int *nums, int numsSize);

int *replaceElements(int *arr, int arrSize, int *returnSize);

int add(int a, int b);
/*
58. Length of Last Word
Given a string s consisting of words and spaces, return the length of the last word in the string.

A word is a maximal substring consisting of non-space characters only.
 */
int lengthOfLastWord(char *s);

/*
14. Longest Common Prefix
Write a function to find the longest common prefix string amongst an array of strings.
If there is no common prefix, return an empty string "".
 **/
char *longestCommonPrefix(char **strs, int strsSize);

//724. Find Pivot Index

int pivotIndex(int *nums, int numsSize);

//27. Remove Element
int removeElement(int *nums, int numsSize, int val);

//929. Unique Email Addresses
int numUniqueEmails(char **emails, int emailsSize);

//205. Isomorphic Strings

bool isIsomorphic(char *s, char *t);
//665. Non-decreasing Array
bool checkPossibility(int *nums, int numsSize);
//438. Find All Anagrams in a String
int *findAnagrams(char *s, char *p, int *returnSize);
//496. Next Greater Element I
int *nextGreaterElement(int *nums1, int nums1Size, int *nums2, int nums2Size, int *returnSize);
//503. Next Greater Element II
int *nextGreaterElements(int *nums, int numsSize, int *returnSize);
//1189. Maximum Number of Balloons
int maxNumberOfBalloons(char *text);

bool wordPattern(char *pattern, char *s);

int **findDifference(int *nums1, int nums1Size, int *nums2, int nums2Size, int *returnSize, int **returnColumnSizes);

char *shortestCompletingWord(char *licensePlate, char **words, int wordsSize);

char **summaryRanges(int *nums, int numsSize, int *returnSize);
int islandPerimeter(int **grid, int gridSize, int *gridColSize);
int missingNumber(int *nums, int numsSize);

//405. Convert a Number to Hexadecimal
char *toHex(int num);
//1572. Matrix Diagonal Sum
int diagonalSum(int **mat, int matSize, int *matColSize);
//424. Longest Repeating Character Replacement
int characterReplacement(char *s, int k);
//1351. Count Negative Numbers in a Sorted Matrix
int countNegatives(int **grid, int gridSize, int *gridRowSize);
#ifdef __cplusplus
}
#endif