mod config;
mod process;

use process::Process;

#[tokio::main]
async fn main() {
    let settings = config::read_config()
        .await
        .expect("Failed to read configuration file");

    let exec_path = std::path::PathBuf::from(settings.game_path);
    if !exec_path.exists() {
        println!("Make sure the game path is correct in the configuration file.");
        return;
    }

    let mut process = Process::new(exec_path);
    for i in 0..1000 {
        process.start().await;
        process.wait_for_idle().await;
        process.stop().await;

        println!("{} / 1000", i + 1)
    }

    println!("Finished");
}
