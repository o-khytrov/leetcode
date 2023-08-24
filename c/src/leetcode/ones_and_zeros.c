#include <leetcode/ones_and_zeros.h>
#include <stdlib.h>
#include <string.h>

#define  MAX_LENGTH  600

int count_chars(char *s, char c) {
    int count = 0;
    while (*s) {
        if (*s == c) count++;
        s++;
    }
    return count;
}

int max(int a, int b) {
    return a > b ? a : b;
}

int findMaxForm(char **strs, int strsSize, int m, int n) {

    int dp[MAX_LENGTH][MAX_LENGTH] = {0};
    for (int k = 0; k < strsSize; k++) {
        int zeros = count_chars(strs[k], '0');
        int ones = count_chars(strs[k], '1');
        for (int i = m; i >= zeros; i--) {
            for (int j = n; j >= ones; j--) {
                dp[i][j] = max(dp[i][j], dp[i - zeros][j - ones] + 1);
            }
        }
    }

    return dp[m][n];
}
