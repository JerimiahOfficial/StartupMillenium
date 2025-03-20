cmake_minimum_required(VERSION 3.11)
project(SM CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(JSON_BuildTests OFF CACHE INTERNAL "")

add_subdirectory(json)

file(GLOB sources source/*.cpp source/*.hpp)

add_executable(${PROJECT_NAME})

target_sources(${PROJECT_NAME} PRIVATE ${sources})
target_link_libraries(${PROJECT_NAME} PRIVATE nlohmann_json::nlohmann_json)
