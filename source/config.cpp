#include "config.hpp"

#include <fstream>
#include <iostream>

#include <nlohmann/json.hpp>

std::string configPath =
    std::filesystem::current_path().append("config.json").string();

#ifdef _WIN32
std::string defaultPath =
    "C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod";
#else
// TODO: Implement Linux support
#endif

void cConfig::createConfig() {
  if (std::filesystem::exists(configPath))
    return;

  nlohmann::json config;
  config["game path"] = defaultPath;

  std::ofstream file(configPath);
  file << config.dump(4);
  file.close();

  std::cout << "Config file created.\n";
}

void cConfig::readConfig() {
  if (!std::filesystem::exists(configPath))
    throw std::runtime_error("Config file doesn't exist.");

  std::ifstream file(configPath);

  nlohmann::json config = nlohmann::json::parse(file);
  gamePath = config["game path"].get<std::string>();

  if (gamePath.empty())
    throw std::runtime_error("Failed to read config file.");

  if (!std::filesystem::exists(gamePath))
    throw std::runtime_error("Game path doesn't exist.");

  file.close();

  std::cout << "Config file found:\n" << configPath << "\n\n";
}