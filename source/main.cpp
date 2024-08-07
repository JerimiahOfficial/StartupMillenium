#include <filesystem>
// #include <format>
#include <fstream>
#include <iostream>
#include <nlohmann/json.hpp>
#include <string>
#include <thread>

std::string gamePath;
std::string configPath =
    std::filesystem::current_path().append("config.json").string();

#ifdef _WIN32
#include <handleapi.h>
#include <stdio.h>
#include <tchar.h>
#include <windows.h>
std::string defaultPath =
    "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";
#elif __linux__
#include <signal.h>
#include <unistd.h>
// std::string defaultPath = std::format(
//     "/home/{}/.local/share/Steam/steamapps/common/GarrysMod", getlogin());
#endif

void createConfig() {
  if (std::filesystem::exists(configPath)) return;

  nlohmann::json config;
  config["path"] = defaultPath;

  std::ofstream file(configPath);
  file << config.dump(4);
  file.close();

  std::cout << "Config file created.\n";
}

void readConfig() {
  std::ifstream file(configPath);

  nlohmann::json config = nlohmann::json::parse(file);
  gamePath = config["path"].get<std::string>();

  file.close();

  std::cout << "Config file found: \n" << configPath << "\n\n";
}

int main() {
#ifdef __linux__
  // TODO: Implement Linux support
  std::cout << "This program is not supported on Linux yet.\n";
  std::cout << "Press enter to exit...\n";
  std::cin.get();
  return 0;
#endif

  std::cout << "Welcome to Startup Millenium\n\n";

  createConfig();
  readConfig();

  if (gamePath.empty()) {
    std::cout << "Failed to read config file.\n";
    std::cout << "Press enter to exit...\n";
    std::cin.get();
    return 0;
  }

  if (!std::filesystem::exists(gamePath)) {
    std::cout << "Check config path may be incorrect.\n";
    std::cout << "Press enter to exit...\n";
    std::cin.get();
    return 0;
  }

  std::cout << "GarrysMod directory found.\n";
  std::cout << "Starting loop...\n";

  std::this_thread::sleep_for(std::chrono::seconds(10));

  for (int i = 1; i < 1000; i++) {
#ifdef _WIN32
    bool bSuccess = false;

    _STARTUPINFOA si;
    _PROCESS_INFORMATION pi;

    ZeroMemory(&si, sizeof(si));
    si.cb = sizeof(si);
    ZeroMemory(&pi, sizeof(pi));

    bSuccess = CreateProcessA((gamePath + "\\hl2.exe").c_str(), NULL, NULL,
                              NULL, TRUE, 0, NULL, NULL, &si, &pi);

    if (!bSuccess) {
      std::cout << "Failed to create process, stopping program.\n";
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
    TerminateProcess(pi.hProcess, 1);
    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);
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
