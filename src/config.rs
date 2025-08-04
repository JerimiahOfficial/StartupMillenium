use serde::{Deserialize, Serialize};

#[derive(Debug, Serialize, Deserialize, Clone, PartialEq)]
pub struct Settings {
    pub game_path: String,
}

pub async fn write_config() -> std::io::Result<()> {
    let config_path = std::env::current_dir()
        .expect("Failed to get current directory")
        .join("config.json");

    let game_path;
    let settings;

    // Based on target os change default paths accordingly
    #[cfg(target_os = "windows")]
    {
        game_path =
            String::from("C:\\Program Files (x86)\\Steam\\steamapps\\common\\GarrysMod\\gmod.exe");
        settings = Settings { game_path };
    }

    #[cfg(target_os = "linux")]
    {
        game_path = String::from("");
        settings = Settings { game_path };
    }

    #[cfg(target_os = "macos")]
    {
        game_path = String::from("");
        settings = Settings { game_path };
    }

    let json_data = serde_json::to_string_pretty(&settings).expect("Failed to serialize Settings");

    tokio::fs::write(config_path, json_data.as_bytes())
        .await
        .expect("Failed to write config file");

    Ok(())
}

pub async fn read_config() -> std::io::Result<Settings> {
    let config_path = std::env::current_dir()
        .expect("Failed to get current directory")
        .join("config.json");

    if !config_path.exists() {
        write_config()
            .await
            .expect("Failed to create configuration file");
    }

    let data = tokio::fs::read_to_string(config_path)
        .await
        .expect("Failed to read config file");

    let settings: Settings = serde_json::from_str(&data).expect("Failed to parse config file");

    Ok(settings)
}

#[tokio::test]
async fn test_write_config() {
    write_config().await.expect("Failed to write config.");
}

#[tokio::test]
async fn test_read_config() {
    read_config().await.expect("Failed to read config.");
}
