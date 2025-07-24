use std::time::Duration;

use sysinfo::System;

pub struct Process {
    // Base process information
    exec_path: std::path::PathBuf,
    child: Option<std::process::Child>,
}

impl Process {
    pub fn new(exec_path: std::path::PathBuf) -> Self {
        Self {
            exec_path,
            child: None,
        }
    }

    pub async fn start(&mut self) {
        let child = std::process::Command::new(self.exec_path.clone())
            .spawn()
            .expect("Failed to start the process");

        self.child = Some(child);
    }

    pub async fn stop(&mut self) {
        if let Some(mut child) = self.child.take() {
            child.kill().expect("Failed to kill process.");

            println!("Process killed.")
        }
    }

    pub async fn wait_for_idle(&self) {
        let mut system = System::new();

        loop {
            tokio::time::sleep(sysinfo::MINIMUM_CPU_UPDATE_INTERVAL).await;
            system.refresh_cpu_usage();

            if self.child.is_none() {
                break;
            }

            let cores = sysinfo::System::physical_core_count().expect("Unable to get core count");
            let cpu_usage =
                system.cpus().iter().map(|cpu| cpu.cpu_usage()).sum::<f32>() / cores as f32;

            if cpu_usage <= 15.0 {
                println!("Process is idling.");
                break;
            }

            println!("Waiting for idle...");
            tokio::time::sleep(Duration::from_secs(5)).await;
        }
    }
}
