cmake_minimum_required(VERSION 3.11)
project(SM VERSION 1.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD_REQUIRED TRUE)
set(CMAKE_CXX_EXTENSIONS OFF)
set(JSON_BuildTests OFF CACHE INTERNAL "")

add_subdirectory(json)

add_executable(SM)

target_sources(SM PRIVATE source/main.cpp)
target_link_libraries(SM PRIVATE nlohmann_json::nlohmann_json)
target_compile_features(SM PRIVATE cxx_std_20)
