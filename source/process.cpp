#include "process.hpp"

#include <filesystem>

#include "config.hpp"

#ifdef _WIN32
#include <windows.h>
#else
// TODO: Implement Linux support
#endif

void cProcess::start() {
#ifdef _WIN32
  memset(&si, 0, sizeof(si));
  si.cb = sizeof(si);
  memset(&pi, 0, sizeof(pi));

  if (!std::filesystem::exists(Config.gamePath + "\\gmod.exe")) {
    throw std::runtime_error("Game executable not found");
  }

  bool bSuccess = CreateProcessA((Config.gamePath + "\\gmod.exe").c_str(), NULL,
                                 NULL, NULL, TRUE, 0, NULL, NULL, &si, &pi);

  if (!bSuccess) {
    throw std::runtime_error("Failed to create process");
    return;
  }
#else
  // TODO: Implement Linux support
#endif
}

void cProcess::stop() {
#ifdef _WIN32
  TerminateProcess(pi.hProcess, 1);
  CloseHandle(pi.hProcess);
  CloseHandle(pi.hThread);
#else
  // TODO: Implement Linux support
#endif
}
