#pragma once

#ifdef _WIN32
#include <windows.h>
#endif

class cProcess {
public:
  void start();
  void stop();

private:
#ifdef _WIN32
  _STARTUPINFOA si;
  _PROCESS_INFORMATION pi;
#else
  // TODO: Implement Linux support
#endif
};