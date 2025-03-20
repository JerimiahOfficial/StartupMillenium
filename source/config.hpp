#pragma once

#include <string>

class cConfig {
public:
  void createConfig();
  void readConfig();

  std::string gamePath;
};
inline cConfig Config;