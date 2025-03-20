#include <iostream>
#include <thread>

#include "config.hpp"
#include "process.hpp"

int main() {
#ifdef __linux__
  // TODO: Implement Linux support
  std::cout << "Linux is not supported.\nPress enter to exit...\n";
  std::cin.get();
  return 0;
#endif

  std::cout << "Welcome to Startup Millenium\n\n";

  Config.createConfig();
  Config.readConfig();

  std::cout << "GarrysMod directory found.\nStarting loop...\n";
  std::this_thread::sleep_for(std::chrono::seconds(5));

  cProcess Process;
  for (int i = 0; i < 999; i++) {
    Process.start();

    std::this_thread::sleep_for(std::chrono::seconds(15));

    Process.stop();

    std::cout << i + 1 << " / 1000\n";
    std::this_thread::sleep_for(std::chrono::seconds(10));
  }

  std::cout << "Loop finished.\nPress enter to exit...\n";
  std::cin.get();
  return 0;
}
