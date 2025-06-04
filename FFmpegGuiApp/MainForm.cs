using System.Diagnostics;
using System.Windows.Forms;

namespace FFmpegGuiApp
{
    public partial class MainForm : Form
    {
        public MainForm()

        {
            InitializeComponent(GetLabel1());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            txtInputPath.AllowDrop = true;
            txtInputPath.DragEnter += new DragEventHandler((s, e) => {
                if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop)) 
                    e.Effect = DragDropEffects.Copy;
            });

            txtInputPath.DragDrop += new DragEventHandler((s, e) => {

                if ((e.Data?.GetData(DataFormats.FileDrop) is string[] files) && files.Length > 0)
                {
                    txtInputPath.Text = files[0];

                    // Автоматически предложить имя выходного файла
                    string inputFileName = Path.GetFileNameWithoutExtension(files[0]);
                    txtOutputPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), inputFileName + "_converted.mp4");
                }
            });

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(txtInputPath.Text);
                    txtOutputPath.Text = Path.Combine(dialog.SelectedPath, inputFileName + "_converted.mp4");
                }
            }
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(txtInputPath.Text);
                    txtOutputPath.Text = Path.Combine(dialog.SelectedPath, inputFileName + "_converted.mp4");
                }
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void comboResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboResolution.SelectedItem is string selected)
            {
                bool isCustom = selected == "Custom";
                txtCustomWidth.Enabled = isCustom;
                txtCustomHeight.Enabled = isCustom;
            }
            else
            {
                MessageBox.Show("Выберите разрешение.");
            }

        }


        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputPath = txtInputPath.Text;
            string outputPath = txtOutputPath.Text;

            if (!File.Exists(inputPath))
            {
                MessageBox.Show("Input file does not exist.");
                return;
            }

            if (string.IsNullOrEmpty(outputPath))
            {
                MessageBox.Show("Please specify an output path.");
                return;
            }

            if (comboResolution.SelectedItem is not string resolution || string.IsNullOrEmpty(resolution))
            {
                MessageBox.Show("Please select a resolution.");
                return;
            }

            if (resolution == "Custom")
            {
                if (!int.TryParse(txtCustomWidth.Text, out int width) || !int.TryParse(txtCustomHeight.Text, out int height))
                {
                    MessageBox.Show("Invalid custom resolution values.");
                    return;
                }
                resolution = $"{width}:{height}";
            }
            else
            {
                int start = resolution.IndexOf('(') + 1;
                int end = resolution.IndexOf(')');
                resolution = resolution.Substring(start, end - start).Replace("x", ":");
            }

            string ffmpegArgs = $"-i \"{inputPath}\" -vf scale={resolution} \"{outputPath}\"";

            Process ffmpeg = new Process();
            ffmpeg.StartInfo.FileName = "ffmpeg";
            ffmpeg.StartInfo.Arguments = ffmpegArgs;
            ffmpeg.StartInfo.CreateNoWindow = true;
            ffmpeg.StartInfo.UseShellExecute = false;
            ffmpeg.StartInfo.RedirectStandardOutput = true;
            ffmpeg.StartInfo.RedirectStandardError = true;
            ffmpeg.OutputDataReceived += (s, ea) => Console.WriteLine(ea.Data);
            ffmpeg.ErrorDataReceived += (s, ea) => Console.WriteLine(ea.Data);

            try
            {
                ffmpeg.Start();
                ffmpeg.BeginOutputReadLine();
                ffmpeg.BeginErrorReadLine();
                ffmpeg.WaitForExit();
                MessageBox.Show("Conversion complete.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error running FFmpeg: " + ex.Message);
            }
        }


    }
}
