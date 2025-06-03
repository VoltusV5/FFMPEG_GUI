# 🎞️ FFmpeg GUI Preset Manager

An open-source graphical user interface (GUI) for **FFmpeg** that brings the power of advanced video and audio encoding to users of all levels. Easily build commands visually, manage custom presets, queue jobs, and export configurations — all through a clean and intuitive interface.

---

## 🚀 Project Goal

To create a user-friendly, visual front-end for **FFmpeg** that supports:
- Preset management  
- Step-by-step command generation  
- Encoding job queue  
- Exporting settings to a readable **XML format**  

Whether you're a beginner or a power user, the interface is designed to provide clarity and control.

---

## 🔧 Key Features

### 1. Parameter Selection & Command Preview

Easily choose and configure:

- **Codecs:**
  - Video: `libx264`, `libx265`, `vp9`, `av1`
  - Audio: `aac`, `mp3`, `opus`, `copy`
- **Containers:** `mp4`, `mkv`, `webm`, `mov`
- **Settings:**
  - CRF or bitrate
  - Resolution (scale)
  - FPS
  - Audio bitrate & sample rate
  - Filters: crop, deinterlace, etc.
  - Preset speed: `ultrafast` to `veryslow` (for x264/x265)

The corresponding **FFmpeg command** is auto-generated and displayed:
- 👁️ Live preview  
- 📋 Copy to clipboard  
- ✍️ Edit manually (optional)  
- ▶️ Use it for actual encoding

---

### 2. Preset System

Save your favorite configurations for reuse:

- Create presets from current settings  
- Export/import as **XML** (compatible with other tools)  
- Add metadata: name, description, category  
- Organize and reuse presets efficiently  

---

### 3. Encoding Queue

Process multiple files in sequence:

- Add file groups and assign different presets  
- Tasks are added to a **queue**  
- One-click **"Start Encoding"** button  
- Real-time logs, progress bar, and pause/resume support  

---

### 4. Output & Logging

Stay informed:

- Task status: Running / Done / Error  
- Live **FFmpeg log** inside the GUI  
- Optional: Open output folder after completion  

---

## 📁 Additional Notes

- 💡 Open-source (on GitHub)  
- 📜 Clean codebase with documentation  
- 🔌 Extensible (e.g., custom FFmpeg filters, GPU encoding support)

---

## 🛠️ Technology Stack

| Area                 | Technology        |
|----------------------|------------------|
| Language             | **C#**            |
| Platform             | **.NET 8**        |
| GUI Framework        | **WinForms**      |
| FFmpeg Integration   | Direct `ffmpeg.exe` process calls |
| Preset Storage       | **XML** format    |

---

## 🧪 First Prototype Goals

A minimal WinForms application that allows users to:

1. Select a video file  
2. Choose a new resolution  
3. Re-encode the file with that resolution  
4. View and execute the generated FFmpeg command  

---

## 📌 License

This project is open-source and will be released under MIT License.

---

## 🙌 Contributing

Pull requests, suggestions, and feedback are welcome! Stay tuned for the first release.
