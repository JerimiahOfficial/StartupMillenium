### StartupMillenium
A simple program to get the acheivement for a game called Garry's Mod. This acheivement requires you to open and close the game 1000 times.

> [!WARNING]
> The program will only work on the default version of Garry's Mod it will not work on any beta branches.

> [!IMPORTANT]  
> If your Garry's Mod is on a different hard drive make sure you set the right path in the config.json file.

> [!NOTE]  
> The timings may be off as different computers start the game slower, faster or take longer to fully load.

### Tested platforms
So far the only supported platform is windows. I am planning on adding linux support in the future.

## Building instructions

### Dependencies:
[CMake](https://cmake.org/) is an open-source, cross-platform family of tools designed to build, test and package software.

### Windows
`cmake -B build -G "MinGW Makefiles" -DCMAKE_BUILD_TYPE=Release -DCMAKE_CXX_COMPILER=g++ -DCMAKE_C_COMPILER=gcc`  
`cmake --build build --config Release`

or use whatever compiler you want to use.

<!-- 
Will be added in when linux support is added.
### Linux

`cmake -B build -DCMAKE_BUILD_TYPE=Release -DCMAKE_CXX_COMPILER=g++ -DCMAKE_C_COMPILER=gcc`  
`cmake --build build --config Release`
-->

