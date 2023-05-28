#include <string.h>
#include <stdbool.h>
#include "functions.h"


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
