#include <filesystem>
#include <iostream>
#include <thread>

#ifdef _WIN32
#include <stdio.h>
#include <tchar.h>
#include <windows.h>

// #include <filesystem>
// namespace fs = std::filesystem;

std::string path =
    "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";

_PROCESS_INFORMATION startup(LPCSTR lpApplicationName) {
  bool bSuccess = false;

  _STARTUPINFOA si;
  _PROCESS_INFORMATION pi;

  ZeroMemory(&si, sizeof(si));
  si.cb = sizeof(si);
  ZeroMemory(&pi, sizeof(pi));

  bSuccess = CreateProcessA(lpApplicationName, NULL, NULL, NULL, TRUE, 0, NULL,
                            NULL, &si, &pi);

  if (!bSuccess) {
    std::cout << "Failed to create process.\n";
  }

  return pi;
}

#elif __linux__
// #include <experimental/filesystem>
// namespace fs = std::experimental::filesystem;
std::string path = "/home/user/.steam/steam/steamapps/common/GarrysMod";
// TODO: Implement Linux
#endif

int main() {
#ifdef __linux__
  // TODO: Implement Linux support
  std::cout << "This program is not supported on Linux yet.\n";
  std::cout << "Press enter to exit...\n";
  std::cin.get();
  return 0;
#endif

  std::cout << "Welcome to Startup Millenium\n";

  if (!std::filesystem::exists(path)) {
    std::cout << "GarrysMod directory not found.\n";
    std::cout << "Press enter to exit...\n";
    std::cin.get();
    return 0;
  }

  std::cout << "GarrysMod directory found.\n";

  std::filesystem::current_path(path);

  std::cout << "Starting loop...\n";

  std::this_thread::sleep_for(std::chrono::seconds(10));

  for (int i = 1; i < 1000; i++) {
#ifdef _WIN32
    PROCESS_INFORMATION pInfo = startup("hl2.exe");

    if (pInfo.hProcess == NULL) {
      std::cout << "Failed to start Garrysmod.\n";
      return 1;
    }
#elif __linux__
    // TODO: Implement Linux support
#endif

    std::this_thread::sleep_for(std::chrono::seconds(15));

#ifdef _WIN32
    TerminateProcess(pInfo.hProcess, 0);
    CloseHandle(pInfo.hProcess);
    CloseHandle(pInfo.hThread);
#elif __linux__
    // TODO: Implement Linux support
#endif

    std::cout << i << " / 1000\n";
    std::this_thread::sleep_for(std::chrono::seconds(10));
  }

  std::cout << "Loop finished.\n";
  std::cout << "Press enter to exit...\n";
  std::cin.get();

  return 0;
}
