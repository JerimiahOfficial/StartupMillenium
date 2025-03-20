# Startup Millenium

A simple program to get the acheivement for a game called Garry's Mod. This acheivement requires you to open and close the game 1000 times.

> [!NOTE]  
> The timings may be off as different computers start the game slower, faster or take longer to fully load.

## Tested platforms

So far **the only supported platform is Windows**. I am planning on adding linux support in the future.

## Building

`cmake -B build -DCMAKE_BUILD_TYPE=Release`  
`cmake --build build --config Release`  

## Configuration

Config file is created upon first run if it does not exist.

The default path is `C:\Program Files (x86)\Steam\steamapps\common\GarrysMod`
