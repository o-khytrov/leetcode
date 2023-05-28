find_package(GTest REQUIRED)

add_executable(leetcodetests test.cpp)

target_link_libraries(leetcodetests
        PRIVATE
        GTest::GTest
        leetcode)

add_test(leetcode_gtest leetcodetests)
