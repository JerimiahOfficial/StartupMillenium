#include <filesystem>
#include <format>
#include <iostream>
#include <string>
#include <thread>

#ifdef _WIN32
#include <stdio.h>
#include <tchar.h>
#include <windows.h>

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
#include <signal.h>
#include <unistd.h>
std::string path = std::format(
    "/home/{}/.local/share/Steam/steamapps/common/GarrysMod", getlogin());

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
  std::cout << "Starting loop...\n";

  std::this_thread::sleep_for(std::chrono::seconds(10));

  for (int i = 1; i < 1000; i++) {
#ifdef _WIN32
    PROCESS_INFORMATION pInfo = startup((path + "\\hl2.exe").c_str());

    if (pInfo.hProcess == NULL) {
      std::cout << "Failed to start Garrysmod.\n";
      return 1;
    }
#elif __linux__
    // TODO: Implement Linux support
    pid_t pId = fork();
    perror("fork");

    if (pId == -1) {
      std::cout << "Failed to start Garrysmod.\n";
      return 1;
    }

    // TODO: figure out how to launch garrysmod with steam
    //       won't start on virtual machine for arch linux.
    execl((path + "/hl2.sh").c_str(), "-steam", "-game", "garrysmod");
    perror("execl");
#endif

    std::this_thread::sleep_for(std::chrono::seconds(15));

#ifdef _WIN32
    TerminateProcess(pInfo.hProcess, 0);
    CloseHandle(pInfo.hProcess);
    CloseHandle(pInfo.hThread);
#elif __linux__
    // TODO: Implement Linux support
    if (kill(pId, SIGKILL)) {
      std::cout << "Failed to kill Garrysmod.\n";
      return 1;
    }
#endif

    std::cout << i << " / 1000\n";
    std::this_thread::sleep_for(std::chrono::seconds(10));
  }

  std::cout << "Loop finished.\n";
  std::cout << "Press enter to exit...\n";
  std::cin.get();

  return 0;
}
