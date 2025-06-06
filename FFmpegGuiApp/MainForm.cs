using System.Diagnostics;
using System.Windows.Forms;

namespace FFmpegGuiApp
{
    public partial class MainForm : Form
    {
        public MainForm()

        {
            InitializeComponent();
            StyleDataGridView();
            

            


            SetupDataGrid();
            this.AllowDrop = true;
            this.DragEnter += Form_DragEnter;
            this.DragDrop += Form_DragDrop;
        }


        private void StyleDataGridView()
        {
            var grid = dataGridView1;

            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = Color.White;
            grid.EnableHeadersVisualStyles = false;

            // Шапка
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Строки
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 235, 255);
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grid.RowTemplate.Height = 28;
            grid.RowHeadersVisible = false;
            grid.GridColor = Color.LightGray;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
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

        private void AddUniqueFileToGrid(string path)
        {
            string filename = Path.GetFileNameWithoutExtension(path);
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            dataGridView1.Rows.Add(path, "Default", outputFolder, filename + "_converted");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

       

        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Здесь можешь выполнить инициализацию при запуске формы, если нужно
        }
        private void btnBrowseInput_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Video files|*.mp4;*.mov;*.avi;*.mkv|All files|*.*";
                ofd.Multiselect = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (var file in ofd.FileNames)
                    {
                        AddUniqueFileToGrid(file); // или AddFileToGrid(file) — в зависимости от логики
                    }
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue; // пропустить пустую строку

                string inputPath = row.Cells["SourceFile"].Value?.ToString();
                string outputFolder = row.Cells["OutputFolder"].Value?.ToString();
                string outputFilename = row.Cells["OutputFilename"].Value?.ToString();
                string preset = row.Cells["Preset"].Value?.ToString(); // пока не используешь

                if (string.IsNullOrWhiteSpace(inputPath) || string.IsNullOrWhiteSpace(outputFolder) || string.IsNullOrWhiteSpace(outputFilename))
                    continue; // пропустить неполные строки

                string fullOutputPath = Path.Combine(outputFolder, outputFilename + ".mp4");

                // Пример разрешения (временное значение — можно из отдельной ячейки тоже брать)
                string resolution = row.Cells["Resolution"].Value?.ToString() ?? "1280:720";


                string ffmpegArgs = $"-i \"{inputPath}\" -vf scale={resolution} \"{fullOutputPath}\"";

                Process ffmpeg = new Process();
                string ffmpegPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg", "ffmpeg.exe");
                ffmpeg.StartInfo.FileName = ffmpegPath;

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error running FFmpeg: " + ex.Message);
                }
            }

        }

        private void SetupDataGrid()
        {
            dataGridView1.AllowDrop = true;

            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SourceFile",
                    HeaderText = "Source File"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Preset",
                    HeaderText = "Preset"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "OutputFolder",
                    HeaderText = "Output Folder"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "OutputFilename",
                    HeaderText = "Output Filename"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Resolution",
                    HeaderText = "Resolution"
                });
            }
        }


        private void AddFileToGrid(string path)
        {
            // Безопасно добавляем столбцы, если ещё не добавлены
            if (!dataGridView1.Columns.Contains("SourceFile"))
            {
                SetupDataGrid();
            }

            // Проверяем — уже есть такой файл?
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (dataGridView1.Columns.Contains("SourceFile"))
                {
                    if (row.Cells["SourceFile"].Value?.ToString() == path)
                        return;
                }
            }

            string filename = Path.GetFileNameWithoutExtension(path);
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            dataGridView1.Rows.Add(path, "Default", outputFolder, filename + "_converted", "1280:720");
        }



    }
}
