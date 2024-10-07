#include <filesystem>
#include <fstream>
#include <iostream>
#include <nlohmann/json.hpp>
#include <string>
#include <thread>

std::string gamePath;
std::string configPath =
    std::filesystem::current_path().append("config.json").string();

#ifdef _WIN32
#include <windows.h>

std::string defaultPath =
    "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";
#elif __linux__
#include <signal.h>
#include <unistd.h>

std::string str(getlogin());
std::string defaultPath =
    "/home/" + str + "/.local/share/Steam/steamapps/common/GarrysMod";
#endif

void createConfig() {
  if (std::filesystem::exists(configPath))
    return;

  nlohmann::json config;
  config["path"] = defaultPath;

  std::ofstream file(configPath);
  file << config.dump(4);
  file.close();

  std::cout << "Config file created.\n";
}

void readConfig() {
  if (!std::filesystem::exists(configPath))
    throw std::runtime_error("Config file doesn't exist.");

  std::ifstream file(configPath);

  nlohmann::json config = nlohmann::json::parse(file);
  gamePath = config["path"].get<std::string>();

  if (gamePath.empty())
    throw std::runtime_error("Failed to read config file.");

  if (!std::filesystem::exists(gamePath))
    throw std::runtime_error("Game path doesn't exist.");

  file.close();

  std::cout << "Config file found:\n" << configPath << "\n\n";
}

int main() {
#ifdef __linux__
  // TODO: Implement Linux support
  std::cout << "Linux is not supported.\nPress enter to exit...\n";
  std::cin.get();
  return 0;
#endif

  std::cout << "Welcome to Startup Millenium\n\n";

  createConfig();
  readConfig();

  std::cout << "GarrysMod directory found.\nStarting loop...\n";
  std::this_thread::sleep_for(std::chrono::seconds(10));

  for (int i = 0; i < 999; i++) {
#ifdef _WIN32
    bool bSuccess = false;

    _STARTUPINFOA si;
    _PROCESS_INFORMATION pi;

    memset(&si, 0, sizeof(si));
    si.cb = sizeof(si);
    memset(&pi, 0, sizeof(pi));

    bSuccess = CreateProcessA((gamePath + "\\hl2.exe").c_str(), NULL, NULL,
                              NULL, TRUE, 0, NULL, NULL, &si, &pi);

    if (!bSuccess) {
      std::cout << "Failed to create process, stopping program.\n";
      return 1;
    }
#elif __linux__
    // TODO: Implement Linux support
    pid_t pId = fork();

    if (pId == 0) {
      // Child process
      std::string hl2Path = gamePath + "/hl2_linux";
      execl(hl2Path.c_str(), "hl2_linux", NULL);

      // If execl returns, it means it failed
      std::cerr << "Failed to execute hl2_linux\n";
      exit(1);
    } else if (pId < 0) {
      // Fork failed
      std::cerr << "Failed to fork process\n";
      return 1;
    }
#endif

    std::this_thread::sleep_for(std::chrono::seconds(15));

#ifdef _WIN32
    TerminateProcess(pi.hProcess, 1);
    CloseHandle(pi.hProcess);
    CloseHandle(pi.hThread);
#elif __linux__
    // TODO: Implement Linux support
    int killResult = kill(pId, SIGTERM);

    if (killResult == -1) {
      std::cerr << "Failed to kill process\n";
      return 1;
    }

    int status;
    pid_t pid = waitpid(pId, &status, 0);

    if (pid == -1) {
      std::cerr << "Failed to wait for process\n";
      return 1;
    }

    if (WIFEXITED(status) && WEXITSTATUS(status) == 0) {
      std::cout << "hl2_linux exited with status " << WEXITSTATUS(status)
                << "\n";
    }
#endif

    std::cout << i + 1 << " / 1000\n";
    std::this_thread::sleep_for(std::chrono::seconds(10));
  }

  std::cout << "Loop finished.\nPress enter to exit...\n";
  std::cin.get();
  return 0;
}
