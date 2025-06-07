using System.Diagnostics;
using System.Windows.Forms;

namespace FFmpegGuiApp
{
    public partial class MainForm : Form
    {
        public MainForm()

        {
            InitializeComponent();
            SetupDataGrid();
            StyleDataGridView();






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

                string inputPath = row.Cells["Column1"].Value?.ToString();
                string outputFolder = row.Cells["Column3"].Value?.ToString();
                string outputFilename = row.Cells["Column4"].Value?.ToString();
                string preset = row.Cells["Column2"].Value?.ToString(); // пока не используешь

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

        private Image ByteArrayToImage(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }


        private void SetupDataGrid()
        {
            dataGridView1.AllowDrop = true;
            dataGridView1.RowTemplate.Height = 32;

            if (dataGridView1.Columns.Count == 0)
            {
                // Заменим иконки на текстовые кнопки через DataGridViewButtonColumn
                var startCol = new DataGridViewButtonColumn
                {
                    Name = "Start_Conversion",
                    HeaderText = "",
                    Width = 40,
                    Text = "▶", // play symbol
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(startCol);

                var infoCol = new DataGridViewButtonColumn
                {
                    Name = "Info",
                    HeaderText = "",
                    Width = 40,
                    Text = "ℹ", // info symbol
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(infoCol);

                var presetCol = new DataGridViewButtonColumn
                {
                    Name = "Preset_Info",
                    HeaderText = "",
                    Width = 40,
                    Text = "🛠", // gearwrench symbol
                    UseColumnTextForButtonValue = true
                };
                dataGridView1.Columns.Add(presetCol);

                // Остальные текстовые колонки
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Column1", // SourceFile
                    HeaderText = "Source File",
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Column2", // Preset
                    HeaderText = "Preset"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Column3", // OutputFolder
                    HeaderText = "Output Folder"
                });
                dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "Column4", // OutputFilename
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
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column1"].Value?.ToString() == path)
                    return; // Уже добавлен
            }

            string filename = Path.GetFileNameWithoutExtension(path);
            string outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            int rowIndex = dataGridView1.Rows.Add();
            var newRow = dataGridView1.Rows[rowIndex];

            // Кнопки оставим пустыми — текст уже задан в колонке
            // Если нужно, можно добавить условия для изменения текста

            newRow.Cells["Start_Conversion"].Value = "▶";
            newRow.Cells["Info"].Value = "ℹ";
            newRow.Cells["Preset_Info"].Value = "🛠";

            // Информационные поля
            newRow.Cells["Column1"].Value = path;
            newRow.Cells["Column2"].Value = "Default";
            newRow.Cells["Column3"].Value = outputFolder;
            newRow.Cells["Column4"].Value = filename + "_converted";
        }

    }
}
