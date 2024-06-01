cmake_minimum_required(VERSION 3.11)
project(SM C CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED TRUE)
set(CMAKE_CXX_EXTENSIONS OFF)

add_executable(SM source/main.cpp)

if (WIN32)

else()

  target_link_libraries(SM PRIVATE libc++)

endif()

set_target_properties(SM PROPERTIES
  CXX_STANDARD 20
  CXX_STANDARD_REQUIRED YES
  CXX_EXTENSIONS NO
)