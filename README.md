### StartupMillenium
A simple program to get the acheivement for a game called Garry's Mod. This acheivement requires you to open and close the game 1000 times.

> [!NOTE]
> The program is hardcoded to `C:\Program Files (x86)\Steam\steamapps\common\GarrysMod`. If you have the game on another hard drive it will not work unless you change the path.

### Tested platforms
It has been tested and verified working on windows. So far the only supported platform is windows. I am planning on adding in linux support in the future.

### Dependencies:
[CMake](https://cmake.org/) is an open-source, cross-platform family of tools designed to build, test and package software.

#### Optional
gcc and g++ for windows:  
[msys2](https://www.msys2.org/) is a collection of tools and libraries providing you with an easy-to-use environment for building, installing and running native Windows software.

### Building instructions

#### Windows
`cmake -B build -G "MinGW Makefiles" -DCMAKE_BUILD_TYPE=Release -DCMAKE_CXX_COMPILER=g++ -DCMAKE_C_COMPILER=gcc`  
`cmake --build build --config Release`

<!-- 
Will be added in when linux support is added.
#### Linux

`cmake -B build -DCMAKE_BUILD_TYPE=Release -DCMAKE_CXX_COMPILER=g++ -DCMAKE_C_COMPILER=gcc`  
`cmake --build build --config Release`
-->

