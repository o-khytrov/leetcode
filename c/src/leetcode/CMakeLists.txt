
add_library(leetcode leetcode.c include/leetcode/ones_and_zeros.h ones_and_zeros.c)

target_include_directories(leetcode PUBLIC include)

