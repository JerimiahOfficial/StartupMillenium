cmake_minimum_required(VERSION 3.11)
project(SM CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED TRUE)
set(CMAKE_CXX_EXTENSIONS OFF)

add_executable(SM)

target_sources(SM PRIVATE source/main.cpp)
