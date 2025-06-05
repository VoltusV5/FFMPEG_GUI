using System.Diagnostics;
using System.Windows.Forms;

namespace FFmpegGuiApp
{
    public partial class MainForm : Form
    {
        public MainForm()

        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.MainForm_Load);

            SetupDataGrid();
            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;
        }

        private void Form_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void Form_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetData(DataFormats.FileDrop) is string[] files)
            {
                foreach (var file in files)
                {
                    if (File.Exists(file)) AddFileToGrid(file);
                }
            }
        }

        private void AddFileToGrid(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            dataGridView1.Rows.Add(path, "Default", outputFolder, filename + "_converted");
        }




        private void MainForm_Load(object sender, EventArgs e)
        {
            txtInputPath.AllowDrop = true;
            txtInputPath.DragEnter += new DragEventHandler((s, e) =>
            {
                if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
                    e.Effect = DragDropEffects.Copy;
            });

            txtInputPath.DragDrop += new DragEventHandler((s, e) =>
            {

                if ((e.Data?.GetData(DataFormats.FileDrop) is string[] files) && files.Length > 0)
                {
                    txtInputPath.Text = files[0];

                    // јвтоматически предложить им€ выходного файла
                    string inputFileName = Path.GetFileNameWithoutExtension(files[0]);
                    txtOutputPath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), inputFileName + "_converted.mp4");
                }
            });

        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            /*
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(txtInputPath.Text);
                    txtOutputPath.Text = Path.Combine(dialog.SelectedPath, inputFileName + "_converted.mp4");
                }
            }*/

            using FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["OutputFolder"].Value = fbd.SelectedPath;
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
            /*
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string inputFileName = Path.GetFileNameWithoutExtension(txtInputPath.Text);
                    txtOutputPath.Text = Path.Combine(dialog.SelectedPath, inputFileName + "_converted.mp4");
                }
            }*/
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Media files|*.mp4;*.avi;*.mov;*.mkv;*.mp3;*.wav;*.flac|All files|*.*"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in ofd.FileNames)
                    AddFileToGrid(file);
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
                MessageBox.Show("¬ыберите разрешение.");
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

        private void SetupDataGrid()
        {
            dataGridView1.AllowDrop = true;

            if (dataGridView1.Columns.Count == 0) // защититьс€ от повторного добавлени€
            {
                dataGridView1.Columns.Add("SourceFile", "Source File");
                dataGridView1.Columns.Add("Preset", "Preset");
                dataGridView1.Columns.Add("OutputFolder", "Output Folder");
                dataGridView1.Columns.Add("OutputFilename", "Output Filename (w/o extension)");
            }
        }

        private void AddFileToGrid(string path)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["SourceFile"].Value?.ToString() == path)
                    return; // уже есть
            }

            string filename = Path.GetFileNameWithoutExtension(path);
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            dataGridView1.Rows.Add(path, "Default", outputFolder, filename + "_converted");
        }


    }
}
