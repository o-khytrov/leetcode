#include <string.h>
#include <stdbool.h>
#include <limits.h>
#include <stdlib.h>
#include <stdio.h>
#include <ctype.h>
#include <leetcode/leetcode.h>
#include <leetcode/uthash.h>

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
    int sum = 0;
    for (int i = 0; i < numsSize; i++) {
        sum += nums[i];
    }
    int tmp_sum = 0;
    for (int i = 0; i < numsSize; i++) {
        if (sum - (tmp_sum + nums[i]) == tmp_sum) {

            return i;
        }

        tmp_sum += nums[i];
    }
    return -1;
}

int removeElement(int *nums, int numsSize, int val) {
    int tmp[numsSize];
    int counter = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (nums[i] != val) {
            tmp[counter] = nums[i];
            counter++;
        }
    }

    memcpy(nums, &tmp, counter * sizeof(int));

    return counter;
}

int numUniqueEmails(char **emails, int emailsSize) {
    int counter = 0;
    for (int i = 0; i < emailsSize; ++i) {
        int part = 0; //0-local; 1- domain;
        char *email = emails[i];
        while (email) {
            if (email == '@') {
                part = 1;
            }
            email++;

        }

    }
    return counter;
}

bool isIsomorphic(char *s, char *t) {

    int map_s[256] = {0};
    int map_t[256] = {0};
    int i = 0;

    while (s[i]) {
        if (map_s[s[i]] != map_t[t[i]]) {
            return false;
        }
        map_s[s[i]] = i + 1;
        map_t[t[i]] = i + 1;
        i++;
    }
    return true;
}

bool checkPossibility(int *nums, int numsSize) {

    int changed = 0;
    for (int i = 0; i < numsSize - 1; ++i) {

        if (nums[i] <= nums[i + 1]) {
            continue;
        }
        if (changed) return false;

        if (i == 0 || nums[i + 1] >= nums[i - 1]) {
            nums[i] = nums[i + 1];
        } else {
            nums[i + 1] = nums[i];
        }
        changed = 1;
    }

    return true;
}

int *findAnagrams(char *s, char *p, int *returnSize) {
    int p_map[26] = {0};
    int s_map[26] = {0};
    int p_len = 0;
    char *p_tpm = p;
    while (*p_tpm) {
        int c = *p_tpm - 97;
        p_map[c] += 1;
        p_tpm++;
        p_len++;
    }
    int s_len = strlen(s);
    int *ptr = (int *) malloc(s_len * sizeof(int));
    *returnSize = 0;

    int l = 0;
    int r = p_len;
    while (r <= s_len) {
        if (l == 0) {
            for (int i = l; i < r; i++) {
                int c = s[i] - 97;
                s_map[c]++;
            }
        } else {
            s_map[s[(l - 1)] - 97]--;
            s_map[s[(r - 1)] - 97]++;
        }
        int is_anagram = 1;
        for (int i = 0; i < 26; ++i) {
            if (s_map[i] != p_map[i]) {
                is_anagram = 0;
                break;
            }
        }
        if (is_anagram) {
            ptr[*returnSize] = l;
            (*returnSize)++;
        }
        r++;
        l++;
    }


    return ptr;
}

int *nextGreaterElement(int *nums1, int nums1Size, int *nums2, int nums2Size, int *returnSize) {
    int *ans = malloc(sizeof(int) * nums1Size);
    *returnSize = nums1Size;
    int hash_map[1000];
    for (int i = 0; i < nums2Size; i++)
        hash_map[nums2[i]] = i;
    for (int i = 0; i < nums1Size; i++) {
        int nex_greater = -1;

        for (int j = hash_map[nums1[i]] + 1; j < nums2Size; j++) {
            if (nums2[j] > nums1[i]) {
                nex_greater = nums2[j];
                break;
            }
        }

        ans[i] = nex_greater;
    }
    return ans;
}

int *nextGreaterElements(int *nums, int numsSize, int *returnSize) {
    int *ans = malloc(sizeof(int) * numsSize);

    *returnSize = numsSize;
    for (int i = 0; i < numsSize; ++i) {
        int num = nums[i];
        int next_greater = -1;
        int counter = 0;
        int j = i == numsSize - 1 ? 0 : i + 1;
        while (counter <= numsSize) {
            if (nums[j] > num) {
                next_greater = nums[j];
                break;
            }
            counter++;
            if (j == numsSize - 1) {
                j = 0;
            } else {
                j++;
            }
        }

        ans[i] = next_greater;
    }
    return ans;
}

int maxNumberOfBalloons(char *text) {
    int word_map[26] = {0};
    char *word = "balloon";
    while (*word) {
        word_map[*word - 97]++;
        word++;
    }
    int result = 0;

    int map[26] = {0};
    char *text_ptr = text;
    while (*text_ptr) {
        map[*text_ptr - 97]++;
        text_ptr++;
    }
    for (int i = 0; i < 26; ++i) {
        if (word_map[i] != 0) {
            if (map[i] < word_map[i]) {
                result = 0;
                break;
            } else {
                int cnt = map[i] / word_map[i];
                if (result == 0 || cnt < result) {
                    result = cnt;
                }

            }
        }
    }

    return result;
}

bool wordPattern(char *pattern, char *s) {
    int len = strlen(pattern);
    char **map = malloc(sizeof(char) * len);
    char *tmp = s;
    for (int i = 0; i < len; ++i) {
        if (*tmp == '\0')
            break;
        if (*tmp == ' ') tmp++;
        map[i] = tmp;
        while (*tmp != ' ' && tmp != '\0') {
            tmp++;
        }
    }
    return true;
}

int **findDifference(int *nums1, int nums1Size, int *nums2, int nums2Size, int *returnSize, int **returnColumnSizes) {
    const int max_size = 2048;
    int map1[2048] = {0};
    int map2[2048] = {0};
    int offset = 1000;
    for (int i = 0; i < nums1Size; i++) {
        map1[nums1[i] + offset] = 1;
    }
    for (int i = 0; i < nums2Size; i++) {
        map2[nums2[i] + offset] = 1;
    }
    int maxSize = (nums1Size > nums2Size) ? nums1Size : nums2Size;
    *returnSize = 2;

    int **ans = (int **) malloc(*returnSize * sizeof(int *));
    int *ans1 = (int *) malloc(maxSize * sizeof(int));
    int *ans2 = (int *) malloc(maxSize * sizeof(int));
    int *colSizes = malloc(*returnSize * sizeof(int));

    int ans1Size = 0;
    int ans2Size = 0;
    for (int i = 0; i < max_size; i++) {
        if (map1[i] && !map2[i]) {
            ans1[ans1Size] = i - offset;
            ans1Size++;
        }

        if (map2[i] && !map1[i]) {
            ans2[ans2Size] = i - offset;
            ans2Size++;
        }

    }
    ans[0] = ans1;
    ans[1] = ans2;

    colSizes[0] = ans1Size;
    colSizes[1] = ans2Size;
    *returnColumnSizes = colSizes;
    return ans;

}

char *shortestCompletingWord(char *licensePlate, char **words, int wordsSize) {
    int map[26] = {0};
    int tmp[26] = {0};
    while (*licensePlate) {
        if (isalpha(*licensePlate)) {
            map[tolower(*licensePlate) - 97]++;
        }

        licensePlate++;
    }
    int min_length = -1;
    int word_index = 0;
    for (int i = 0; i < wordsSize; i++) {
        memset(tmp, 0, sizeof(tmp));
        char *word = words[i];
        int length = 0;
        while (*word) {
            tmp[*word - 97]++;
            word++;
            length++;
        }

        int completing = 1;
        for (int l = 0; l < 26; l++) {

            if (tmp[l] > map[l]) {
                completing = 0;
                break;
            }
        }
        if (completing && (min_length == -1 || length < min_length)) {
            printf("%s", words[i]);
            min_length = length;
            word_index = i;
        }

    }
    return words[word_index];
}

char **summaryRanges(int *nums, int numsSize, int *returnSize) {
    char **result = (char *) malloc(sizeof(char *) * numsSize * 2);

    for (int i = 0; i < numsSize; ++i) {
        int num = nums[i];
        while (i < numsSize - 1 && nums[i + 1] - nums[i] == 1) {
            i++;
        }
        char *str = malloc(sizeof(char) * 5);
        if (nums[i] - num == 0) {
            //printf("%d\n", num);
            sprintf(str, "%d", num);
        } else {
            //printf("%d->%d\n", num, nums[i]);
            sprintf(str, "%d->%d", num, nums[i]);
        }
        result[*returnSize] = str;
        (*returnSize)++;
    }

    return result;
}