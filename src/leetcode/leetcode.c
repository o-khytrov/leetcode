#include <string.h>
#include <stdbool.h>
#include <limits.h>
#include <stdlib.h>
#include <stdio.h>

#include <leetcode/leetcode.h>

int strStr(char *haystack, char *needle) {
    int h, n = 0;
    int needle_length = strlen(needle);
    int haystack_length = strlen(haystack);
    if (haystack_length < needle_length) return -1;
    for (h = 0; h < haystack_length; h++) {
        if (haystack[h] == needle[n]) {
            n++;
        } else {
            h = h - n;
            n = 0;
        }
        if (n == needle_length) {
            return h - needle_length + 1;
        }
    }
    return -1;

}
/**/
bool isSubsequence(char *s, char *t) {
    int s_length = strlen(s);
    int t_length = strlen(t);
    if (s_length > t_length) return false;
    int count = 0;
    int s_index = 0;


    for (int i = 0; i < t_length; i++) {
        if (s_index > s_length - 1) {
            break;
        }
        if (t[i] == s[s_index]) {
            count++;
            s_index++;
        }
    }
    return count == s_length;
}

//605
bool canPlaceFlowers(int *flowerbed, int flowerbedSize, int n) {

    int counter = 0;
    for (int i = 0; i < flowerbedSize; i++) {

        if (counter >= n) {
            break;
        }
        int l = 0;
        int r = 0;
        if (i > 0) l = flowerbed[i - 1];
        if (i < flowerbedSize - 1) r = flowerbed[i + 1];
        if (!flowerbed[i] && !r && !l) {
            flowerbed[i] = 1;
            counter++;
        }
    }
    return counter == n;
}

void sortColors(int *nums, int numsSize) {
    int r = 0, w = 0, b = 0;
    for (int i = 0; i < numsSize; i++) {
        switch (nums[i]) {
            case 0:
                r++;
                break;
            case 1:
                w++;
                break;
            case 2:
                b++;
                break;
            default:
                break;
        }

    }
    for (int i = 0; i < r; i++) {
        nums[i] = 0;
    }
    for (int i = r; i < r + w; i++) {
        nums[i] = 1;
    }
    for (int i = r + w; i < r + w + b; i++) {
        nums[i] = 2;
    }
}

int max_int(int a, int b) {
    if (a > b) return a;
    return b;
}

int *replaceElements(int *arr, int arrSize, int *returnSize) {
    int max = INT_MIN;
    int *new_array = (int *) malloc(sizeof(int) * arrSize);
    for (int i = 0; i < arrSize; i++) {
        max = max_int(max, arr[i]);
        new_array[i] = max;
    }
    new_array[arrSize - 1] = -1;
    *returnSize = arrSize;
    return new_array;
}

int add(int a, int b) {
    return 0;
}

int lengthOfLastWord(char *s) {
    int len = strlen(s);
    int counter = 0;
    int is_space = 0;
    for (int i = 0; i < len; i++) {
        if (s[i] != ' ' && is_space) {
            counter = 0;
        }

        if (s[i] == ' ') {
            is_space = 1;
        } else {
            is_space = 0;
        }

        if (!is_space) {
            counter++;
        }
    }

    return counter;
}

char *longestCommonPrefix(char **strs, int strsSize) {

    for (int c = 0;; ++c) {
        if (strs[0][c] == '\0') // the longest common prefix is the first string
            return strs[0];
        for (int s = 1; s < strsSize; ++s) {
            if (strs[s][c] != strs[0][c]) // compare all strings character to the first one
            {
                strs[0][c] = '\0'; // replace the current character with '\0'
                return strs[0];
            }
        }
    }
}

int pivotIndex(int *nums, int numsSize) {

    return -1;
}
